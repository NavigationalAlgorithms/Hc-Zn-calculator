/*
	FILE: Hc Zn.cs
	
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
	Copyright (c) 1998
*/

namespace NavigationalAlgorithms
{
	public class HcZn : Sexagesimal
	{
		public static double LHA( double L, double GHA )
		{		
			return( ang_0_360( GHA+L ) );
		}

        public static double LHA2MeridianAngle(double LHA)
        {
            double ma = 0.0;

            if (0.0 <= LHA && LHA <= 180.0) ma = -LHA;      // W
            else if (180.0 < LHA && LHA <= 360.0) ma = 360.0 - LHA; // E
            else ma = 888.8;

            return (ma);
        }

        public static double Hc( double B, double Dec, double LHA )
		{
			return( ASIN( SIN( B )*SIN( Dec )+COS( B )*COS( Dec )*COS( LHA ) ) );
		}

		public static double Zn( double B, double Dec, double HC, double LHA )
		{
			//Z  = ACOS( (SIN( Dec )-SIN( B )*SIN( HC ))/(COS( B )*COS( HC )) );
			double Z;

			// |cos(x)| <= 1
			double x = 	( (SIN( Dec )-SIN( B )*SIN( HC ))/(COS( B )*COS( HC )) );
				 if( x > +1.0 ) x = +1.0;
			else if( x < -1.0 ) x = -1.0;
			
			Z  = ACOS( x );
			if( LHA <= 180.0 ) Z = 360.0-Z;

			return( Z );
		}

        public static double Z(double Dec, double LHA, double Hc)
        {
            return (ASIN(SIN(LHA) * COS(Dec) / COS(Hc)));
        }

        public static string Zstr(double Dec, double LHA, double Hc)
        {
            double Z = ASIN(SIN(LHA) * COS(Dec) / COS(Hc));

            double P = LHA2MeridianAngle(LHA);

            string Zcuadrantal = "";
            if (Z > 0)
                Zcuadrantal += "N";
            else
                Zcuadrantal += "S";

            Zcuadrantal += abs(Z).ToString("0.0");

            if (P > 0)
                Zcuadrantal += "E";
            else
                Zcuadrantal += "W";

            return (Zcuadrantal);
        }
    }
}
