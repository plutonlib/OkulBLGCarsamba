using OkulApp.BLL;
using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulApp
{
    public partial class frmOgrBul : Form
    {
        frmOgrKayit frm;
        public frmOgrBul(frmOgrKayit frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OgrenciBL obl = new OgrenciBL();
                Ogrenci ogr = obl.OgrenciBul(textBox1.Text.Trim());
                if (ogr != null)
                {
                    frm.textBox1.Text = ogr.Ad;
                    frm.textBox2.Text = ogr.Soyad;
                    frm.textBox3.Text = ogr.Numara;
                    frm.Ogrenciid = ogr.Ogrenciid;

                    //Sil ve Guncelle butonları aktifligi ve bul formunun kapanması
                    frm.button3.Enabled = true;
                    frm.button4.Enabled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Öğrenci bulunamadı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
    }
}
