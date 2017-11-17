using SistemaDeHotelaria.Domain;
using SistemaDeHotelaria.Utilitarios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeHotelaria.Controller
{
    public class SituacaoQuarto
    {
        public int Quarto { get; set; }
        public int Hospede { get; set; }
        public string NomeHospede { get; set; }
        public int Hospedagem { get; set; }
        public int Reserva { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        
        
    }
}
