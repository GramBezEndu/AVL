using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class Wezel
    {
		protected Wezel lewy;
		protected Wezel prawy;
		protected Wezel tlumaczenie;
		protected string slowo;
		protected int height;

		public Wezel Lewy { get => lewy; set => lewy = value; }
		public Wezel Prawy { get => prawy; set => prawy = value; }
		public string Slowo { get => slowo; set => slowo = value; }
		public Wezel Tlumaczenie { get => tlumaczenie; set => tlumaczenie = value; }
		public int Height { get => height; set => height = value; }

		//public int Height { get => height; set => height = value; }

		//Konstrukcja wierzcholka 
		public Wezel(string wyraz)
        {
            this.slowo = wyraz;
			this.Height = 1;
        }
    }
}
