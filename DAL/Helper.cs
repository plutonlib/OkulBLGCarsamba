using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL  //Data Access Layer
{
    public class Helper 
    {
        SqlConnection baglanti;
        SqlCommand cmd;

        //SQL Baglanti stringini OkulApp projesindeki App.config dosyasi icine attik. Oradan getiriyoruz.
        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;

        private static Helper instance;
        public static Helper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Helper();
                }
                return instance;
            }
        }

        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)  //Insert,Update,Delete icin
        {
            try
            {
                
                using (baglanti = new SqlConnection(cstr))
                {
                    using (cmd = new SqlCommand(cmdtext, baglanti))
                    {
                        if (p != null)
                        {
                            cmd.Parameters.AddRange(p);
                        }
                        baglanti.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    
                }
                
                //DISPOSE islemi SQL OBJELERINI BELLEKTEN ATAR (normalde garbage collector isimli sistem oto yapar. ancak sql gibi islemleri yapmaz)
                //using kullandigimizda using in disina cikildiginda otomatik dispose eder bu sayede dispose kodu yazmamiza gerek kalmaz (dogal olarak baglantiyi da oto kapatir)
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)   //Select icin
        {
            try
            {
                baglanti = new SqlConnection(cstr);
                cmd = new SqlCommand(cmdtext, baglanti);
                if (p != null)
                {
                    cmd.Parameters.AddRange(p);
                }
                baglanti.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BaglantiKapat()
        {
            cmd.Dispose();
            baglanti.Dispose();
        }
    }
}

// n KATMANLI MIMARI (3 katmanli proje)
// Presentation Layer (UI), Business Logic Layer (BLL), Data Access Layer (DAL)
//     frmOgrKayit                  OgrenciBL                   Helper