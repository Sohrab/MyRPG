using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateACharacter.Model;

namespace CreateACharacter.Items
{
    public class Shield : Item
    {

        public string ShieldName { get; set; }
        public int ShieldArmor { get; set; }
        public BonusStats BonusStatistics { get; set; }
        public int ShieldBlockChance { get; set; }



        public void BuyShield()
        {
            if (Repository.Player.Gold >= this.BuyPrice)
            {
                Repository.Player.EquipedShield = this;
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
