using SistemaDeHotelaria.Utilitarios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeHotelaria.Controller
{
    class Reservas
    {
        public int Codigo { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int CodQuarto { get; set; }
        public int CodHospede { get; set; }
        public int CodFuncionario { get; set; }

        public static List<Reservas> listaReservas = new List<Reservas>();

        public static List<Reservas> carregarListaReservas()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());   
                conn.Open();
                string query = "SELECT * FROM reserva";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dtr = cmd.ExecuteReader();

                listaReservas.Clear();

                while (dtr.Read())
                {
                    Reservas r = new Reservas();
                    r.Codigo = int.Parse(dtr["reservaCodigo"].ToString());
                    r.CodHospede = int.Parse(dtr["hospCodigo"].ToString());
                    r.CodQuarto = int.Parse(dtr["quartoCodigo"].ToString());
                    r.Checkin = DateTime.Parse(dtr["reservaCheckin"].ToString());
                    r.Checkout = DateTime.Parse(dtr["reservaCheckout"].ToString());
                    r.CodFuncionario = int.Parse(dtr["funcCodigo"].ToString());
                    listaReservas.Add(r);

                }
                conn.Close();
                return listaReservas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void inserirReserva(Reservas r)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                string query = "insert into reserva (hospCodigo,quartoCodigo,reservaCheckin,reservaCheckout,funcCodigo) " +
                    " values ( @hospCodigo,@quartoCodigo,@checkin,@checkout,@funcCodigo);";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@hospCodigo", r.CodHospede);
                cmd.Parameters.AddWithValue("@quartoCodigo", r.CodQuarto);
                cmd.Parameters.AddWithValue("@checkin", r.Checkin);
                cmd.Parameters.AddWithValue("@checkout", r.Checkout);
                cmd.Parameters.AddWithValue("@funcCodigo", r.CodFuncionario);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void alterarReserva(Reservas r)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "update reserva set hospCodigo = @hospCodigo,quartoCodigo = @quartoCodigo,"+
                    "reservaCheckin = @checkin,"+
                    " reservaCheckout = @checkout,funcCodigo = @funcCodigo "+
                    " where reservaCodigo = @cod";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@hospCodigo", r.CodHospede);
                cmd.Parameters.AddWithValue("@quartoCodigo", r.CodQuarto);
                cmd.Parameters.AddWithValue("@checkin", r.Checkin);
                cmd.Parameters.AddWithValue("@checkout", r.Checkout);
                cmd.Parameters.AddWithValue("@funcCodigo", r.CodFuncionario);
                cmd.Parameters.AddWithValue("@cod", r.Codigo.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void excluirReserva(int codigo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                conn.Open();

                String query = "delete from reserva where reservaCodigo = @cod";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cod", codigo);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }


    }
}
