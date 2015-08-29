using CreateACharacter.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPropertyChangedBase;

namespace CreateACharacter.Model
{
    public class Shop : PropertyChangedBase
    {



        public string shopResultText = "";

        public string ShopResultText
        {
            get { return shopResultText; }
            set { shopResultText = value; OnPropertyChanged(); }
        }


        public List<Armor> ArmorListShop { get; set; }

        public List<Weapon> WeaponListShop { get; set; }

        public List<Shield> ShieldListShop { get; set; }


        public ItemGenerator itemGenerator = new ItemGenerator();

        public Weapon SelectedWeapon { get; set; }

        public Armor SelectedArmor { get; set; }


        public void GenerateItems()
        {
            WeaponListShop = GenerateWeapons();
            ArmorListShop = GenerateArmors();
            ShieldListShop = GenerateShields();

        }

        private List<Shield> GenerateShields()
        {

            List<Shield> shieldList = new List<Shield>();
            Shield shield1 = new Shield();
            Shield shield2 = new Shield();
            Shield shield3 = new Shield();

            shield1 = itemGenerator.GenerateShield(0);
            shield2 = itemGenerator.GenerateShield(1);
            shield3 = itemGenerator.GenerateShield(2);
            shieldList.Add(shield1);
            shieldList.Add(shield2);
            shieldList.Add(shield3);

            return shieldList;

        }


        private List<Armor> GenerateArmors()
        {
            List<Armor> armorlist = new List<Armor>();

            Armor armor1 = new Armor();
            Armor armor2 = new Armor();
            Armor armor3 = new Armor();

            armor1 = itemGenerator.GenerateArmor(0);
            armor2 = itemGenerator.GenerateArmor(1);
            armor3 = itemGenerator.GenerateArmor(2);

            armorlist.Add(armor1);
            armorlist.Add(armor2);
            armorlist.Add(armor3);


            return armorlist;
        }

        private List<Weapon> GenerateWeapons()
        {
            List<Weapon> weaponlist = new List<Weapon>();

            Weapon weapon1 = new Weapon();
            Weapon weapon2 = new Weapon();
            Weapon weapon3 = new Weapon();

            weapon1 = itemGenerator.GenerateWeapon(0);
            weapon2 = itemGenerator.GenerateWeapon(1);
            weapon3 = itemGenerator.GenerateWeapon(2);
            weaponlist.Add(weapon1);
            weaponlist.Add(weapon2);
            weaponlist.Add(weapon3);

            /*
            Weapon lightWeapon = new Weapon() { WeaponName = "Light Weapon", WeaponDamage = 20, ParryChance = 10 };
            Weapon mediumWeapon = new Weapon() { WeaponName = "Medium Weapon", WeaponDamage = 35, ParryChance = 20 };
            Weapon heavyWeapon = new Weapon() { WeaponName = "Heavy Weapon", WeaponDamage = 50, ParryChance = 30 };
            weaponlist.Add(lightWeapon);
            weaponlist.Add(mediumWeapon);
            weaponlist.Add(heavyWeapon);*/

            return weaponlist;
        }





    }
}
