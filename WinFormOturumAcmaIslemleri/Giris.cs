using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormOturumAcmaIslemleri.Models;


namespace WinFormOturumAcmaIslemleri
{
    public partial class Form1 : Form
    {
        WinFormOturumAcmaIslemleriEntitiesConnectionDb db = new WinFormOturumAcmaIslemleriEntitiesConnectionDb();
        public Form1()
        {
            InitializeComponent();
        }

        
        public static int Id;

        private void button1_Click_1(object sender, EventArgs e)
        {
            var Durum = db.PersonelGirisTablosu.FirstOrDefault(x => x.MailAdress == txtMailAdresKontrol.Text && x.Password == txtSifreKontrol.Text);
            if (Durum != null)
            {
                Id = Durum.Id;
                GirisBasarili gb = new GirisBasarili();
                gb.ShowDialog();
                
                
                AracKiralamaOrnek.Form1 form1 = new AracKiralamaOrnek.Form1();
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Girilen bilgiler hatalıdır", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SifreTazele sifreTazele = new SifreTazele();
            sifreTazele.ShowDialog();
        }
    }
}
