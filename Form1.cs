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
    enum Smer
    {
        Doprava, Doleva, Nahoru, Dolu
    }
    public partial class HerniOkno : Form
    {
        Image G_Hrac_Vpravo = Properties.Resources.panacek_pravo;
        Image G_Hrac_Vlevo = Properties.Resources.panacek_vlevo;
        Image G_Hrac_Dolu = Properties.Resources.panacek_dolu;
        Image G_Hrac_Nahoru = Properties.Resources.panacek_nahoru;

        Image G_Nevykopano = Properties.Resources.Nevykopana_zeme;
        Image G_Vykopano = Properties.Resources.Vykopana_zeme;
        Image G_Prekazka = Properties.Resources.Kamen;
        Image G_Vychod = Properties.Resources.Vychod;
        Image G_Drahokam = Properties.Resources.Drahokam;
        Image G_Smaragd = Properties.Resources.Smaragd;
        //všechny obrázky přebíráme z properties.resources. 

        const int polickoRozmer = 40;
        //Všechny políčka mají rozměry 40x40
        const int MAPA_SIRKA = 20;
        const int MAPA_VYSKA = 14;
        //Mapa má šířku 20 na 14 bloků. Ta se nemění.
        int PocetPredmetu = 0;
        //Počítá, kolik zbývá předmětů
        PostavaHrace Hrac;
        //Třída Postavahrace, mezitím bez nového zástupce
        enum StavyPolicek
        {
            Nevykopano,Vykopano,Prekazka,Drahokam,Smaragd,Vychod
            //Enum rozlišuje, co políčka obsahují
        }
        StavyPolicek[,] Mapa = new StavyPolicek[MAPA_SIRKA, MAPA_VYSKA];
        // Mapa uchovává hodnoty pro jednotlivé pole v úrovni
        Timer casovac = new Timer();

        public HerniOkno()
        {
            InitializeComponent();
            VygenerujMapu();
            Hrac = new PostavaHrace();
            //konstruktor, který se spustí zavolá funkci Vygeneruj mapu a vytvoří novou instanci třídy hráč
            casovac.Interval = 125;
            casovac.Tick += TiknutiCasovace;
            casovac.Start();
        }

        private void HerniOkno_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(800, 600);
            this.BackColor = Color.Black;
            this.Icon = Properties.Resources.lojza_icon;
            //Okno po nahrání stanoví velikost, barvu a ikonu
            
        }
        private void VygenerujMapu()
        {
            //funkce náhodně vygeneruje mapu
            Random generatorCisel = new Random();

            for (int X = 0; X < MAPA_SIRKA; X++)
            {
                for (int Y = 0; Y < MAPA_VYSKA; Y++)
                {
                    Mapa[X, Y] = StavyPolicek.Nevykopano;
                }
            }
            //nejdřív funkce vyplní všechny políčka hodnotou Nevykopano
            Mapa[0, 0] = StavyPolicek.Vykopano;
            //pak stanoví, že 0,0 bude startovní bod pro hráče - proto Hodnota Vykopano
            int RozmistenePrekazky = 0;
            while (RozmistenePrekazky < 30)
            {
                int NahodaX = generatorCisel.Next(0, MAPA_SIRKA);
                int NahodaY = generatorCisel.Next(0, MAPA_VYSKA);
                if (Mapa[NahodaX, NahodaY] == StavyPolicek.Nevykopano )
                {
                    Mapa[NahodaX, NahodaY] = StavyPolicek.Prekazka;
                    RozmistenePrekazky++;
                }
            }
            //pak rozmístí náhodně 30 překážek. Pokud se náhodně vygeneruje již obsazené místo (Vykopano nebo již daná překážka), tak se vybere jiné místo (tj.-proběhne cyklus na prázdno)
            int RozmistenePredmety = 0;
            while(RozmistenePredmety<10)
            {
                int NahodaX = generatorCisel.Next(0, MAPA_SIRKA);
                int NahodaY = generatorCisel.Next(0, MAPA_VYSKA);
                if (Mapa[NahodaX, NahodaY] == StavyPolicek.Nevykopano)
                {
                    int typPredmetu = generatorCisel.Next(0, 2);
                    if (typPredmetu == 0)
                    {
                        Mapa[NahodaX, NahodaY] = StavyPolicek.Drahokam;
                    }
                    else
                    {
                        Mapa[NahodaX, NahodaY] = StavyPolicek.Smaragd;
                    }
                    PocetPredmetu++;
                    RozmistenePredmety++;
                }
            }
            //Pak se náhodně rozmístí předměty - drahokamy a kameny. Dohromady jich bude 10. Mohou být jen na neobsazených místech.
            //pozor! Za tuhle funkci už nic víc nepsat! Leda před!
            bool hledaniProbiha = true;
            while (hledaniProbiha)
            {
                int NahodaX = generatorCisel.Next(1, MAPA_SIRKA-1);
                int NahodaY = generatorCisel.Next(1, MAPA_VYSKA-1);
                if (Mapa[NahodaX, NahodaY] == StavyPolicek.Nevykopano && 
                   (Mapa[NahodaX - 1, NahodaY] == StavyPolicek.Nevykopano || 
                   Mapa[NahodaX + 1, NahodaY] == StavyPolicek.Nevykopano))
                {
                    hledaniProbiha = false;
                    Mapa[NahodaX, NahodaY] = StavyPolicek.Vychod;
                }
            }
            //A posledně se rozmístí východ. Je jen jeden. Rozmístí se vždy na prázdném místě a za předpokladů, že místo nalevo a napravo jsou prázdná. Nemůže se vygenerovat na pravém kraji a dolejšku.
        }
        private void VykresliMapu(Graphics g)
        {
            //funkce volaná z draw. Přejímá grafiku (g). Projede postupně celou mapu a zakreslí na pole požadovaný znak, podle toho co obsahuje.
            for (int X = 0; X < MAPA_SIRKA; X++)
            {
                for (int Y = 0; Y < MAPA_VYSKA; Y++)
                {
                    switch(Mapa[X,Y])
                    {
                        case StavyPolicek.Vykopano:
                            g.DrawImage(G_Vykopano, X * polickoRozmer, Y * polickoRozmer);
                            break;
                        case StavyPolicek.Nevykopano:
                            g.DrawImage(G_Nevykopano, X * polickoRozmer, Y * polickoRozmer);
                            break;
                        case StavyPolicek.Prekazka:
                            g.DrawImage(G_Prekazka, X * polickoRozmer, Y * polickoRozmer);
                            break;
                        case StavyPolicek.Vychod:
                            g.DrawImage(G_Vychod, X * polickoRozmer, Y * polickoRozmer);
                            break;
                        case StavyPolicek.Drahokam:
                            g.DrawImage(G_Drahokam, X * polickoRozmer, Y * polickoRozmer);
                            break;
                        case StavyPolicek.Smaragd:
                            g.DrawImage(G_Smaragd, X * polickoRozmer, Y * polickoRozmer);
                            break;
                    }
                }
            }
        }
        private void VykresliHrace(Graphics g)
        {
            Image ObrazekKvykresleni;
            switch(Hrac.Smerhrace)
            {
                case Smer.Doprava:
                    ObrazekKvykresleni = G_Hrac_Vpravo;
                    break;
                case Smer.Doleva:
                    ObrazekKvykresleni = G_Hrac_Vlevo;
                    break;
                case Smer.Nahoru:
                    ObrazekKvykresleni = G_Hrac_Nahoru;
                    break;
                case Smer.Dolu:
                    ObrazekKvykresleni = G_Hrac_Dolu;
                    break;
                default:
                    ObrazekKvykresleni = G_Hrac_Vpravo;
                    break;
            }
            g.DrawImage(ObrazekKvykresleni, Hrac.X * polickoRozmer, Hrac.Y * polickoRozmer);
        }
        private void VykresliText(Graphics g)
        {
            Font pismo = new Font("Arial", 12);
            g.DrawString("Počet kroků: " + Hrac.PocetKroku, pismo, Brushes.White, 5, 560);
            g.DrawString("Zbývá sebrat předmětů: " + PocetPredmetu, pismo, Brushes.White, 5, 575);
        }
        private bool ZkontrolujPolicko(int x, int y)
        {
            return Mapa[x, y] != StavyPolicek.Prekazka;
        }
        private void KonecHry(string zprava)
        {
            casovac.Stop();
            MessageBox.Show(zprava, "Skvělá dobrodružství horníka Lojzy!");
            Application.Exit();
        }
        private void TiknutiCasovace(object o, EventArgs e)
        {
            ZkontrolujPrekazky();
        }
        private void ZkontrolujPrekazky()
        {
            bool[,] pouzitaPolicka = new bool[MAPA_SIRKA, MAPA_VYSKA];
            for (int X = 0; X < MAPA_SIRKA; X++)
            {
                for (int Y = 0; Y < MAPA_VYSKA; Y++)
                {
                    if (Y + 1 < MAPA_VYSKA)
                    {
                        if (Mapa[X, Y] == StavyPolicek.Prekazka && Mapa[X, Y + 1] == StavyPolicek.Vykopano && pouzitaPolicka[X, Y] == false)
                        {
                            pouzitaPolicka[X, Y + 1] = true;
                            Mapa[X, Y] = StavyPolicek.Vykopano;
                            Mapa[X, Y + 1] = StavyPolicek.Prekazka;
                            this.Invalidate();
                            if (Mapa[X, Y + 1] == Mapa[Hrac.X, Hrac.Y])
                            {
                                KonecHry("Prohráli jste na plné čáře :(!");
                                return;
                            }
                        }
                    }
                }
            }
        }
        private void HerniOkno_Paint(object sender, PaintEventArgs e)
        {
            //event spouští funkci pro vykreslí mapy a hráče na herní plochu
            VykresliMapu(e.Graphics);
            VykresliHrace(e.Graphics);
            VykresliText(e.Graphics);
        }

        private void HerniOkno_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control)
            {
                switch(e.KeyCode)
                {
                    case Keys.Right:
                        if (Hrac.X + 2 < MAPA_SIRKA && Mapa[Hrac.X + 1, Hrac.Y] == StavyPolicek.Prekazka && Mapa[Hrac.X + 2, Hrac.Y] == StavyPolicek.Vykopano)
                        {
                            Mapa[Hrac.X + 1, Hrac.Y] = StavyPolicek.Vykopano;
                            Mapa[Hrac.X + 2, Hrac.Y] = StavyPolicek.Prekazka;
                        }
                        break;
                    case Keys.Left:
                        if (Hrac.X - 2 >= 0 && Mapa[Hrac.X - 1, Hrac.Y] == StavyPolicek.Prekazka && Mapa[Hrac.X - 2, Hrac.Y] == StavyPolicek.Vykopano)
                        {
                            Mapa[Hrac.X - 1, Hrac.Y] = StavyPolicek.Vykopano;
                            Mapa[Hrac.X - 2, Hrac.Y] = StavyPolicek.Prekazka;
                        }
                        break;
                }
                this.Invalidate();
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        if (Hrac.X + 1 < MAPA_SIRKA && ZkontrolujPolicko(Hrac.X + 1, Hrac.Y))
                        {
                            Hrac.PocetKroku++;
                            Hrac.X++;
                        }
                        break;
                    case Keys.Left:
                        if (Hrac.X - 1 >= 0 && ZkontrolujPolicko(Hrac.X - 1, Hrac.Y))
                        {
                            Hrac.PocetKroku++;
                            Hrac.X--;
                        }
                        break;
                    case Keys.Up:
                        if (Hrac.Y - 1 >= 0 && ZkontrolujPolicko(Hrac.X, Hrac.Y - 1))
                        {
                            Hrac.PocetKroku++;
                            Hrac.Y--;
                        }
                        break;
                    case Keys.Down:
                        if (Hrac.Y + 1 < MAPA_VYSKA && ZkontrolujPolicko(Hrac.X, Hrac.Y + 1))
                        {
                            Hrac.PocetKroku++;
                            Hrac.Y++;
                        }
                        break;
                }
                if (Mapa[Hrac.X, Hrac.Y] == StavyPolicek.Nevykopano)
                {
                    Mapa[Hrac.X, Hrac.Y] = StavyPolicek.Vykopano;
                }
                else if (Mapa[Hrac.X, Hrac.Y] == StavyPolicek.Drahokam || Mapa[Hrac.X, Hrac.Y] == StavyPolicek.Smaragd)
                {
                    Mapa[Hrac.X, Hrac.Y] = StavyPolicek.Vykopano;
                    PocetPredmetu--;
                }
                this.Invalidate();
                if (Mapa[Hrac.X, Hrac.Y] == StavyPolicek.Vychod && PocetPredmetu == 0)
                {
                    KonecHry("Vyhrál jsi!");
                    return;
                }
            }
        }
    }
}
