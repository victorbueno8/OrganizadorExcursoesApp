using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using OrganizadorExcursoesApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorExcursoesApp.Services
{
    class FirebaseService
    {
        FirebaseClient firebase = new FirebaseClient("https://organizadorexcursoesapp.firebaseio.com/");

        public async Task<List<Excursao>> GetExcursoes()
        {
            return (await firebase.Child("Excursoes").OnceAsync<Excursao>())
                .Select(item => new Excursao
                {
                    Id = item.Object.Id,
                    Nome = item.Object.Nome,
                    Descricao = item.Object.Descricao,
                    LocalDestino = item.Object.LocalDestino,
                    Data = item.Object.Data,
                    LocalSaida = item.Object.LocalSaida,
                    HorarioSaida = item.Object.HorarioSaida
                }).ToList();
        }

        public async Task CreateExcursao(Excursao e)
        {
            await firebase.Child("Excursoes").PostAsync(e);
        }

        public async Task<Excursao> GetExcursao(int id)
        {
            var allExcursoes = await GetExcursoes();

            return allExcursoes.Where(a => a.Id == id).FirstOrDefault();
        }

        public async Task UpdateExcursao(Excursao e)
        {
            var toUpdateExcursao = (await firebase.Child("Excursoes").OnceAsync<Excursao>()).Where(a => a.Object.Id == e.Id).FirstOrDefault();

            await firebase.Child("Excursoes").Child(toUpdateExcursao.Key).PutAsync(e);
        }

        public async Task DeleteExcursao(int id)
        {
            var toDeleteExcursao = (await firebase.Child("Excursoes").OnceAsync<Excursao>()).Where(a => a.Object.Id == id).FirstOrDefault();

            await firebase.Child("Excursoes").Child(toDeleteExcursao.Key).DeleteAsync();
        }
    }
}
