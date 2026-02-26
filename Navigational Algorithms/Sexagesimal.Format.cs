/*
	File: Sexagesimal.Format.cs
	
	This file contains proprietary information of Andrés Ruiz Gonzalez
	Copying or reproduction without prior written approval is prohibited.
	Andrés Ruiz. San Sebastian - Donostia. Gipuzkoa
	Navigational Algorithms
	Copyright (c) 2026	
*/

using System;
using System.Globalization;

namespace NavigationalAlgorithms
{
    public static class DMSformat
    {
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        #region TMP

        public static string FormatearGradosMinutos(double ang)
        {
            // Conservar el signo
            string signo = ang < 0 ? "-" : "";
            double valorAbs = Math.Abs(ang);

            // Grados enteros
            int grados = (int)Math.Floor(valorAbs);

            // Minutos decimales
            double minutosDec = (valorAbs - grados) * 60;

            // Redondear a 1 decimal
            minutosDec = Math.Round(minutosDec, 1);

            // Ajuste si redondeo empuja a 60.0
            if (minutosDec >= 60.0)
            {
                grados += 1;
                minutosDec = 0.0;
            }

            // Formato final
            return $"{signo}{grados:00}º {minutosDec:00.0}'";
        }

        public static string FormatearGradosMinutosSegundos(double ang)
        {
            // Conservar el signo
            string signo = ang < 0 ? "-" : "";
            double valorAbs = Math.Abs(ang);

            // Grados enteros
            int grados = (int)Math.Floor(valorAbs);

            // Minutos totales decimales
            double minutosTot = (valorAbs - grados) * 60;

            int minutos = (int)Math.Floor(minutosTot);

            // Segundos decimales
            double segundos = (minutosTot - minutos) * 60;

            // Redondear a 1 decimal
            segundos = Math.Round(segundos, 1);

            // Ajuste si segundos redondean a 60.0
            if (segundos >= 60.0)
            {
                segundos = 0.0;
                minutos += 1;
            }

            // Ajuste si minutos llegan a 60
            if (minutos >= 60)
            {
                minutos = 0;
                grados += 1;
            }

            // Formato final
            return $"{signo}{grados:00}º {minutos:00}' {segundos:00.0}\"";
        }

        public static double GradosMinutosSegundosADecimal(int grados, int minutos, double segundos)
        {
            double valor = Math.Abs(grados) + (minutos / 60.0) + (segundos / 3600.0);

            // Mantener el signo original si grados era negativo
            return grados < 0 ? -valor : valor;
        }

        public static string FormatearGMSHemisferio(double valor, bool esLatitud)
        {
            // Determinar hemisferio
            char hemi;

            if (esLatitud)
                hemi = valor >= 0 ? 'N' : 'S';
            else
                hemi = valor >= 0 ? 'E' : 'O';

            double absVal = Math.Abs(valor);

            int grados = (int)Math.Floor(absVal);
            double minutosTot = (absVal - grados) * 60;
            int minutos = (int)Math.Floor(minutosTot);
            double segundos = (minutosTot - minutos) * 60;

            segundos = Math.Round(segundos, 1);

            if (segundos >= 60.0)
            {
                segundos = 0;
                minutos++;
            }

            if (minutos >= 60)
            {
                minutos = 0;
                grados++;
            }

            return $"{grados:00}º {minutos:00}' {segundos:00.0}\" {hemi}";
        }

        public static double GMSHemisferioADecimal(int grados, int minutos, double segundos, char hemisferio)
        {
            double valor = Math.Abs(grados) + (minutos / 60.0) + (segundos / 3600.0);

            hemisferio = char.ToUpper(hemisferio);

            // Aplicar signo según hemisferio
            if (hemisferio == 'S' || hemisferio == 'O')
                valor = -valor;

            return valor;
        }

        #endregion

        /// <summary>
        /// Formatea grados decimales a "DDº MM.M'".
        /// Minutos con 1 decimal, redondeo y ajuste si llega a 60.0.
        /// </summary>
        public static string DM(double ang) =>
            DMM(ang, decimalesMinutos: 1, includeSign: true);

        /// <summary>
        /// Formatea grados decimales a "DDº MM.mmm'".
        /// Minutos con 3 decimales, redondeo y ajuste si llega a 60.000.
        /// </summary>
        public static string DMm(double ang) =>
            DMM(ang, decimalesMinutos: 3, includeSign: true);

        /// <summary>
        /// Formatea grados decimales a "DDº MM.m..m' H" donde H = N/S/E/O.
        /// Por defecto usa 3 decimales en minutos (DDº MM.mmm').
        /// </summary>
        public static string DMmHemisferio(double valor, bool esLatitud, int decimalesMinutos = 3)
        {
            char hemi = GetHemisferio(valor, esLatitud);
            string core = DMM(Math.Abs(valor), decimalesMinutos, includeSign: false);
            return $"{core} {hemi}";
        }

        /// <summary>
        /// Formatea grados decimales a "DDº MM' SS.S"" (por defecto 1 decimal en segundos).
        /// Maneja redondeos y acarreos.
        /// </summary>
        public static string DMS(double ang, int decimalesSegundos = 1)
        {
            string signo = ang < 0 ? "-" : "";
            double v = Math.Abs(ang);

            int grados = (int)Math.Floor(v);
            double minutosTot = (v - grados) * 60.0;
            int minutos = (int)Math.Floor(minutosTot);

            double segundos = (minutosTot - minutos) * 60.0;

            // Redondeo; AwayFromZero evita el "banker's rounding"
            segundos = Math.Round(segundos, decimalesSegundos, MidpointRounding.AwayFromZero);

            if (segundos >= 60.0)
            {
                segundos = 0.0;
                minutos += 1;
            }
            if (minutos >= 60)
            {
                minutos = 0;
                grados += 1;
            }

            string fmtSeg = "00." + new string('0', Math.Max(0, decimalesSegundos));
            return $"{signo}{grados.ToString("00", Inv)}º {minutos.ToString("00", Inv)}' {segundos.ToString(fmtSeg, Inv)}\"";
        }

        /// <summary>
        /// Formatea grados decimales a "DDº MM' SS.s..s"" H" (H = N/S/E/O).
        /// </summary>
        public static string DMSHemisferio(double valor, bool esLatitud, int decimalesSegundos = 1)
        {
            char hemi = GetHemisferio(valor, esLatitud);
            string core = DMS(Math.Abs(valor), decimalesSegundos);
            // 'core' no incluye hemisferio ni signo (porque pasamos valor absoluto),
            // así que simplemente añadimos H.
            return $"{core.Replace("-", "")} {hemi}";
        }

        #region Inversas

        /// <summary>
        /// Convierte DDº MM' SS" a grados decimales.
        /// El signo viene dado por 'grados' (si grados &lt; 0, devuelve negativo).
        /// </summary>
        public static double DMS2D(int grados, int minutos, double segundos)
        {
            double abs = Math.Abs(grados) + (Math.Abs(minutos) / 60.0) + (Math.Abs(segundos) / 3600.0);
            double val = grados < 0 ? -abs : abs;
            return val;
        }

        /// <summary>
        /// Convierte DD MM SS H (H = N/S/E/O/W) a grados decimales.
        /// </summary>
        public static double DMSHemisferio2D(int grados, int minutos, double segundos, char hemisferio)
        {
            double val = Math.Abs(grados) + (Math.Abs(minutos) / 60.0) + (Math.Abs(segundos) / 3600.0);
            hemisferio = char.ToUpperInvariant(hemisferio);
            if (hemisferio == 'S' || hemisferio == 'O' || hemisferio == 'W')
                val = -val;
            return val;
        }

        /// <summary>
        /// Convierte DDº MM.mmm' (minutos decimales) a grados decimales.
        /// El signo viene dado por 'grados' (si grados &lt; 0, devuelve negativo).
        /// Acepta minutosDec &gt;= 60 y normaliza.
        /// </summary>
        public static double DMm2D(int grados, double minutosDec)
        {
            double absGrados = Math.Abs(grados);

            // Normalización por si minutosDec >= 60
            if (minutosDec >= 60.0)
            {
                int extra = (int)Math.Floor(minutosDec / 60.0);
                absGrados += extra;
                minutosDec = minutosDec - (extra * 60.0);
            }

            double abs = absGrados + (Math.Abs(minutosDec) / 60.0);
            double val = grados < 0 ? -abs : abs;
            return val;
        }

        /// <summary>
        /// Convierte DD MM.mmm H (H = N/S/E/O/W) a grados decimales.
        /// Acepta minutosDec &gt;= 60 y normaliza.
        /// </summary>
        public static double DMmHemisferio2D(int grados, double minutosDec, char hemisferio)
        {
            double absGrados = Math.Abs(grados);

            if (minutosDec >= 60.0)
            {
                int extra = (int)Math.Floor(minutosDec / 60.0);
                absGrados += extra;
                minutosDec = minutosDec - (extra * 60.0);
            }

            double val = absGrados + (Math.Abs(minutosDec) / 60.0);
            hemisferio = char.ToUpperInvariant(hemisferio);
            if (hemisferio == 'S' || hemisferio == 'O' || hemisferio == 'W')
                val = -val;
            return val;
        }

        #endregion

        #region Internos / auxiliares

        /// <summary>
        /// Formatea DDº MM.x..x' con N decimales en minutos.
        /// </summary>
        private static string DMM(double ang, int decimalesMinutos, bool includeSign)
        {
            string signo = (includeSign && ang < 0) ? "-" : "";
            double v = Math.Abs(ang);

            int grados = (int)Math.Floor(v);
            double minutos = (v - grados) * 60.0;

            minutos = Math.Round(minutos, decimalesMinutos, MidpointRounding.AwayFromZero);

            if (minutos >= 60.0)
            {
                minutos = 0.0;
                grados += 1;
            }

            string fmtMin = decimalesMinutos > 0
                ? "00." + new string('0', decimalesMinutos)
                : "00";

            return $"{signo}{grados.ToString("00", Inv)}º {minutos.ToString(fmtMin, Inv)}'";
        }

        /// <summary>
        /// Devuelve el hemisferio correspondiente según signo y tipo de coordenada.
        /// esLatitud = true => N/S, false => E/O.
        /// </summary>
        private static char GetHemisferio(double valor, bool esLatitud)
        {
            if (esLatitud)
                return valor >= 0 ? 'N' : 'S';
            else
                return valor >= 0 ? 'E' : 'W';
        }

        #endregion

        public static string Test()
        {
            string test = "";

            // 1) DDº MM.M'
            test += DM(12.3456);
            // 12º 20.7'

            // 2) DDº MM.mmm'
            test += DMm(-3.999);
            // -03º 59.940'

            // 3) DDº FormatearGradosMinutosSegundos(15.999999);
            // 16º 00' 00.0"

            // 4) DMM con hemisferio (latitud)
            test += DMmHemisferio(43.267, true);
            // 43º 16.020' N

            // 5) DMS con hemisferio (longitud)
            test += DMSHemisferio(-2.92344, false);
            // 02º 55' 24.4" O

            // 6) Inversas
            double d1 = DMS2D(12, 20, 44.2);     // 12.345611...
            double d2 = DMSHemisferio2D(43, 16, 1.2, 'N');         // 43.267...
            double d3 = DMm2D(-3, 59.94);             // -3.999
            double d4 = DMmHemisferio2D(2, 55.406, 'W');           // -2.923433...

            return test;
        }
    }
}

