using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace InBar.ViewModels
{
    public class LoginViewModel : BaseViewModel 
    {

        public LoginViewModel()
        {
            Title = "Login";
        }

        public ICommand NextCommand { get; }
        public Entry password { get; }
        public Entry login { get; }

    }
}