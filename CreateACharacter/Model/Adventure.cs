using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateACharacter.Items;
using MyPropertyChangedBase;

namespace CreateACharacter.Model
{
    public class Adventure : PropertyChangedBase
    {
        public ItemGenerator itemGenerator = new ItemGenerator();

        Random rnd = new Random();
        FightSystem fightsystem = new FightSystem();
        public FightSystem FightSyStem { get { return fightsystem; } set { fightsystem = value; } }


        static Enemy _advEnemy;
        public static Enemy advEnemy { get { return _advEnemy; } set { _advEnemy = value; /*OnPropertyChanged();*/ } }

        List<Item> lootlist = new List<Item>();
        public List<Item> LootList { get { return lootlist; } set { lootlist = value; } }
        public Armor advArmor { get; set; }
        public Shield advShield { get; set; }
        public Weapon advWeapon { get; set; }
        public Adventure(Enemy _advEnemy, int _enemyDifficulty)
        {

            advEnemy = _advEnemy;
            EnemyMaxHP = advEnemy.HealthPoints;
            PlayerMaxHP = Repository.Player.Maxhealth;
            if (_enemyDifficulty == 0)
            {
                GenerateItems(0);
                AdvGold = rnd.Next(50, 151);
            }
            if (_enemyDifficulty == 1)
            {
                GenerateItems(1);
                AdvGold = rnd.Next(100, 201);
            }
            if (_enemyDifficulty == 2)
            {
                GenerateItems(2);
                AdvGold = rnd.Next(150, 251);
            }
            if (_enemyDifficulty == 3)
            {
                GenerateItems(3);
                AdvGold = rnd.Next(200, 301);
            }
            if (_enemyDifficulty == 4)
            {
                GenerateItems(3);
                AdvGold = rnd.Next(350, 501);
            }

            //FightSyStem.PBarMaxValue = _advEnemy.HealthPoints;

            updateProgressBar();
        }






        private void GenerateItems(int itemValue)
        {
            if (itemValue == 0)
            {
                advWeapon = itemGenerator.GenerateWeapon(0);
                advArmor = itemGenerator.GenerateArmor(0);
                advShield = itemGenerator.GenerateShield(0);
                LootList.Add(advWeapon);
                LootList.Add(advArmor);
                LootList.Add(advShield);
            }
            if (itemValue == 1)
            {
                advWeapon = itemGenerator.GenerateWeapon(1);
                advArmor = itemGenerator.GenerateArmor(1);
                advShield = itemGenerator.GenerateShield(1);
                LootList.Add(advWeapon);
                LootList.Add(advArmor);
                LootList.Add(advShield);
            }
            if (itemValue == 2)
            {
                advWeapon = itemGenerator.GenerateWeapon(2);
                advArmor = itemGenerator.GenerateArmor(2);
                advShield = itemGenerator.GenerateShield(2);
                LootList.Add(advWeapon);
                LootList.Add(advArmor);
                LootList.Add(advShield);
            }
            if (itemValue == 3)
            {
                advWeapon = itemGenerator.GenerateWeapon(3);
                advArmor = itemGenerator.GenerateArmor(3);
                advShield = itemGenerator.GenerateShield(3);
                LootList.Add(advWeapon);
                LootList.Add(advArmor);
                LootList.Add(advShield);
            }
        }






        //-
        //Fight Properties, Variables and Methods
        //-
        private int  advState = 1;
        

        public int AdvState {
            get { return advState; }
            set { advState = AdvState; } 
        }



        public void Attack()
        {
            if (FightSyStem.PlayerTurn == true)
            {
                FightSyStem.AttackEnemy(advEnemy);
            }
            else
            {
                FightSyStem.EnemyAttacksYou(advEnemy);
            }

            updateProgressBar();
            
        }

        public void LootItems()
        {
            Repository.Player.EquipedWeapon = advWeapon;
            Repository.Player.EquipedShield = advShield;
            Repository.Player.EquipedArmor = advArmor;
        }

        public void LootGold()
        {
            Repository.Player.Gold += AdvGold;
        }









        //ProgressBars

        private void updateProgressBar()
        {
            double _EprogressPercent;
            double _PprogressPercent;
            _EprogressPercent = calculateProgPercent(1, Adventure.advEnemy.HealthPoints);
            EnemyProgressBarValue = _EprogressPercent;

            _PprogressPercent = calculateProgPercent(2, Repository.Player.Health);
            PlayerProgressBarValue = _PprogressPercent;

        }

        private double calculateProgPercent(int choise, double hp)
        {
            double calculatedPercent;

            if (choise == 1)
            {
                calculatedPercent = 100 * (hp / EnemyMaxHP);
            }
            else
            {
                calculatedPercent = 100 * (hp / PlayerMaxHP);
            }


            return calculatedPercent;
        }


        double playerProgressBarValue;

        public double PlayerProgressBarValue { 
            get
            { return playerProgressBarValue; }
            set
            { playerProgressBarValue = value; OnPropertyChanged(); } 
        }

        double enemeyProgressBarValue;
        public double EnemyProgressBarValue
        {
            get
            { return enemeyProgressBarValue; }
            set
            { enemeyProgressBarValue = value; OnPropertyChanged(); }
        }
        public double EnemyMaxHP { get; set; }

        public double PlayerMaxHP { get; set; }

        public int AdvGold { get; set; }
    }
}
