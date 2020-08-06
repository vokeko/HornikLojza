using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Hornik_Lojza
{
    class PostavaHrace
    {

        public Smer Smerhrace
        {
            get;
            private set;
        }
        private int _pocetKroku = 0;
        public int PocetKroku
        {
            get
            {
                return _pocetKroku;
            }
            set
            {
                _pocetKroku = value;
            }
        }
        private int x = 0, y = 0;
        //x a y (nebo X a Y) uchovávají pozici, na které hráč je
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (X > value)
                {
                    Smerhrace = Smer.Doleva;
                }
                else
                {
                    Smerhrace = Smer.Doprava;
                }
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (Y > value)
                {
                    Smerhrace = Smer.Nahoru;
                }
                else
                {
                    Smerhrace = Smer.Dolu;
                }
                y = value;
            }
        }
        public PostavaHrace()
        {
            //konstruktor přiřadí obrazek(poslaný image typ) Grafice - tj. přiřadí postavě při vytvoření obrázek pro pohyb doprava.
            Smerhrace = Smer.Doprava;
        }
    }
}
