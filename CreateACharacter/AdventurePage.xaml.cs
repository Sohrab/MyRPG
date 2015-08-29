using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CreateACharacter.Items;
using CreateACharacter.Model;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CreateACharacter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdventurePage : Page
    {

        //double progressPercent;
        double enemyMaxHPValue;

        double playerMaxHPValue;

        public double PlayerMaxHP { get{ return playerMaxHPValue; } set { playerMaxHPValue = value; }  }

        double localPlayerHP;
        double localEnemyHP;

        public double LocalPlayerHP { get{ return localPlayerHP; } set { localPlayerHP = value; } }
        public double LocalEnemyHP { get { return localEnemyHP; } set { localEnemyHP = value; } }
        public double EnemyMaxHP { get { return enemyMaxHPValue; } set { enemyMaxHPValue = value; } }
        public AdventurePage()
        {
            this.InitializeComponent();        

           
        }

        private void setProgressMaximum()
        {
            EnemyMaxHP = Convert.ToDouble(EnemyHp.Text);
            EnemyProgressBar.Value = 100;

        }


        private void progressBar_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            setProgressMaximum();
        }
    }
}
