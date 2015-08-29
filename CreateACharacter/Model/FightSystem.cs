using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPropertyChangedBase;
using System.Text.RegularExpressions;

namespace CreateACharacter.Model
{
    public class FightSystem : PropertyChangedBase
    {

        Random rnd = new Random();
        Windows.UI.Xaml.Controls.ProgressBar pBar = new Windows.UI.Xaml.Controls.ProgressBar();

        public Windows.UI.Xaml.Controls.ProgressBar ProgressBar { get { return pBar; } set { pBar = value; OnPropertyChanged(); } }



        double enemyHP;

        public double EnemyHP { get { return enemyHP; } set { enemyHP = value; } }

        bool victory;
        bool loose;

        public bool Loose { get { return loose; } set { loose = value; OnPropertyChanged(); } }
        public bool Victory { get { return victory; } set { victory = value; OnPropertyChanged(); } }
        bool playerTurn = true;

        public bool PlayerTurn {
            get { return playerTurn; }
            set { playerTurn = value; OnPropertyChanged(); }
        }

        public string combatLog = "";

        public string CombatLog { get { return combatLog; } 
            set 
        
            { 
                
                combatLog = value;

                combatLog = CheckLines(combatLog, 1);
                OnPropertyChanged(); 

        
            } 
        }




        public static string CheckLines(string str, int linesCount)
        {
            //Check if more than 10 lines
            //If true, remove first line
            string[] lines = str.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string output ="";
            if (lines.Count() >= 10)
            {
                return output = string.Join(Environment.NewLine, lines.Skip(linesCount));
            }
            else
            {
                return output = string.Join(Environment.NewLine, lines);
            }

            
            

            
            
        }









        public void AttackEnemy(Enemy advEnemy)
        {
            CombatLog += "\r\n";
            bool crit = false;
            int damage = Repository.Player.Damage;
            float drProcent;
            float damageReduction;
            int randomizer;
            if (rnd.Next(1, 101) <= 30)
            {
                CombatLog += "You missed your attack.";
            }
            else
            {
                if (rnd.Next(1, 101) <= Repository.Player.CritChance)
                {
                    damage = damage * 2;
                    crit = true;
                }

                drProcent = advEnemy.Armor / 1000f;
                damageReduction = damage * drProcent;
                
                randomizer = rnd.Next(1, advEnemy.RandomiZer);
                if (randomizer > damage)
                {
                    damage += randomizer;
                }
                else
                {
                    if (rnd.Next(1, 2) == 2)
                    {
                        damage += randomizer;
                    }
                    else
                    {
                        damage -= randomizer;
                    }
                }

                damage = (int)(damage - damageReduction);
                advEnemy.HealthPoints -= damage;

                CombatLog += "You hit " + advEnemy.EnemyName;
                if (randomizer < advEnemy.RandomiZer / 2)
                {
                    CombatLog += " hard for " + damage;
                }
                else
                {
                    CombatLog += " poorly for " + damage;
                    
                }

                if (crit == true)
                {
                    CombatLog += " critical";
                }

                CombatLog += " damage.";
            }

            PlayerTurn = false;

            CheckVictoryConditions(advEnemy);
            //SetEnemyHp(advEnemy);
        }

        private void SetEnemyHp(Enemy _enemy)
        {
            EnemyHP = _enemy.HealthPoints;
        }




        private void CheckVictoryConditions(Enemy _advEnemy)
        {
            //Check if Player won
            if (_advEnemy.HealthPoints <= 0)
            {
                Victory = true;
                Loose = false;
                Repository.Player.DefeatedEnemies.Add(_advEnemy);
            }

            //Check if Enemy won
            if (Repository.Player.Health <= 0)
            {
                Victory = false;
                Loose = true;
            }
            

        }



        public void EnemyAttacksYou(Enemy advEnemy)
        {
            CombatLog += "\r\n";
            bool crit = false;
            int damage = advEnemy.Damage;
            float drProcent;
            float damageReduction;
            int randomizer;

            //See if miss
            if (rnd.Next(1, 101) <= 30)
            {
                CombatLog += advEnemy.EnemyName + " missed his attack.";
            }
            else
            {
                if (rnd.Next(1, 101) <= 10)
                {
                    damage = damage * 2;
                    crit = true;
                }


                //Start calculating damage
                drProcent = Repository.Player.Armor / 1000f;
                damageReduction = damage * drProcent;

                randomizer = rnd.Next(1, advEnemy.RandomiZer);
                if (randomizer > damage)
                {
                    damage += randomizer;
                }
                else
                {
                    if (rnd.Next(1, 2) == 2)
                    {
                        damage += randomizer;
                    }
                    else
                    {
                        damage -= randomizer;
                    }
                }

                damage = (int)(damage - damageReduction);
                Repository.Player.Health -= damage;


                //See if Parry, Dodge or Block
                if (rnd.Next(1, 101) <= Repository.Player.ParryChance)
                {
                    CombatLog += "You parried " + advEnemy.EnemyName + "'s attack!";
                }
                else if (rnd.Next(1, 101) <= Repository.Player.BlockChance)
                {
                    CombatLog += "You blocked " + advEnemy.EnemyName + "'s attack!";
                }
                else if (rnd.Next(1, 101) <= Repository.Player.DodgeChance)
                {
                    CombatLog += "You dodged " + advEnemy.EnemyName + "'s attack!";
                }

                else
                {
                    CombatLog += advEnemy.EnemyName + " hits you";
                    if (randomizer < advEnemy.RandomiZer / 2)
                    {
                        CombatLog += " hard for " + damage;
                    }
                    else
                    {
                        CombatLog += " poorly for " + damage;

                    }

                    if (crit == true)
                    {
                        CombatLog += " critical";
                    }

                    CombatLog += " damage.";
                }
            }

            PlayerTurn = true;

            CheckVictoryConditions(advEnemy);


        }






    }
}
