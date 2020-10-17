using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OrganizadorExcursoesApp.Models;
using OrganizadorExcursoesApp.Services;

namespace OrganizadorExcursoesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExcursaoCreate : ContentPage
    {
        FirebaseService firebaseService = new FirebaseService();
        public ExcursaoCreate()
        {
            InitializeComponent();
        }

        private async void OnSave(object sender, EventArgs args)
        {
            Excursao e = BindingContext as Excursao;
            Console.WriteLine(e);
            await firebaseService.CreateExcursao(e);
            await Navigation.PopAsync();
        }
    }
}