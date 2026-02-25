/*
	File: Sexagesimal.cs
	
	This file contains proprietary information of Andrés Ruiz Gonzalez
	Copying or reproduction without prior written approval is prohibited.
	Andrés Ruiz. San Sebastian - Donostia. Gipuzkoa
	Navigational Algorithms
	Copyright (c) 1998	
*/

using System;
using System.Globalization;

namespace NavigationalAlgorithms
{
    public class Sexagesimal
    {
        public static double SIN(double x) { return Math.Sin(x * Math.PI / 180.0); }
        public static double COS(double x) { return Math.Cos(x * Math.PI / 180.0); }
        public static double TAN(double x) { return Math.Tan(x * Math.PI / 180.0); }

        public static double ASIN(double x) { return 180.0 / Math.PI * Math.Asin(x); }
        public static double ACOS(double x) { return 180.0 / Math.PI * Math.Acos(x); }
        public static double ATAN(double x) { return 180.0 / Math.PI * Math.Atan(x); }
        public static double ATAN2(double x, double y) { return (180.0 / Math.PI * (Math.Atan2(x, y))); }

        // CONVERSION DE UN ANGULO EN (º) DENTRO DE LOS LIMITES DE 0º Y 360º
        public static double ang_0_360(double ang)
        {
            if (ang < 0.0)
                while (ang < 0.0) ang = ang + 360.0;
            else if (ang > 360.0)
                while (ang > 360.0) ang = ang - 360.0;

            return (ang);
        }

        public static double abs(double x) { return Math.Abs(x); }
    }
}
