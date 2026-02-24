/*
	FILE: Ageton.cs
	
	B - Latitude +N/-S
	L - Longitude +E/-W
	Dec - Declination +N/-S
	GHA - Greenwich hour angle
	
	LHA - Local hour angle

	Hc - Altitude (calculated)
	Zn - Azimut
	
	This file contains proprietary information of Andrés Ruiz Gonzalez
	Copying or reproduction without prior written approval is prohibited.
	Andrés Ruiz. San Sebastian - Donostia. Gipuzkoa
	Navigational Algorithms
	Copyright (c) 2015
*/

using System;


namespace NavigationalAlgorithms
{
	public class Ageton : Sexagesimal
	{
        #region Ageton table

        public static double A(double x)
        {
            return (1E5 * Math.Log10(1.0 / SIN(x)));
        }

        public static double B(double x)
        {
            return (1E5 * Math.Log10(1.0 / COS(x)));
        }

        public static double aA(double A)
        {
            return (ASIN(1.0 / Math.Pow(10.0, A / 1E5)));
        }

        public static double aB(double B)
        {
            return (ACOS(1.0 / Math.Pow(10.0, B / 1E5)));
        }

        public static string Table()
        {
            string table = "";
            double x;

            for (double xd = 0.0; xd < 180.0; xd++)
            {
                for (double xm = 0.0; xm <= 60.0; xm++)
                {
                    x = xd + xm / 60.0;
                    table += xd + "º " + xm + "'\t" + x + "\t" + A(x).ToString("0.") + "\t" + B(x).ToString("0.#") + "\r\n";
                }
            }

            return table;
        }

        #endregion


        public static Tuple<double, double> HcZn_Ageton(double lat, double lon, double Dec, double GHA)
        {
            double LHA = HcZn.LHA(lon, GHA);
            double t = HcZn.LHA2MeridianAngle(LHA);

            double Ar = A(t) + B(Dec);
            double R = aA(Ar);
            double Ak = A(Dec) - B(R);
            double K = aA(Ak);

            double Ahc = B(R) + B(K - lat);
            double Hc = aA(Ahc);

            double AZn = Ar - B(Hc);
            double Zn = aA(AZn); // kk sg(Zn)

            return new Tuple<double, double>(Hc, Zn);
        }

        public static string Examples()
        {
            string text = "";

            Tuple<double, double> ex1 = HcZn_Ageton(-20, 15, 15, 45);
            text += ex1.Item1.ToString() + "\r\n";
            text += ex1.Item2.ToString() + "\r\n";

            Tuple<double, double> ex2 = HcZn_Ageton(-30, 15, -10, 45);
            text += ex2.Item1.ToString() + "\r\n";
            text += ex2.Item2.ToString() + "\r\n";

            Tuple<double, double> ex3 = HcZn_Ageton(30, 15, -10, 45);
            text += ex3.Item1.ToString() + "\r\n";
            text += ex3.Item2.ToString() + "\r\n";

            Tuple<double, double> ex4 = HcZn_Ageton(+45, -45, +10, 330);
            text += ex4.Item1.ToString() + "\r\n";
            text += ex4.Item2.ToString() + "\r\n";

            return text;
        }

    }
}
