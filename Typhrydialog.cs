using System;
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
        public Typhrydialog()
        {
            InitializeComponent();
        }

        private void vratitse_tlacitko_Click(object sender, EventArgs e)
        {
            vyberhry();
            this.Hide();
            //Skryje okno
        }

        private void standartihra_tlacitko_Click(object sender, EventArgs e)
        {
            HerniOkno hra = new HerniOkno();
            hra.Show();
            this.Hide();
            //začne novou hru, se standartními parametry
        }

        private void Typhrydialog_Load(object sender, EventArgs e)
        {
            vyberhry();

            rychlostpadani_textbox.Text = Convert.ToString(tick_trackbar.Value);
            kamenu_textbox.Text = Convert.ToString(Kamenu_trackbar.Value);
            drahokamu_textbox.Text = Convert.ToString(drahokamu_trackbar.Value);

            toolTip1.SetToolTip(standartihra_tlacitko, "Zahrajte si hru s výchozím nastavením");
            toolTip1.SetToolTip(vlastnihra_tlacitko, "Zahrajte si hru podle vlastních hodnot a pravidel");
            toolTip1.SetToolTip(vratitse_tlacitko, "Navrácení do hlavního menu");

            toolTip1.SetToolTip(tick_trackbar, "Jak často hra kontroluje, kdy mají padat kameny. Čím je číslo vyšší, tím je snažší se jim vyhnout.");
            toolTip1.SetToolTip(Kamenu_trackbar, "Kolik překážek se vygeneruje na herní ploše");
            toolTip1.SetToolTip(drahokamu_trackbar, "Kolik drahokamů k sebrání se vygeneruje na herní ploše");
            toolTip1.SetToolTip(potvrd_tlacitko, "Potvrdit změny a začít novou hru?");
            //Ukáže se, když uživatel přejede myší po některém z tlačítek
        }

        private void vlastnihra_tlacitko_Click(object sender, EventArgs e)
        {
            vlastnihra();
        }

        private void potvrd_tlacitko_Click(object sender, EventArgs e)
        {
            int padani = tick_trackbar.Value;
            HerniOkno hra = new HerniOkno(tick_trackbar.Value, Convert.ToUInt16(Kamenu_trackbar.Value), Convert.ToUInt16(drahokamu_trackbar.Value));
            hra.Show();
            this.Hide();
        }
        private void vyberhry()
        {
            vlastnihra_tlacitko.Show();
            standartihra_tlacitko.Show();
            potvrd_tlacitko.Hide();
            tick_trackbar.Hide();
            Kamenu_trackbar.Hide();

            kamenu_textbox.Hide();
            rychlostpadani_textbox.Hide();
            rychlost_label.Hide();
            kamenu_label.Hide();

            drahokamu_label.Hide();
            drahokamu_textbox.Hide();
            drahokamu_trackbar.Hide();
        }
        private void vlastnihra()
        {
            vlastnihra_tlacitko.Hide();
            standartihra_tlacitko.Hide();
            potvrd_tlacitko.Show();
            tick_trackbar.Show();
            Kamenu_trackbar.Show();

            kamenu_textbox.Show();
            rychlostpadani_textbox.Show();
            rychlost_label.Show();
            kamenu_label.Show();

            drahokamu_label.Show();
            drahokamu_textbox.Show();
            drahokamu_trackbar.Show();
            //Skryje tlačítka a ukáže nové ovládací prvky, sloužící pro výběr parametrů vlastní hry
            //(pozn. - v budoucnu)
        }

        private void tick_trackbar_Scroll(object sender, EventArgs e)
        {
            rychlostpadani_textbox.Text = Convert.ToString(tick_trackbar.Value+" ms");
        }

        private void Kamenu_trackbar_Scroll(object sender, EventArgs e)
        {
            kamenu_textbox.Text = Convert.ToString(Kamenu_trackbar.Value);
        }

        private void drahokamu_trackbar_Scroll(object sender, EventArgs e)
        {
            drahokamu_textbox.Text = Convert.ToString(drahokamu_trackbar.Value);
        }
    }
}
