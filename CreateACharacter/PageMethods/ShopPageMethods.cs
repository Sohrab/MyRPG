using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateACharacter.Model;

namespace CreateACharacter.PageMethods
{
    public class ShopPageMethods
    {

        public Weapon SelectedWeapon { get; set; }

        public Armor SelectedArmor { get; set; }



        public void Buy()
        {
            if (SelectedWeapon != null)
            {
                Repository.Player.Damage += SelectedWeapon.WeaponDamage;
            }
            if (SelectedArmor != null)
            {
                //epository.Player.Armor += SelectedArmor.ArmorPoints;
            }
        }
    }
}
