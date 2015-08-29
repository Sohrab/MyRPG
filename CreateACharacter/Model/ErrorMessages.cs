using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPropertyChangedBase;

namespace CreateACharacter.Model
{
    public class ErrorMessages : PropertyChangedBase
    {

        private string shopMessage = "";
        private int messageState = 0;

        public int MessageState { get { return messageState; } set { messageState = value; OnPropertyChanged(); } }
        public string ShopMessage { get { return shopMessage; } set { shopMessage = value; OnPropertyChanged(); } }
    }
}
