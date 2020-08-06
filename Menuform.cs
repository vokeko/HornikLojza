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
    public partial class Menuform : Form
    {
        private Typhrydialog dialog = new Typhrydialog();

        public Menuform()
        {
            InitializeComponent();
        }

        private void Ukoncit_tlacitko_Click(object sender, EventArgs e)
        {
            DialogResult vyber = MessageBox.Show("Jste si jisti?", "Opravdu?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (vyber == DialogResult.OK)
            {
                Application.Exit();
            }

        }
        private void tutorial_tlacitko_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hra je jednoduchá. Hýbáte se šipkami - můžete sbírat drahokamy a těžit co vás napadne. Jakmile najdete všechny předměty, běžte do východu! Ale dejte pozor na padající kameny! Jestli vás jeden zavalí, tak je po všem! Kameny taky můžete odsunout na volné políčko držením tlačítko control a šipkou do strany.", "Tutoriál", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void Menuform_Load(object sender, EventArgs e)
        {

        }

        private void novaHra_tlacitko_Click(object sender, EventArgs e)
        {
            dialog.Show();
            //Nasměruje hráče na nový form - ten umožní vybrat mezi standartní hrou a vlastní hrou. Vlastní hra dovolí definovat jak rychle padají kameny, kolik předmětů bude v úrovni, jak velká bude úroveň a kolik kamenů tam bude.
            //Vlastní i standartní hra 
        }

        private void nastaveni_tlacitko_Click(object sender, EventArgs e)
        {
            //nasměruje hráče na form s nastavením. Bude možné přenastavit tlačítko pro pohyb a vykonávání akcí
        }
    }
}
