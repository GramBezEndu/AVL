using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AVL
{
    class Drzewo
    {
        public Wezel korzen;

		public Wezel RightRotate(Wezel y)
		{
			Wezel x = y.Lewy;
			Wezel t2 = x.Prawy;

			x.Prawy = y;
			y.Lewy = t2;

			y.Height = Math.Max(Height(y.Lewy), Height(y.Prawy)) + 1;
			x.Height = Math.Max(Height(x.Lewy), Height(x.Prawy)) + 1;
			return x;
		}

		public Wezel LeftRotate(Wezel x)
		{
			Wezel y = x.Prawy;
			Wezel t2 = y.Lewy;

			y.Lewy = x;
			x.Prawy = t2;

			x.Height = Math.Max(Height(x.Lewy), Height(x.Prawy)) + 1;
			y.Height = Math.Max(Height(y.Lewy), Height(y.Prawy)) + 1;

			return y;
		}
		
		public int GetBalance(Wezel n)
		{
			if (n == null)
				return 0;
			return Height(n.Lewy) - Height(n.Prawy);
		}

		public int Height(Wezel n)
		{
			if (n == null)
				return 0;
			return n.Height;
		}

		public Wezel WstawSlowo(Wezel korzen, string slowo)
		{
			if (korzen == null)
			{
				return new Wezel(slowo);
			}
			if (slowo.CompareTo(korzen.Slowo) < 0)
			{
				korzen.Lewy = WstawSlowo(korzen.Lewy, slowo);
			}
			else if (slowo.CompareTo(korzen.Slowo) > 0)
			{
				korzen.Prawy = WstawSlowo(korzen.Prawy, slowo);
			}
			else
				throw new Exception("Te slowo znajduje sie juz w drzewie");
			korzen.Height = Math.Max(Height(korzen.Lewy), Height(korzen.Prawy)) + 1;

			int balance = GetBalance(korzen);
			if (balance > 1 && slowo.CompareTo(korzen.Lewy.Slowo) < 0)
			{
				return RightRotate(korzen);
			}
			if (balance < -1 && slowo.CompareTo(korzen.Prawy.Slowo) > 0)
			{
				return LeftRotate(korzen);
			}
			if (balance > 1 && slowo.CompareTo(korzen.Lewy.Slowo) > 0)
			{
				korzen.Lewy = LeftRotate(korzen.Lewy);
				return RightRotate(korzen);
			}
			if(balance < -1 && slowo.CompareTo(korzen.Prawy.Slowo) < 0)
			{
				korzen.Prawy = RightRotate(korzen.Prawy);
				return LeftRotate(korzen);
			}
			return korzen;
		}

		public Wezel UsunSlowo(Wezel root, string slowo)
		{
			if (root == null)
				return null;
			if(slowo.CompareTo(root.Slowo) < 0)
			{
				root.Lewy = UsunSlowo(root.Lewy, slowo);
			}
			else if(slowo.CompareTo(root.Slowo) > 0)
			{
				root.Prawy = UsunSlowo(root.Prawy, slowo);
			}
			else
			{
				//jeden syn lub brak synow
				if (root.Lewy == null || root.Prawy == null)
				{
					Wezel temp;
					//brak synow
					if (root.Lewy == null && root.Prawy == null)
					{
						temp = root;
						root = null;
					}
					//jeden syn
					else
					{
						if (root.Lewy == null)
							temp = root.Prawy;
						else
							temp = root.Lewy;
						//przypisz korzen pod niepustego syna
						root = temp;
					}
				}
				//Dwoch synow
				else
				{
					Wezel temp = MinValueNode(root.Prawy);
					root.Slowo = temp.Slowo;
					root.Prawy = UsunSlowo(root.Prawy, temp.Slowo);
				}
			}
			if (root == null)
				return root;
			root.Height = Math.Max(Height(root.Lewy),Height(root.Prawy)) + 1;

			int balance = GetBalance(root);
			if(balance > 1 && GetBalance(root.Lewy)>=0)
			{
				return RightRotate(root);
			}
			if(balance > 1 && GetBalance(root.Lewy)<0)
			{
				root.Lewy = LeftRotate(root.Lewy);
				return RightRotate(root);
			}
			if(balance < -1 && GetBalance(root.Prawy)>0)
			{
				root.Prawy = RightRotate(root.Prawy);
				return LeftRotate(root);
			}
			return root;
		}

		public Wezel MinValueNode(Wezel node)
		{
			Wezel current = node;
			while(current.Lewy != null)
			{
				current = current.Lewy;
			}
			return current;
		}

        public void WypiszDrzewo(Wezel korzen)
        {
            if (korzen == null)
                return;
            Console.WriteLine(korzen.Slowo);
            if (korzen.Lewy != null)
            {
                WypiszDrzewo(korzen.Lewy);
                //Console.WriteLine(korzen.Lewy.Slowo);
            }
            if (korzen.Prawy != null)
            {
                WypiszDrzewo(korzen.Prawy);
            }
        }

		public void WypiszDrzewoOrazTlumaczenia(Wezel korzen)
		{
			if (korzen == null)
				return;
			Console.WriteLine("{0}\t{1}", korzen.Slowo, korzen.Tlumaczenie.Slowo);
			if (korzen.Lewy != null)
			{
				WypiszDrzewoOrazTlumaczenia(korzen.Lewy);
				//Console.WriteLine(korzen.Lewy.Slowo);
			}
			if (korzen.Prawy != null)
			{
				WypiszDrzewoOrazTlumaczenia(korzen.Prawy);
			}
		}

		public Wezel Wyszukaj(Wezel korzen, string slowo)
		{
			// Base Cases: root is null or key is present at root 	
			if (korzen == null || slowo.CompareTo(korzen.Slowo) == 0)
				return korzen;
			//return null;	
			// Key is greater than root's key 	
			if (korzen.Slowo.CompareTo(slowo) < 0)
				return Wyszukaj(korzen.Prawy, slowo);
			//Key is smaller than root's key 	
			return Wyszukaj(korzen.Lewy, slowo);
		}
	}
}
