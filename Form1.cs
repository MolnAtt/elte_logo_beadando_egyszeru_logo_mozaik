using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LogoKaresz
{
	public partial class Form1 : Form
	{
		
		void FELADAT()
		{
			Tollvastagság(3);
			Fal(4,10,20);

		}

		private void Alap(double méret)
		{
			EJ(méret, 30);
			EJ(méret, 120);
			EJ(méret, 30);
			EJ(méret, 90);
			EJ(méret, 90);
		}

		void Lopakodva_Oldalaz(double d) => Lopakodva_Oldalaz(defaultkaresz, d);
		static void Lopakodva_Oldalaz(Avatar a, double d)
		{
			using (new Rajzol(false))
			using (new Átmenetileg(Jobbra, 90))
				a.Előre(d);
		}
		void Sor(int N, double méret, Color szín1, Color szín2)
		{
			bool első_szín = true;
			Ismétlés(N, delegate () 
			{
				if (első_szín)
					SzinesAlap(méret, szín1);
				else
					SzinesAlap(méret, szín2);
				első_szín = !első_szín;
				Lopakodva_Oldalaz(méret);
			});
			Lopakodva_Oldalaz(-N*méret);
		}

		void Sor1(int N, double méret) => Sor(N, méret, Color.Green, Color.Purple);
		void Sor2(int N, double méret) => Sor(N, méret, Color.Red, Color.Yellow);
		void SzinesAlap(double méret, Color szín) { Alap(méret); Odatölt(45, méret, szín); }
		void Dupla(int N, double méret) 
		{
			Sor1(N, méret);
            using (new Átmenetileg(Lopakodva_Oldalaz,N*méret))
            using (new Átmenetileg(Előre,méret))
            using (new Átmenetileg(Jobbra,30))
            using (new Átmenetileg(Előre,méret))
            using (new Átmenetileg(Balra,30))
            using (new Átmenetileg(Előre,méret))
            using (new Átmenetileg(Jobbra,180))
				Sor2(N, méret);
		}

		void Fal(int M, int N, double méret)
		{
			Ismétlés(M, delegate () {
				Dupla(N, méret);
				Emel(méret);
			});
			Ismétlés(M, delegate () { Emel(-méret); });
		}

		void Emel(double méret)
		{
			EJ(méret, 30);
			EJ(méret, -30);
			Előre(méret);
		}

		void Odatölt(double f, double m, Color szín)
		{
			using (new Rajzol(false))
			using (new Átmenetileg(Jobbra, f))
			using (new Átmenetileg(Előre, m))
				Tölt(szín);
		}

        private void EJ(double d, double f) { Előre(d);Jobbra(f); }
    }
}
