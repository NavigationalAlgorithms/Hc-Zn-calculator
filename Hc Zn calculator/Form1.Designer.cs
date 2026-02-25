namespace Hc_Zn_calculator
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            calculate_button = new Button();
            label1 = new Label();
            B_textBox = new TextBox();
            L_textBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            Dec_textBox = new TextBox();
            label4 = new Label();
            GHA_textBox = new TextBox();
            output_textBox = new TextBox();
            Table_hv_button = new Button();
            SuspendLayout();
            // 
            // calculate_button
            // 
            calculate_button.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            calculate_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            calculate_button.Location = new Point(15, 196);
            calculate_button.Margin = new Padding(4, 3, 4, 3);
            calculate_button.Name = "calculate_button";
            calculate_button.Size = new Size(318, 43);
            calculate_button.TabIndex = 8;
            calculate_button.Text = "Calculate";
            calculate_button.UseVisualStyleBackColor = true;
            calculate_button.Click += Calculate_button_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 0;
            label1.Text = "B - Latitude +N/-S";
            // 
            // B_textBox
            // 
            B_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            B_textBox.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            B_textBox.Location = new Point(15, 30);
            B_textBox.Margin = new Padding(4, 3, 4, 3);
            B_textBox.Name = "B_textBox";
            B_textBox.Size = new Size(318, 23);
            B_textBox.TabIndex = 1;
            B_textBox.Text = "43.31666667";
            // 
            // L_textBox
            // 
            L_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            L_textBox.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            L_textBox.Location = new Point(14, 75);
            L_textBox.Margin = new Padding(4, 3, 4, 3);
            L_textBox.Name = "L_textBox";
            L_textBox.Size = new Size(319, 23);
            L_textBox.TabIndex = 3;
            L_textBox.Text = "-2.0";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(14, 57);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 2;
            label2.Text = "L - Longitude +E/-W";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(14, 102);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 4;
            label3.Text = "Dec - Declination +N/-S";
            // 
            // Dec_textBox
            // 
            Dec_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Dec_textBox.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Dec_textBox.Location = new Point(15, 120);
            Dec_textBox.Margin = new Padding(4, 3, 4, 3);
            Dec_textBox.Name = "Dec_textBox";
            Dec_textBox.Size = new Size(318, 23);
            Dec_textBox.TabIndex = 5;
            Dec_textBox.Text = "8.211666667";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(14, 147);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(159, 15);
            label4.TabIndex = 6;
            label4.Text = "GHA - Greenwich hour angle";
            // 
            // GHA_textBox
            // 
            GHA_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GHA_textBox.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GHA_textBox.Location = new Point(14, 166);
            GHA_textBox.Margin = new Padding(4, 3, 4, 3);
            GHA_textBox.Name = "GHA_textBox";
            GHA_textBox.Size = new Size(319, 23);
            GHA_textBox.TabIndex = 7;
            GHA_textBox.Text = "347.9733333";
            // 
            // output_textBox
            // 
            output_textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            output_textBox.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            output_textBox.Location = new Point(14, 246);
            output_textBox.Margin = new Padding(4, 3, 4, 3);
            output_textBox.Multiline = true;
            output_textBox.Name = "output_textBox";
            output_textBox.ScrollBars = ScrollBars.Vertical;
            output_textBox.Size = new Size(319, 303);
            output_textBox.TabIndex = 9;
            output_textBox.Text = "LHA - Local hour angle\r\nHc - Altitude (calculated)\r\nZn - Azimut\r\n\r\nhttps://en.wikipedia.org/wiki/Sight_reduction\r\n\r\nNavigational Algorithms\r\nhttp://sites.google.com/site/navigationalalgorithms/";
            // 
            // Table_hv_button
            // 
            Table_hv_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Table_hv_button.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Table_hv_button.Location = new Point(15, 556);
            Table_hv_button.Margin = new Padding(4, 3, 4, 3);
            Table_hv_button.Name = "Table_hv_button";
            Table_hv_button.Size = new Size(318, 43);
            Table_hv_button.TabIndex = 10;
            Table_hv_button.Text = "Table: Haversine, Ageton";
            Table_hv_button.UseVisualStyleBackColor = true;
            Table_hv_button.Visible = false;
            Table_hv_button.Click += Table_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 613);
            Controls.Add(Table_hv_button);
            Controls.Add(output_textBox);
            Controls.Add(GHA_textBox);
            Controls.Add(label4);
            Controls.Add(Dec_textBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(L_textBox);
            Controls.Add(B_textBox);
            Controls.Add(label1);
            Controls.Add(calculate_button);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hc Zn calculator";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calculate_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox B_textBox;
        private System.Windows.Forms.TextBox L_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Dec_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GHA_textBox;
        private System.Windows.Forms.TextBox output_textBox;
        private System.Windows.Forms.Button Table_hv_button;
    }
}

