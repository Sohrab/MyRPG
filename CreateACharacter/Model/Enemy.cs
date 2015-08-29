using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateACharacter.Items;
using MyPropertyChangedBase;

namespace CreateACharacter.Model
{
    public class Enemy : PropertyChangedBase
    {
        public string EnemyName { get; set; }

        public string ImgPath { get; set; }
        public int RandomiZer { get; set; }

        int healthpoints;
        public int HealthPoints { 
            get
            {
                return healthpoints;
            }
            set
            {
                healthpoints = value;
                OnPropertyChanged();
            }
        }
        public int Armor { get; set; }
        public int Damage { get; set; }


        public Enemy(string name, int hp, int armor, int damage, int randomizer, string imgPath)
        {
            EnemyName = name;
            HealthPoints = hp;
            Armor = armor;
            Damage = damage;
            RandomiZer = randomizer;
            ImgPath = imgPath;
        }
    }
}
