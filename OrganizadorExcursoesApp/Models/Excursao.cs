using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizadorExcursoesApp.Models
{
    class Excursao
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public String LocalDestino { get; set; }
        public String Data { get; set; }
        public String LocalSaida { get; set; }
        public String HorarioSaida { get; set; }

    }
}
