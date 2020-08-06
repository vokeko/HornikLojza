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
        //Tenhle formulář se spustí otevřením aplikace. Z něj se přistupuje k formuláři Typhrydialog. Sám o sobě nepředává žádná data mezi formuláři, jen jeden vytváří a zobrazuje.
        private Typhrydialog dialog = new Typhrydialog();

        public Menuform()
        {
            InitializeComponent();
            toolTip2.SetToolTip(novaHra_tlacitko, "Nová hra");
            toolTip2.SetToolTip(nastaveni_tlacitko, "Změnění nastavení kláves");
            toolTip2.SetToolTip(tutorial_tlacitko, "Zobrazení krátkého tutoriálu, který vysvětluje jak hru hrát");
            toolTip2.SetToolTip(Ukoncit_tlacitko, "Ukončit hru");
        }

        private void Ukoncit_tlacitko_Click(object sender, EventArgs e)
        {
            //Spustí se při stisknutí tlačítka Ukoncit_tlacitko. Zavře aplikaci, pokud uživatel vybere ano.
            DialogResult vyber = MessageBox.Show("Jste si jisti?", "Opravdu?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (vyber == DialogResult.OK)
            {
                Application.Exit();
            }

        }
        private void tutorial_tlacitko_Click(object sender, EventArgs e)
        {
            //Popis ovládání hry.
            MessageBox.Show("Hra je jednoduchá. Hýbáte se šipkami - můžete sbírat drahokamy a těžit co vás napadne. Jakmile najdete všechny předměty, běžte do východu! Ale dejte pozor na padající kameny! Jestli vás jeden zavalí, tak je po všem! Kameny taky můžete odsunout na volné políčko držením tlačítko control a šipkou do strany.", "Tutoriál", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void novaHra_tlacitko_Click(object sender, EventArgs e)
        {
            dialog.Show();
            //Nasměruje hráče na nový form (Typhrydialog) - ten umožní vybrat mezi standartní hrou a vlastní hrou. Vlastní hra dovolí definovat jak rychle padají kameny, kolik předmětů bude v úrovni, jak velká bude úroveň a kolik kamenů tam bude.
        }

        private void nastaveni_tlacitko_Click(object sender, EventArgs e)
        {
            novaHra_tlacitko.Hide();
            nastaveni_tlacitko.Hide();
            tutorial_tlacitko.Hide();
            zpatkytlacitko.Show();
            //Předělá formulář na nastavení 
        }

        private void zpatkytlacitko_Click(object sender, EventArgs e)
        {
            novaHra_tlacitko.Show();
            nastaveni_tlacitko.Show();
            tutorial_tlacitko.Show();
            zpatkytlacitko.Hide();
        }
        /* co potřebuju udělat:
         * 1) Ošetřit kód, aby kameny nemohly na startu zablokovat Lojzu
         * 2) Udělat nastavení, kde půjde nastavit vlastní klávesy
         * 3) Udělat nastavení pro vlastní hru
         * 4) Úspěšně poslat hodnoty nastavení a vlastní hry a použít je ve formu1
         * 5)Udělat to tak, aby se menuform otevřel po dokončení hry
         * 6)Použití zdí (10%?)
         * 7)Hudba?
         * 8)Napřátelé?
         * 9)Bonusy?
         * 10)Na čas?
         */
    }
}
