﻿using System;
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
    public partial class GirisBasarili : Form
    {
        WinFormOturumAcmaIslemleriEntitiesConnectionDb db=new WinFormOturumAcmaIslemleriEntitiesConnectionDb();
        public GirisBasarili()
        {
            InitializeComponent();
        }

        private void GirisBasarili_Load(object sender, EventArgs e)
        {
            label1.Text = $@"Hoşgeldiniz Sayın {db.PersonelGirisTablosu.FirstOrDefault(x => x.Id == Form1.Id).FirstName} {db.PersonelGirisTablosu.FirstOrDefault(x => x.Id == Form1.Id).LastName}";

        }
    }
}
