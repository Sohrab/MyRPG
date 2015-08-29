using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateACharacter.Items;

namespace CreateACharacter.Model
{
    public class Weapon : Item
    {

        public string WeaponName { get; set; }
        public int WeaponDamage { get; set; }

        public BonusStats BonusStatistics { get; set; }

        public int ParryChance { get; set; }
        




        public void BuyWeapon()
        {
            if (Repository.Player.Gold >= this.BuyPrice)
            {
                Repository.Player.EquipedWeapon = this;
                Repository.Player.Gold -= this.BuyPrice;
                Repository.ErrorMessage.MessageState = 1;
                Repository.ErrorMessage.ShopMessage = "Buy Sucess!";


            }
            else
            {
                Repository.ErrorMessage.MessageState = 2;
                Repository.ErrorMessage.ShopMessage = "Not Enough Gold =(";
            }

        }



    }
}
