using DAL;
using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OkulApp.BLL
{
    public class OgretmenBL
    {
        public bool OgretmenEkle(Ogretmen ogrt)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@Ad", ogrt.Ad),
                    new SqlParameter("@Soyad", ogrt.Soyad),
                    new SqlParameter("@TC", ogrt.TC)
                };

                var hlp = new Helper();
                return hlp.ExecuteNonQuery("Insert into tblOgretmenler (Ad,Soyad,TC) values (@Ad,@Soyad,@TC)", p) > 0;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //if (baglanti != null && baglanti.State != ConnectionState.Closed)
                //{
                //    //baglanti.Close();
                //    baglanti.Dispose();   //Bellekten SQL objelerini atar
                //    cmd.Dispose();
                //}
            }
        }
    }
}
