using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateACharacter.Items;
using MyPropertyChangedBase;


namespace CreateACharacter.Model
{
    public class Repository : PropertyChangedBase
    {
           

        private static Player player = new Player();

        public List<Enemy> Enemies { get; set; }

        public static Player Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }

        }

        public Repository()
        {
            initialize();
            
        }
        private void initialize()
        {

            Enemies = GetEnemies();
            ShopInstance.GenerateItems();
        }





        private List<Enemy> GetEnemies()
        {
            List<Enemy> enemies = new List<Enemy>();
            Enemy FirstEnemy = new Enemy("Paco",200,20,10,6, "Images/Paco.png");
            Enemy SecondEnemy = new Enemy("Monkey", 400, 40, 20, 10, "Images/Monkey.png");
            Enemy ThirdEnemy = new Enemy("Johny", 800, 80, 40, 30, "Images/Johny.png");
            Enemy ForthEnemy = new Enemy("Jimpach", 1600, 160, 80, 50, "Images/Jimmy.png");
            Enemy FifthEnemy = new Enemy("Basse", 3200, 320, 160, 80, "Images/Basse.png");
            enemies.Add(FirstEnemy);
            enemies.Add(SecondEnemy);
            enemies.Add(ThirdEnemy);
            enemies.Add(ForthEnemy);
            enemies.Add(FifthEnemy);
            
            return enemies;
        }








        static ErrorMessages errorMessage = new ErrorMessages();


        public static ErrorMessages ErrorMessage { get { return errorMessage; } set { errorMessage = value; } }





        //-
        //SHOP SECTION
        //-


        public Shop shopInstance = new Shop();

        public Shop ShopInstance { get { return shopInstance; } set { shopInstance = value; } }

        


        //-
        //Adventure Section
        //-


        public static int stage;
        public static Adventure MyAdventure { get; set; }
        
        public void GenerateAdventure()
        {
            setStage();
            if (stage == 0)
            {
                MyAdventure = new Adventure(Enemies[0], 0);                              
            }
            if (stage == 1)
            {
                MyAdventure = new Adventure(Enemies[1], 1); 
            }
            if (stage == 2)
            {
                MyAdventure = new Adventure(Enemies[2], 2); 
            }
            if (stage == 3)
            {
                MyAdventure = new Adventure(Enemies[3], 3); 
            }
            if (stage == 4)
            {
                MyAdventure = new Adventure(Enemies[4], 4);
            }


            //Cheat
            //Repository.Player.Health = 4000;
            
            
            
        }

        private void setStage()
        {
            stage = Player.CheckDefeatedEnemies();
        }







        //-
        //Page info Section
        //-

        private static int pageLocator;
        private string pageName;


        //PageLocator values:
        //1. HomePage
        //2. ShopPage
        //3. AdventurePage
        //4.

        public string PageName { 
            get {
                if (pageLocator == 1)
                {
                    pageName = "HOME";
                }
                if (pageLocator == 2)
                {
                    pageName = "SHOP";
                }
                if (pageLocator == 3)
                {
                    pageName = "ADVENTURE";
                }

            return pageName; 
            } set { pageName = value; } }
        public static int PageLocator { get { return pageLocator; } set { pageLocator = value; } }












        //Options





    }
}
