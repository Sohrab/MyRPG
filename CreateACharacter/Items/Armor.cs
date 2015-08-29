using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateACharacter.Items;

namespace CreateACharacter.Model
{
    public class Armor : Item
    {

        public string ArmorName { get; set; }
        public int ArmorPoints { get; set; }

        public BonusStats BonusStatistics { get; set; }

        public int ArmorDodgeChance { get; set; }

        


        public void BuyArmor()
        {
            if (Repository.Player.Gold >= this.BuyPrice)
            {
                Repository.Player.EquipedArmor = this;
                Repository.Player.Gold -= this.BuyPrice;
                Repository.ErrorMessage.MessageState = 1;
                Repository.ErrorMessage.ShopMessage = "Buy Sucess!";
                
                
            }
            else
            {
                Repository.ErrorMessage.MessageState = 2;
                Repository.ErrorMessage.ShopMessage = "Not Enough Gold =(";
            }


            
            //Buy and/Or equip armor

            
        }


       
    }
}
