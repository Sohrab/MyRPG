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
using CreateACharacter.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CreateACharacter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShopPage : Page
    {
        public ShopPage()
        {
            this.InitializeComponent();



        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Repository.Player.Gold >= 10)
            {
                Repository.Player.Health = Repository.Player.Maxhealth;
                Repository.Player.Gold -= 10;
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
