﻿using System;
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
    public partial class ExcursaoDetailEdit : ContentPage
    {
        FirebaseService firebaseService = new FirebaseService();
        public ExcursaoDetailEdit()
        {
            InitializeComponent();
        }

        private async void OnSave(object sender, EventArgs args)
        {
            Excursao e = BindingContext as Excursao;
            await firebaseService.UpdateExcursao(e);
            await Navigation.PopAsync();
        }

        private async void OnDelete(object sender, EventArgs args)
        {
            Excursao e = BindingContext as Excursao;
            await firebaseService.DeleteExcursao(e);
            await Navigation.PopAsync();
        }
    }
}