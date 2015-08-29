using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPropertyChangedBase;

namespace CreateACharacter.Items
{
    public class Item : PropertyChangedBase
    {


        public int durability;
        public bool usable;
        public int buyPrice;
        public int sellPrice;
        public int InventorySlot;


        public int Rarity { get; set; }

        public int Rank { get; set; }

        public string ImgPath { get; set; }



        public int BuyPrice
        {
            get
            {
                return buyPrice;
            }
            set
            {
                buyPrice = value;
            }
        }

        public int SellPrice {
            get
            {
                return buyPrice / 2;
            }
            set{
                sellPrice = value;
            }
        }

    }
}
