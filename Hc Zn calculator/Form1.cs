/*
	FILE: Form1.cs
	
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
using System.Windows.Forms;
using NavigationalAlgorithms;


namespace Hc_Zn_calculator
{
    public partial class Form1 : Form
    {
        public static bool flag = true;

        public Form1()
        {
            InitializeComponent();

            if (flag)
            {
                Table_hv_button.Visible = true;
            }
        }

        private void calculate_button_Click(object sender, EventArgs e)
        {
            // data
            double B = Convert.ToDouble(B_textBox.Text);
            double L = Convert.ToDouble(L_textBox.Text);
            double Dec = Convert.ToDouble(Dec_textBox.Text);
            double GHA = Convert.ToDouble(GHA_textBox.Text);

            // calculations
            double LHA = HcZn.LHA(L, GHA);
            double HC  = HcZn.Hc(B, Dec, LHA);
            double ZN  = HcZn.Zn(B, Dec, HC, LHA);

            double Z = HcZn.Z(Dec, LHA, HC);
            double P = HcZn.LHA2MeridianAngle(LHA);

            // results
            output_textBox.Text = "Sight reduction:\r\n";
            output_textBox.Text += "LHA = " + LHA + " º\r\n";
            output_textBox.Text += "Hc  = " + HC + " º\r\n";
            // output_textBox.Text += "Zn  = " + string.Format("{0:N2}", ZN) + " º\r\n";
            output_textBox.Text += "Zn  = " + ZN.ToString("0.0") + " º\r\n";

            if (flag)
            {
                output_textBox.Text += "Z   = " + Z.ToString("0.0") + " º\r\n";
                output_textBox.Text += "t   = " + P + " º\r\n";
                output_textBox.Text += "Z   = " + HcZn.Zstr(Dec, LHA, HC) + " º\r\n";

                HannoDoniolHaversineMethod();

                // test kk
                /*
                UltraCompactHaversineSightReduction.LunarDistanceSD(52.0 + 23.0 / 60.0, 38.0 + 40.0 / 60.0, 30.0 + 36.0 / 60.0);
                UltraCompactHaversineSightReduction.LunarDistanceO(64.0 + 12.9 / 60.0, 38.0 + 38.7 / 60.0, 31.0 + 21.4 / 60.0);
                output_textBox.Text += UltraCompactHaversineSightReduction.logStr;*/
                /*
                double RBA = UltraCompactHaversineSightReduction.LunarDistanceSD(52.0 + 23.2 / 60.0, 38.0 + 39.8 / 60.0, 30.0 + 36.3 / 60.0);
                UltraCompactHaversineSightReduction.LunarDistanceO(RBA, 38.0 + 38.7 / 60.0, 31.0 + 21.4 / 60.0);
                output_textBox.Text += UltraCompactHaversineSightReduction.logStr;*/

                Tuple<double, double> ag = Ageton.HcZn_Ageton(B, L, Dec, GHA);
                output_textBox.Text += "\r\n";
                output_textBox.Text += "Ageton SR\r\n";
                output_textBox.Text += "Hc  = " + ag.Item1 + " º\r\n";
                output_textBox.Text += "Zn  = " + ag.Item2.ToString("0.0") + " º\r\n";

                output_textBox.Text += "\r\n";
                output_textBox.Text += "Ageton.Examples\r\n";
                output_textBox.Text += Ageton.Examples();
            }
        }

        private void HannoDoniolHaversineMethod()
        {
            // data
            double B = Convert.ToDouble(B_textBox.Text);
            double L = Convert.ToDouble(L_textBox.Text);
            double Dec = Convert.ToDouble(Dec_textBox.Text);
            double GHA = Convert.ToDouble(GHA_textBox.Text);

            // calculations
            double LHA = HcZn.LHA(L, GHA);
            double HC = UltraCompactHaversineSightReduction.Hc(B, Dec, LHA);
            double ZN = UltraCompactHaversineSightReduction.Zn(B, Dec, HC, LHA);

            // results
            output_textBox.Text += "\r\n";
            output_textBox.Text += "Ultra Compact Haversine SR:\r\n";
            output_textBox.Text += "Hc  = " + HC + " º\r\n";
            // output_textBox.Text += "Zn  = " + string.Format("{0:N2}", ZN) + " º\r\n";
            output_textBox.Text += "Zn  = " + ZN.ToString("0.0") + " º\r\n";
            output_textBox.Text += UltraCompactHaversineSightReduction.logStr;
            output_textBox.Text += "\r\n";
        }

        private void Table_button_Click(object sender, EventArgs e)
        {
            output_textBox.Text  = UltraCompactHaversineSightReduction.HaversineTable();
            output_textBox.Text += "\r\n";

            output_textBox.Text += "Ageton\r\n";
            output_textBox.Text += Ageton.Table();
        }
    }
}
