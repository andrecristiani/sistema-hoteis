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
    class Hospedagens
    {
        public int Codigo { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int CodigoFunc { get; set; }
        public int CodigoReserva { get; set; }
        public int CodigoHosp { get; set; }
        public int CodigoQuarto { get; set; }
        public double Valor { get; set; }

        public static List<Hospedagens> listaHospedagens = new List<Hospedagens>();

        public static void carregarHospedagens()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString());    
                conn.Open();
                string query = "SELECT * FROM hospedagem";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dtr = cmd.ExecuteReader();

                listaHospedagens.Clear();

                while (dtr.Read())
                {
                   Hospedagens h = new Hospedagens();
                    h.Codigo = int.Parse(dtr["hospedagemCodigo"].ToString());
                    h.CodigoHosp = int.Parse(dtr["hospCodigo"].ToString());
                    h.CodigoQuarto = int.Parse(dtr["quartoCodigo"].ToString());
                    h.CodigoFunc = int.Parse(dtr["funcCodigo"].ToString());
                    h.CodigoReserva = int.Parse(dtr["reservaCodigo"].ToString());
                    h.Checkin = DateTime.Parse(dtr["hospCheckin"].ToString());
                    h.Checkout = DateTime.Parse(dtr["hospCheckout"].ToString());
                    h.Valor = float.Parse(dtr["valorTotal"].ToString());
                    listaHospedagens.Add(h);

                }
                conn.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void inserirHospedagem(Hospedagens h)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString());      
                conn.Open();
                string query;
                if (h.CodigoReserva > 0)
                {

                     query= "insert into hospedagem (hospCodigo,quartoCodigo,funcCodigo,reservaCodigo," +
                        "hospCheckin,hospCheckout, valorTotal) " +
                        " values ( @hospCodigo,@quartoCodigo,@funcCodigo,@reservaCodigo,@checkin,@checkout,@valor);";
                }
                else
                {
                    query = "insert into hospedagem (hospCodigo,quartoCodigo,funcCodigo," +
                        "hospCheckin,hospCheckout, valorTotal) " +
                        " values ( @hospCodigo,@quartoCodigo,@funcCodigo,@checkin,@checkout,@valor);";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@hospCodigo", h.CodigoHosp);
                cmd.Parameters.AddWithValue("@quartoCodigo", h.CodigoQuarto);
                cmd.Parameters.AddWithValue("@funcCodigo", h.CodigoFunc);
                if(h.CodigoReserva > 0)
                    cmd.Parameters.AddWithValue("@reservaCodigo", h.CodigoReserva);
                cmd.Parameters.AddWithValue("@checkin", h.Checkin);
                cmd.Parameters.AddWithValue("@checkout", h.Checkout);
                cmd.Parameters.AddWithValue("@valor", h.Valor);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void alterarHospedagem(Hospedagens h)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString()); 
                conn.Open();

                String query = "update hospedagem set hospCodigo = @hospCodigo,quartoCodigo = @quartoCodigo," +
                    "funcCodigo = @funcCodigo, reservaCodigo = @reservaCodigo, hospCheckin = @checkin," +
                    " hospCheckout = @checkout, funcCodigo = @funcCodigo, valorTotal = @valor " +
                    " where reservaCodigo = @cod";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@hospCodigo", h.CodigoHosp);
                cmd.Parameters.AddWithValue("@quartoCodigo", h.CodigoQuarto);
                cmd.Parameters.AddWithValue("@funcCodigo", h.CodigoFunc);
                cmd.Parameters.AddWithValue("@reservaCodigo", h.CodigoReserva);
                cmd.Parameters.AddWithValue("@checkin", h.Checkin);
                cmd.Parameters.AddWithValue("@checkout", h.Checkout);
                cmd.Parameters.AddWithValue("@funcCodigo", h.CodigoFunc);
                cmd.Parameters.AddWithValue("@valor", h.Valor);
                cmd.Parameters.AddWithValue("@cod", h.Codigo.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void excluirHospedagem(int codigo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString());  
                conn.Open();

                String query = "delete from hospedagem where hospedagemCodigo = @cod";

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
