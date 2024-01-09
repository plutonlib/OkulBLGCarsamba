using System;
using System.Data.SqlClient;
using DAL;
using OkulApp.MODEL;

namespace OkulApp.BLL //Business Logic Layer
{
    public class OgrenciBL
    {
        Helper hlp = Helper.Instance;

        public bool OgrenciEkle(Ogrenci ogr)
        {
            try
            {
                //cmd.Parameters.AddWithValue("@Ad", ogr.Ad);
                SqlParameter[] p =
                {
                    new SqlParameter("@Ad", ogr.Ad),
                    new SqlParameter("@Soyad", ogr.Soyad),
                    new SqlParameter("@Numara", ogr.Numara)
                };

                //var hlp = new Helper();
                return hlp.ExecuteNonQuery("Insert into tblOgrenci (Ad,Soyad,Numara) values (@Ad,@Soyad,@Numara)", p) > 0;
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
                //    baglanti.Dispose();   //Bellekten SQL Objelerini atar
                //    cmd.Dispose();
                //}
            }
        }

        public Ogrenci OgrenciBul(string numara)
        {
            try
            {               
                //var hlp = new Helper();
                SqlParameter[] p = { new SqlParameter("@Numara", numara) };
                var dr = hlp.ExecuteReader("Select OgrenciId,Ad,Soyad,Numara from tblOgrenci where Numara=@Numara", p);
                Ogrenci ogr = null;               
                if (dr.Read())
                {
                    ogr = new Ogrenci();
                    ogr.Ad = dr["Ad"].ToString();
                    ogr.Soyad = dr["Soyad"].ToString();
                    ogr.Numara = dr["Numara"].ToString();
                    ogr.Ogrenciid = Convert.ToInt32(dr["OgrenciId"]);
                    //MessageBox.Show(ogr.Ad);
                }
                dr.Close();
                return ogr;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                hlp.BaglantiKapat();
            }
        }

        public bool OgrenciSil(int id)
        {
            try
            {
                //var hlp = new Helper();
                SqlParameter[] p = { new SqlParameter("@Id", id) };
                return hlp.ExecuteNonQuery("Delete from tblOgrenci where OgrenciId=@Id", p) > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool OgrenciGuncelle(Ogrenci ogr)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@Ad", ogr.Ad),
                    new SqlParameter("@Soyad", ogr.Soyad),
                    new SqlParameter("@Numara", ogr.Numara),
                    new SqlParameter("@OgrenciId", ogr.Ogrenciid)
                };
                //var hlp = new Helper();
                return hlp.ExecuteNonQuery("Update tblOgrenci set Ad=@Ad, Soyad=@Soyad, Numara=@Numara where OgrenciId=@OgrenciId", p) > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
