using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateACharacter.Items;
using MyPropertyChangedBase;
using Newtonsoft.Json;
using Windows.Storage;
using System.Runtime.Serialization;


namespace CreateACharacter.Model
{
    public class Player : PropertyChangedBase
    {

        string name;
        int health = 100;
        int maxHealth = 100;
        int damage = 5;
        int armor = 0;
        int critChance = 0;
        int blockChance = 0;
        int parryChance = 0;
        int dodgeChance = 0;
        int gold = 100;
        bool wepEquiped = false;
        bool shieldEquiped = false;
        bool armorEquiped = false;
        Weapon equipedWeapon;
        Shield equipedShield;
        Armor equpedArmor;

        public string ImgPath { get; set; }
        public int Maxhealth { get { return maxHealth; } set { maxHealth = value; } }
        public string PlayerName { get { return name; } set { name = value; } }
        public int Health { get 
        { return health; } set 
        { health = value; OnPropertyChanged(); 
        } 
        }
        public int Damage { get { return damage; } set { damage = value; } }
        public int Armor { get { return armor; } set { health = armor; } }
        public int CritChance { get { return critChance; } set { critChance = value; } }
        public int BlockChance { get { return blockChance; } set { blockChance = value; } }
        public int ParryChance { get { return parryChance; } set { parryChance = value; } }
        public int DodgeChance { get { return dodgeChance; } set { dodgeChance = value; } }
        public bool WepEquiped { get { return wepEquiped; } set { wepEquiped = value;   } }
        public bool ArmorEquiped { get { return armorEquiped; } set { armorEquiped = value; } }
        public bool ShieldEquiped { get { return shieldEquiped; } set { shieldEquiped = value; } }
        public Weapon EquipedWeapon { 
            get 
            { 
                return equipedWeapon; 
            } 
            set 
            {
                if (equipedWeapon != null)
                {
                    UnEquipWeapon(equipedWeapon);
                    EquipWeapon(value);
                }
                else
                {
                    EquipWeapon(value);
                }


                equipedWeapon = value;
            }
 
        }
        public Armor EquipedArmor { 
            get 
            { 
                return equpedArmor; 
            } 
            set
            {

                if (equpedArmor != null)
                {
                    UnEquipArmor(equpedArmor);
                    EquipArmor(value);
                }
                else
                {
                    EquipArmor(value);
                }
                equpedArmor = value; 
            } 
        }
        public Shield EquipedShield { 
            get 
            { 
                return equipedShield; 
            } 
            set
            {
                    if (equipedShield != null)
                    {
                        UnEquipShield(equipedShield);
                        EquipShield(value);
                    }
                    else
                    {
                        EquipShield(value);
                    }

                equipedShield = value; 
            } 
        }

        List<Enemy> defeatedEnemies = new List<Enemy>();
        public List<Enemy> DefeatedEnemies { get { return defeatedEnemies; } set { defeatedEnemies = value; } }
        public int Gold { get { return gold; } set { gold = value; OnPropertyChanged(); } }






        public int CheckDefeatedEnemies()
        {
            int amount;
            if (DefeatedEnemies != null)
            {
                amount = DefeatedEnemies.Count();
            }
            else
            {
                amount = 0;
            }


            return amount;
        }






        //-
        //Weapon Methods
        //-
        public void EquipWeapon (Weapon _weapon)
        {
            if (_weapon != null)
            {
                damage = damage + _weapon.WeaponDamage;
                parryChance = parryChance + _weapon.ParryChance;
                wepEquiped = true;
            }

        }
        public void UnEquipWeapon (Weapon _weapon)
        {
            damage = damage - _weapon.WeaponDamage;
            parryChance = parryChance - _weapon.ParryChance;
            wepEquiped = false;
        }


        //-
        //Armor Methods
        //-

        public void EquipArmor(Armor _armor)
        {
            if (_armor != null)
            {
                armor = armor + _armor.ArmorPoints;
                dodgeChance = blockChance + _armor.ArmorDodgeChance;
                armorEquiped = true;
            }

        }
        public void UnEquipArmor(Armor _armor)
        {
            armor = armor - _armor.ArmorPoints;
            dodgeChance = blockChance - _armor.ArmorDodgeChance;
            armorEquiped = false;
        }


        //-
        //Shield Methods
        //-

        public void EquipShield(Shield _shield)
        {
            if (_shield != null)
            {
                armor = armor + _shield.ShieldArmor;
                blockChance = blockChance + _shield.ShieldBlockChance;
                shieldEquiped = true;
            }

        }
        public void UnEquipShield(Shield _shield)
        {
            armor = armor - _shield.ShieldArmor;
            blockChance = blockChance - _shield.ShieldBlockChance;
            shieldEquiped = false;
        }

        public void SellShield()
        {
            Gold += EquipedShield.SellPrice;
            EquipedShield = null;
        }




















        //Save Hero



        private StorageFolder _folder = ApplicationData.Current.LocalFolder;
        private string _filename = "player.json";

        

        public void SaveGame()
        {
            Save();
        }

        public Task Save()
        {
            return Task.Run(async () =>
            {
                string player = JsonConvert.SerializeObject(Repository.Player);
                var file = await OpenFileAsync();
                await FileIO.WriteTextAsync(file, player);

            }
            );
        }

        private async Task<StorageFile> OpenFileAsync()
        {

            return await _folder.CreateFileAsync(_filename, CreationCollisionOption.ReplaceExisting);
        }






        public void Load()
        {
            LoadGame();
        }

        private async Task LoadGame()
        {
            var file = await _folder.CreateFileAsync(_filename, CreationCollisionOption.OpenIfExists);
            string filecontent = String.Empty;

            if (file != null)
            {
                filecontent = await FileIO.ReadTextAsync(file);
            }

                Player player =
                JsonConvert.DeserializeObject<Player>
                (filecontent) ?? new Player();

                
                Repository.Player = player;
                Repository.Player.Health = 100;
                


        }





        //NavigateToPage kallas inte när LoadComplete ändras till true
        public bool LoadComplete { get; set; }

        [OnDeserializedAttribute()]
        private void RunThisMethod(StreamingContext context)
        {
            
            Repository.Player.LoadComplete = true;
        }



        /* OLD CODE
        string name;
        int health = 100;
        int damage = 5;
        int armor = 0;

        public string PlayerName { get { return name; } set { name = value; } }
        public int HealthPoints { get { return health; } set { health = value; } }
        public int Armor { get { return armor; } set { armor = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public List<Enemy> DefeatedEnemies { get; set; }

      public Weapon EquipedWeapon { get; set; }
      public Armor EquipedArmor { get; set; }*/
    
 }
}
