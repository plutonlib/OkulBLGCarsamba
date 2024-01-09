using OkulApp.MODEL;
using OkulApp.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulApp
{
    public partial class frmOgrKayit : Form
    {
        public int Ogrenciid { get; set; }
        public frmOgrKayit()
        {
            InitializeComponent();
        }     

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var ogr = new Ogrenci();
                ogr.Ad = textBox1.Text.Trim();
                ogr.Soyad = textBox2.Text.Trim();
                ogr.Numara = textBox3.Text.Trim();
                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciEkle(ogr);
                MessageBox.Show(sonuc ? "Ekleme Başarılı" : "Ekleme Başarısız!");
                Temizlik();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu Numara Zaten Kayıtlı!!");
                        break;
                    default:
                        MessageBox.Show($"Veritabanı Hatası!!");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bilinmayen Hata Oluştu!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmOgrBul(this);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciSil(Ogrenciid) ? "Silme Başarılı" : "Silme Başarısız!");
                Temizlik();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var ogr = new Ogrenci();
                ogr.Ad = textBox1.Text.Trim();
                ogr.Soyad = textBox2.Text.Trim();
                ogr.Numara = textBox3.Text.Trim();
                ogr.Ogrenciid = Ogrenciid;

                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciGuncelle(ogr) ? "Guncelleme Başarılı" : "Guncelleme Başarısız!");
                Temizlik();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Temizlik()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            button3.Enabled = false;
            button4.Enabled = false;
        }
    }



    //INTERFACE DERSI
    interface ITransfer
    {
        int EFT(string aliciiban, string gondereniban, double tutar);
        int Havale(string aliciiban, string gondereniban, double tutar, DateTime tarih);
    }
    class TransferIslemleri : ITransfer
    {
        public int EFT(string aliciiban, string gondereniban, double tutar)
        {
            throw new NotImplementedException();
        }

        public int Havale(string aliciiban, string gondereniban, double tutar, DateTime tarih)
        {
            throw new NotImplementedException();
        }
    }

}
