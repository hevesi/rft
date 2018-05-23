namespace MoziKliens
{
    partial class NewMovieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_cim = new System.Windows.Forms.TextBox();
            this.tb_mufaj = new System.Windows.Forms.TextBox();
            this.tb_hossz = new System.Windows.Forms.TextBox();
            this.tb_rendezo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_cim
            // 
            this.tb_cim.Location = new System.Drawing.Point(12, 38);
            this.tb_cim.Name = "tb_cim";
            this.tb_cim.Size = new System.Drawing.Size(119, 20);
            this.tb_cim.TabIndex = 0;
            // 
            // tb_mufaj
            // 
            this.tb_mufaj.Location = new System.Drawing.Point(148, 38);
            this.tb_mufaj.Name = "tb_mufaj";
            this.tb_mufaj.Size = new System.Drawing.Size(94, 20);
            this.tb_mufaj.TabIndex = 1;
            // 
            // tb_hossz
            // 
            this.tb_hossz.Location = new System.Drawing.Point(258, 38);
            this.tb_hossz.Name = "tb_hossz";
            this.tb_hossz.Size = new System.Drawing.Size(94, 20);
            this.tb_hossz.TabIndex = 2;
            // 
            // tb_rendezo
            // 
            this.tb_rendezo.Location = new System.Drawing.Point(376, 38);
            this.tb_rendezo.Name = "tb_rendezo";
            this.tb_rendezo.Size = new System.Drawing.Size(94, 20);
            this.tb_rendezo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cím(kötelező)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Műfaj";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hossz(perc)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rendező";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(167, 90);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 8;
            this.button_Add.Text = "Hozzáadás";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(258, 90);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 9;
            this.button_Exit.Text = "Kilépés";
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // NewMovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 146);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_rendezo);
            this.Controls.Add(this.tb_hossz);
            this.Controls.Add(this.tb_mufaj);
            this.Controls.Add(this.tb_cim);
            this.Name = "NewMovieForm";
            this.Text = "Új film";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_cim;
        private System.Windows.Forms.TextBox tb_mufaj;
        private System.Windows.Forms.TextBox tb_hossz;
        private System.Windows.Forms.TextBox tb_rendezo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Exit;
    }
}