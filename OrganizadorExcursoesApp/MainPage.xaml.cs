using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using OrganizadorExcursoesApp.Models;
using OrganizadorExcursoesApp.Services;

namespace OrganizadorExcursoesApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        FirebaseService firebaseService = new FirebaseService();
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListaExcursoes.ItemsSource = await firebaseService.GetExcursoes();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args != null)
            {
                Navigation.PushAsync(new ExcursaoDetailEdit()
                {
                    BindingContext = args.SelectedItem as Excursao
                });
            }
        }

        private void OnAdicionarClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ExcursaoCreate()
            {
                BindingContext = new Excursao()
            });
        }
    }
}
