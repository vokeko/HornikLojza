﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hornik_Lojza
{
    public partial class Typhrydialog : Form
    {
        private HerniOkno hra = new HerniOkno();
        public Typhrydialog()
        {
            InitializeComponent();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void vratitse_tlacitko_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void standartihra_tlacitko_Click(object sender, EventArgs e)
        {
            this.Hide();
            hra.Show();
        }

        private void Typhrydialog_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(standartihra_tlacitko, "Zahrajte si hru s výchozím nastavením");
            toolTip1.SetToolTip(vlastnihra_tlacitko, "Zahrajte si hru podle vlastních hodnot a pravidel");
            toolTip1.SetToolTip(vratitse_tlacitko, "Navrácení do hlavního menu");
        }

        private void vlastnihra_tlacitko_Click(object sender, EventArgs e)
        {
            vlastnihra_tlacitko.Visible = false;
            standartihra_tlacitko.Visible = false;
        }
    }
}
