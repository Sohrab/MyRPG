using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateACharacter.Items;

namespace CreateACharacter.Model
{
    public class ItemGenerator
    {
        Random rnd = new Random();

        public List<string> itemRarityNames = new List<string>();

        public List<string> ItemRankNames = new List<string>();

        public List<string> ItemTypeNames = new List<string>();


        public ItemGenerator()
        {
            initialize();
        }

        private void initialize()
        {

            itemRarityNames.Add("Lesser");
            itemRarityNames.Add("Medium");
            itemRarityNames.Add("Heavy");
            itemRarityNames.Add("LEGENDARY");

            ItemRankNames.Add("peasant");
            ItemRankNames.Add("soldier");
            ItemRankNames.Add("knight");
            ItemRankNames.Add("ROYAL");

            ItemTypeNames.Add("armor");
            ItemTypeNames.Add("shield");
            ItemTypeNames.Add("weapon");
        }











        public Shield GenerateShield(int _shieldValue)
        {
            Shield genShield = new Shield();


            if (_shieldValue == 0)
            {
                genShield.ShieldArmor = rnd.Next(0, 101);
                genShield.ShieldBlockChance = rnd.Next(0, 6);
                genShield.BuyPrice = rnd.Next(30, 71);
                genShield.ShieldName = SetSheildName(genShield);


            }
            if (_shieldValue == 1)
            {
                genShield.ShieldArmor = rnd.Next(20, 201);
                genShield.ShieldBlockChance = rnd.Next(0, 16);
                genShield.BuyPrice = rnd.Next(71, 140);
                genShield.ShieldName = SetSheildName(genShield);
            }
            if (_shieldValue == 2)
            {
                genShield.ShieldArmor = rnd.Next(100, 301);
                genShield.ShieldBlockChance = rnd.Next(0, 21);
                genShield.BuyPrice = rnd.Next(141, 280);
                genShield.ShieldName = SetSheildName(genShield);
            }
            if (_shieldValue == 3)
            {
                genShield.ShieldArmor = rnd.Next(200, 401);
                genShield.ShieldBlockChance = rnd.Next(10, 31);
                genShield.BuyPrice = rnd.Next(281, 560);
                genShield.ShieldName = SetSheildName(genShield);
            }

            return genShield;
        }



        public Armor GenerateArmor(int _armorValue)
        {
            Armor genArmor = new Armor();
            if (_armorValue == 0)
            {
                genArmor.ArmorPoints = rnd.Next(0, 101);
                genArmor.ArmorDodgeChance = rnd.Next(0, 6);
                genArmor.BuyPrice = rnd.Next(30, 71);
                genArmor.ArmorName = SetArmorName(genArmor);
            }
            if (_armorValue == 1)
            {
                genArmor.ArmorPoints = rnd.Next(20, 201);
                genArmor.ArmorDodgeChance = rnd.Next(0, 16);
                genArmor.BuyPrice = rnd.Next(70, 141);
                genArmor.ArmorName = SetArmorName(genArmor);
            }
            if (_armorValue == 2)
            {
                genArmor.ArmorPoints = rnd.Next(100, 301);
                genArmor.ArmorDodgeChance = rnd.Next(0, 21);
                genArmor.BuyPrice = rnd.Next(140, 281);
                genArmor.ArmorName = SetArmorName(genArmor);
            }
            if (_armorValue == 3)
            {
                genArmor.ArmorPoints = rnd.Next(200, 401);
                genArmor.ArmorDodgeChance = rnd.Next(10, 31);
                genArmor.BuyPrice = rnd.Next(280, 561);
                genArmor.ArmorName = SetArmorName(genArmor);
            }


            return genArmor;
        }

        public Weapon GenerateWeapon(int _weaponValue)
        {

            Weapon genWeapon = new Weapon();

            //Set Damage
            if (_weaponValue == 0)
            {
                genWeapon.WeaponDamage = rnd.Next(10, 61);
                genWeapon.ParryChance = rnd.Next(0, 3);
                genWeapon.BuyPrice = rnd.Next(30, 71);
                genWeapon.WeaponName = SetWeapinName(genWeapon);
            }
            if (_weaponValue == 1)
            {
                genWeapon.WeaponDamage = rnd.Next(40, 100);
                genWeapon.ParryChance = rnd.Next(0, 6);
                genWeapon.BuyPrice = rnd.Next(70, 141);
                genWeapon.WeaponName = SetWeapinName(genWeapon);
            }
            if (_weaponValue == 2)
            {
                genWeapon.WeaponDamage = rnd.Next(100, 151);
                genWeapon.ParryChance = rnd.Next(3, 9);
                genWeapon.BuyPrice = rnd.Next(140, 281);
                genWeapon.WeaponName = SetWeapinName(genWeapon);
            }
            if (_weaponValue == 3)
            {
                genWeapon.WeaponDamage = rnd.Next(200, 301);
                genWeapon.ParryChance = rnd.Next(5, 11);
                genWeapon.BuyPrice = rnd.Next(280, 561);
                genWeapon.WeaponName = SetWeapinName(genWeapon);
            }


            return genWeapon;
        }







        //-
        //SET ITEM NAMES
        //-



        //Set Shield Name
        public string SetSheildName(Shield _genItem)
        {
            string itemName = "";

            //Set Rarity Name
            if (_genItem.ShieldArmor < 101)
            {
                itemName += itemRarityNames[0];
                _genItem.Rarity = 1;
                
            }
            if (_genItem.ShieldArmor > 100 && _genItem.ShieldArmor < 201)
            {
                itemName += itemRarityNames[1];
                _genItem.Rarity = 2;
            }
            if (_genItem.ShieldArmor > 200 && _genItem.ShieldArmor < 301)
            {
                itemName += itemRarityNames[2];
                _genItem.Rarity = 3;
            }
            if (_genItem.ShieldArmor > 300 && _genItem.ShieldArmor < 401)
            {
                itemName += itemRarityNames[3];
                _genItem.Rarity = 4;
            }

            //Set Rank Name
            if (_genItem.ShieldBlockChance < 6)
            {
                itemName += " " + ItemRankNames[0];
                _genItem.Rank = 1;
                _genItem.ImgPath = "Images/Shield1.png";
            }
            if (_genItem.ShieldBlockChance > 5 && _genItem.ShieldBlockChance < 16)
            {
                itemName += " " + ItemRankNames[1];
                _genItem.Rank = 2;
                _genItem.ImgPath = "Images/Shield2.png";
            }
            if (_genItem.ShieldBlockChance > 15 && _genItem.ShieldBlockChance < 21)
            {
                itemName += " " + ItemRankNames[2];
                _genItem.Rank = 3;
                _genItem.ImgPath = "Images/Shield3.png";
            }
            if (_genItem.ShieldBlockChance > 20 && _genItem.ShieldBlockChance < 31)
            {
                itemName += " " + ItemRankNames[3];
                _genItem.Rank = 4;
                _genItem.ImgPath = "Images/Shield4.png";
            }

            //Set Type Name
            itemName += " " + ItemTypeNames[1];

            return itemName;
        }


        //Set Armor Name
        public string SetArmorName(Armor _genItem)
        {
            string itemName = "";

            //Set Rarity Name
            if (_genItem.ArmorPoints < 101)
            {
                itemName += itemRarityNames[0];
                _genItem.Rarity = 1;
            }
            if (_genItem.ArmorPoints > 100 && _genItem.ArmorPoints < 201)
            {
                itemName += itemRarityNames[1];
                _genItem.Rarity = 2;
            }
            if (_genItem.ArmorPoints > 200 && _genItem.ArmorPoints < 301)
            {
                itemName += itemRarityNames[2];
                _genItem.Rarity = 3;
            }
            if (_genItem.ArmorPoints > 300 && _genItem.ArmorPoints < 401)
            {
                itemName += itemRarityNames[3];
                _genItem.Rarity = 4;
            }

            //Set Rank Name
            if (_genItem.ArmorDodgeChance < 6)
            {
                itemName += " " + ItemRankNames[0];
                _genItem.Rank = 1;
                _genItem.ImgPath = "Images/Armor1.png";
            }
            if (_genItem.ArmorDodgeChance > 5 && _genItem.ArmorDodgeChance < 16)
            {
                itemName += " " + ItemRankNames[1];
                _genItem.Rank = 2;
                _genItem.ImgPath = "Images/Armor2.png";
            }
            if (_genItem.ArmorDodgeChance > 15 && _genItem.ArmorDodgeChance < 21)
            {
                itemName += " " + ItemRankNames[2];
                _genItem.Rank = 3;
                _genItem.ImgPath = "Images/Armor3.png";
            }
            if (_genItem.ArmorDodgeChance > 20 && _genItem.ArmorDodgeChance < 31)
            {
                itemName += " " + ItemRankNames[3];
                _genItem.Rank = 4;
                _genItem.ImgPath = "Images/Armor4.png";
            }

            //Set Type Name
            itemName += " " + ItemTypeNames[0];

            return itemName;
        }


        //Set Weapon Name
        public string SetWeapinName(Weapon _genItem)
        {
            string itemName = "";

            //Set Rarity Name
            if (_genItem.WeaponDamage < 61)
            {
                itemName += itemRarityNames[0];
                _genItem.Rarity = 1;
            }
            if (_genItem.WeaponDamage > 60 && _genItem.WeaponDamage < 101)
            {
                itemName += itemRarityNames[1];
                _genItem.Rarity = 2;
            }
            if (_genItem.WeaponDamage > 100 && _genItem.WeaponDamage < 151)
            {
                itemName += itemRarityNames[2];
                _genItem.Rarity = 3;
            }
            if (_genItem.WeaponDamage > 200 && _genItem.WeaponDamage < 301)
            {
                itemName += itemRarityNames[3];
                _genItem.Rarity = 4;
            }

            //Set Rank Name
            if (_genItem.ParryChance < 6)
            {
                itemName += " " + ItemRankNames[0];
                _genItem.Rank = 1;
                _genItem.ImgPath = "Images/Weapon1.png";
            }
            if (_genItem.ParryChance > 5 && _genItem.ParryChance < 16)
            {
                itemName += " " + ItemRankNames[1];
                _genItem.Rank = 2;
                _genItem.ImgPath = "Images/Weapon2.png";
            }
            if (_genItem.ParryChance > 15 && _genItem.ParryChance < 21)
            {
                itemName += " " + ItemRankNames[2];
                _genItem.Rank = 3;
                _genItem.ImgPath = "Images/Weapon3.png";
            }
            if (_genItem.ParryChance > 20 && _genItem.ParryChance < 31)
            {
                itemName += " " + ItemRankNames[3];
                _genItem.Rank = 4;
                _genItem.ImgPath = "Images/Weapon4.png";
            }

            //Set Type Name
            itemName += " " + ItemTypeNames[2];

            return itemName;
        }
    }
}
