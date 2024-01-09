using OkulApp.BLL;
using OkulApp.MODEL;
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
    public partial class frmOgrtKayit : Form
    {
        public frmOgrtKayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var ogrt = new Ogretmen();
                ogrt.Ad = textBox1.Text.Trim();
                ogrt.Soyad = textBox2.Text.Trim();
                ogrt.TC = textBox3.Text.Trim();
                var obl = new OgretmenBL();
                bool sonuc = obl.OgretmenEkle(ogrt);
                MessageBox.Show(sonuc ? "Ekleme Başarılı" : "Ekleme Başarısız!");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu TC Zaten Kayıtlı!!");
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
