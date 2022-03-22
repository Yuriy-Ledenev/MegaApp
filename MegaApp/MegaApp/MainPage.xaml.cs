using System;
using Android.Widget;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MegaApp.Models;
using MegaApp.Utils;
using MegaApp.Pages;

namespace MegaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(EntryLogin.Text.Trim()) && !string.IsNullOrWhiteSpace(EntryPassword.Text.Trim()))
            {
                AutorizationScreen.IsEnabled = false;
                LoadingScreen.IsVisible = true;
                try
                {
                    var authUser = await RestService.PostAsync<User>("User/Autorization", new User(EntryLogin.Text, EntryPassword.Text));
                    App.LoginUser = authUser;
                    await Navigation.PushAsync(new MyProfilePage(authUser));
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    Message.ShowShort("НЕВЕРНО! Это не наши данные");
                }
                catch(Java.Net.SocketException)
                {
                    Message.ShowShort("Интернета нема");
                }
                catch
                {
                    Message.ShowShort("Ошибка слишком ошибочная, чтобы что-то тебе говорить");
                }
                AutorizationScreen.IsEnabled = true;
                LoadingScreen.IsVisible = false;
            }
            else
            {
                Message.ShowShort("Поля будут плакать, если их не заполнить");
            }
        }
    }
}
