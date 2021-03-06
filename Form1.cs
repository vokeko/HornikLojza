﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace Hornik_Lojza
{
    enum Smer
    {
        //enum pro určení, kterým směrem je postava hráče otočená. Je takhle bokem, aby se k ní dostala i třída postavy.
        Doprava, Doleva, Nahoru, Dolu, Mrtvy
    }
    public partial class HerniOkno : Form
    {
        //Všechny políčka mají rozměry 40x40
        const int polickoRozmer = 40;
        //Mapa má šířku 20 na 14 bloků. Nemění se.
        const int MAPA_SIRKA = 20;
        const int MAPA_VYSKA = 14;

        //všechny obrázky přebíráme z properties.resources.
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

        SoundPlayer prehravac = new SoundPlayer(Properties.Resources.minin_all_day);
        // bool sleduje jestli hraje zvuk nebo ne.
        bool hraje = false;

        //Počítá, kolik zbývá předmětů
        int PocetPredmetu = 0;
        //Třída Postavahrace, mezitím bez nového zástupce
        PostavaHrace Hrac;

        //Enum rozlišuje, co políčka mapy obsahují.
        enum StavyPolicek
        {
            Nevykopano, Vykopano, Prekazka, Drahokam, Smaragd, Vychod
        }

        // Mapa uchovává hodnoty pro jednotlivé pole v úrovni
        StavyPolicek[,] Mapa = new StavyPolicek[MAPA_SIRKA, MAPA_VYSKA];

        //časovač se aktivuje jednou za určitou dobu. Kontroluje, jestli jsou na herní ploše kameny, které by mohly spadnout
        Timer casovac = new Timer();

        //Proměnné cisloprekazek a cislodrahokamu jsou readonly, protože se změní v konstruktoru - a jsou různé, dle toho jestli byla vytvořena vlastní hra
        private readonly uint cisloprekazek;
        private readonly uint cislodrahokamu;

        public HerniOkno(int casovyInterval = 125, uint _cisloprekazek = 30, uint _cislodrahokamu = 10)
        {
            //konstruktor, který když se spustí zavolá funkci Vygeneruj mapu a vytvoří novou instanci třídy hráč
            cisloprekazek = _cisloprekazek;
            cislodrahokamu = _cislodrahokamu;
            InitializeComponent();
            VygenerujMapu();
            Hrac = new PostavaHrace();

            //konstruktor nastaví interval časovače, spustí ho a přidělí mu funkci TiknutiCasovace
            casovac.Interval = casovyInterval;
            casovac.Tick += TiknutiCasovace;
            casovac.Start();
        }

        private void HerniOkno_Load(object sender, EventArgs e)
        {
            //Okno po nahrání stanoví velikost, barvu a ikonu
            this.ClientSize = new Size(800, 600);
            this.BackColor = Color.Black;
            this.Icon = Properties.Resources.lojza_icon;

            hraje = prohod();
        }
        private bool prohod()
        {
            //zastaví nebo spustí muziku podle toho jestli hraje nebo ne
            if (hraje == true)
            {
                prehravac.Stop();
                return false;
            }
            else
            {
                prehravac.PlayLooping();
                return true;
            }
        }
        private void VygenerujMapu()
        {
            //funkce náhodně vygeneruje mapu

            Random generatorCisel = new Random();

            //nejdřív funkce vyplní úplně všechny políčka hodnotou Nevykopano
            for (int X = 0; X < MAPA_SIRKA; X++)
            {
                for (int Y = 0; Y < MAPA_VYSKA; Y++)
                {
                    Mapa[X, Y] = StavyPolicek.Nevykopano;
                }
            }
            //pak stanoví, že 0,0 bude startovní bod pro hráče - proto Hodnota Vykopano
            Mapa[0, 0] = StavyPolicek.Vykopano;

            //pak rozmístí náhodně 30 překážek. Pokud se náhodně vygeneruje již obsazené místo (Vykopano nebo již daná překážka), tak se vybere jiné místo (tj.-proběhne cyklus na prázdno)
            int RozmistenePrekazky = 0;
            while (RozmistenePrekazky < cisloprekazek)
            {
                int NahodaX = generatorCisel.Next(0, MAPA_SIRKA);
                int NahodaY = generatorCisel.Next(0, MAPA_VYSKA);
                if (Mapa[NahodaX, NahodaY] == StavyPolicek.Nevykopano )
                {
                    Mapa[NahodaX, NahodaY] = StavyPolicek.Prekazka;
                    RozmistenePrekazky++;
                }
            }

            //Pak se náhodně rozmístí předměty - drahokamy a kameny. Dohromady jich bude 10. Mohou být jen na neobsazených místech.
            int RozmistenePredmety = 0;
            while (RozmistenePredmety < cislodrahokamu)
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

            //pozor! Za tuhle funkci už nic víc nepsat! Leda před!
            //A posledně se rozmístí východ. Je jen jeden. Rozmístí se vždy na prázdném místě a za předpokladů, že místo nalevo a napravo jsou prázdná. Nemůže se vygenerovat na pravém kraji a dolejšku.
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
            //funkce, která vykreslí postavu podle toho, na jaký směr je otočená.
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

                case Smer.Mrtvy:
                    Bitmap prazdny = new Bitmap(40,40);
                    ObrazekKvykresleni = prazdny;
                    break;

                default:
                    ObrazekKvykresleni = G_Hrac_Vpravo;
                    break;
            }

            g.DrawImage(ObrazekKvykresleni, Hrac.X * polickoRozmer, Hrac.Y * polickoRozmer);

        }
        private void VykresliText(Graphics g)
        {
            //Funkce na dolejšek formu vykreslí kolik zbývá předmětů a kolik hráč udělal kroků.

            Font pismo = new Font("Arial", 12);
            g.DrawString("Počet kroků: " + Hrac.PocetKroku, pismo, Brushes.White, 5, 560);
            g.DrawString("Zbývá sebrat předmětů: " + PocetPredmetu, pismo, Brushes.White, 5, 575);

        }

        private bool ZkontrolujPolicko(int x, int y)
        {
            //Funkce kontroluje, jestli je dané políčko překážka (kámen)
            return Mapa[x, y] != StavyPolicek.Prekazka;
        }

        private void KonecHry(string zprava, bool vyhrat)
        {
            //Při konci hry se zastaví časovač, ukáže se příslušná zpráva (dopbrá nebo špatná) a ukončí se aplikace.

            casovac.Stop();
            Hrac.jeMrtvy(true);
            this.Invalidate();

            if (hraje)
            {
                if (vyhrat)
                {
                    SoundPlayer fanfara = new SoundPlayer(Properties.Resources.Victory);
                    fanfara.Play();
                }
                else
                {
                    SoundPlayer fanfara = new SoundPlayer(Properties.Resources.dead);
                    fanfara.Play();
                }
            }
            MessageBox.Show(zprava, "Skvělá dobrodružství horníka Lojzy!");
            Application.Exit();

        }

        private void TiknutiCasovace(object o, EventArgs e)
        {
            //event, který se spustí při tiknutí časovače
            ZkontrolujPrekazky();

        }

        private void ZkontrolujPrekazky()
        {
            //Kontroluje, jestli na hráče nespadl kámen (tj. - konec hry)

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

                            if (Mapa[X, Y + 1] == Mapa[Hrac.X, Hrac.Y])
                            {
                                KonecHry("Prohráli jste na plné čáře !", false);
                                return;
                            }

                        }
                    }
                }
            }

            this.Invalidate();

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
            //Rozsáhlá funkce pro pohyb
            if(e.Control)
            {
                //tahle část kódu je spuštěna, pokud hráč drží ctrl + šipku doleva nebo prava. Pokud je v tom směru od postavy kámen a o políčko volno je prázdno, pak se tam posune.

                switch (e.KeyCode)
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
                //Tahle část kódu kontroluje, jestli hráč se může tím směrem pohnout, když klikne klávesu pro pohyb. Nemůže se tak stát v případě, že se snaží posunout za okraj mapy, nebo na políčko kamene

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

                //Tato část kódu kontroluje, na jaké políčko hráč vstupuje. Pokud je nevykopané, vykopá se. Pokud je to drahokam, vykopá se a sníží se počet předmětů, co jsou zapotřebí. Pokud je to políčko pro východ, tak se zkontroluje jestli hráč sebral všechny předměty.

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
                    KonecHry("Vyhrál jsi!", true);
                    return;
                }

            }

            if (e.KeyCode == Keys.M)
            {
                hraje = prohod();
            }

        }
    }
}
