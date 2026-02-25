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
using System.Net.NetworkInformation;


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

        public static (double Hc, double Zn) SightReduction(double lat, double lon, double Dec, double GHA)
        {
            double LHA = HcZn.LHA(lon, GHA);
            double t = HcZn.LHA2MeridianAngle(LHA);

            //TODO -> testing
            t = LHA;
            
            double Ar = A(t) + B(Dec);
            double R = aA(Ar);
            double Ak = A(Dec) - B(R);
            double K = aA(Ak);

            double Ahc = B(R) + B(K - lat);
            double Hc = aA(Ahc);

            double AZn = Ar - B(Hc);
            double Zn = aA(AZn); // TODO sg(Zn)

            return new(Hc, Zn);
        }

        public static string Test()
        {
            string text = "Examples Ageton SR";
            text += "\r\n";

            var ex1 = SightReduction(-20, 15, 15, 45);
            text += ex1.Hc.ToString() + " = " + DMSformat.DMm(ex1.Hc) + "\r\n";
            text += ex1.Zn.ToString() + " = " + DMSformat.DMm(ex1.Zn) + "\r\n";

            var ex2 = SightReduction(-30, 15, -10, 45);
            text += ex2.Hc.ToString() + " = " + DMSformat.DMm(ex2.Hc) + "\r\n";
            text += ex2.Zn.ToString() + " = " + DMSformat.DMm(ex2.Zn) + "\r\n";

            var ex3 = SightReduction(30, 15, -10, 45);
            text += ex3.Hc.ToString() + " = " + DMSformat.DMm(ex3.Hc) + "\r\n";
            text += ex3.Zn.ToString() + " = " + DMSformat.DMm(ex3.Zn) + "\r\n";

            var ex4 = SightReduction(+45, -45, +10, 330);
            text += ex4.Hc.ToString() + " = " + DMSformat.DMm(ex4.Hc) + "\r\n";
            text += ex4.Zn.ToString() + " = " + DMSformat.DMm(ex4.Zn) + "\r\n";

            return text;
        }
    }
}
