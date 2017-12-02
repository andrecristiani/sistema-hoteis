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
    class Cidade
    {
        public int Cod { get; set; }
        public string Cidades { get; set; }
        public int CodEstado { get; set; }

       public static List<cidade> carregarListaCidadeEntities()
        {
            try
            {
                List<cidade> listaCidade = new List<cidade>();

                using (Entities ef = new Entities())
                {
                    listaCidade = ef.cidade.ToList();
                }

                return listaCidade;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static List<Cidade> carregarListaCidade()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[StringBD.nomeString].ToString());
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDB"].ToString());
                con.Open();
                string query = "select *from cidade";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dtr = cmd.ExecuteReader();
                List<Cidade> listaCidade = new List<Cidade>();

                while (dtr.Read())
                {
                    Cidade cid = new Cidade();
                    cid.Cod = int.Parse(dtr["cidadeCodigo"].ToString());
                    cid.Cidades = dtr["cidadeNome"].ToString();
                    cid.CodEstado = int.Parse(dtr["estadoCodigo"].ToString());
                    listaCidade.Add(cid);
                }
                con.Close();
                return listaCidade;
              
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }


}
