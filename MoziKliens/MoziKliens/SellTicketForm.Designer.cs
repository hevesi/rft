namespace MoziKliens
{
    partial class SellTicketForm
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
            this.tb_EloadasId = new System.Windows.Forms.TextBox();
            this.tb_Darab = new System.Windows.Forms.TextBox();
            this.ElőadásId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eladottJegyekMegtekintéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_EloadasId
            // 
            this.tb_EloadasId.Location = new System.Drawing.Point(12, 54);
            this.tb_EloadasId.Name = "tb_EloadasId";
            this.tb_EloadasId.Size = new System.Drawing.Size(100, 20);
            this.tb_EloadasId.TabIndex = 0;
            // 
            // tb_Darab
            // 
            this.tb_Darab.Location = new System.Drawing.Point(118, 54);
            this.tb_Darab.Name = "tb_Darab";
            this.tb_Darab.Size = new System.Drawing.Size(100, 20);
            this.tb_Darab.TabIndex = 1;
            // 
            // ElőadásId
            // 
            this.ElőadásId.AutoSize = true;
            this.ElőadásId.Location = new System.Drawing.Point(13, 35);
            this.ElőadásId.Name = "ElőadásId";
            this.ElőadásId.Size = new System.Drawing.Size(59, 13);
            this.ElőadásId.TabIndex = 2;
            this.ElőadásId.Text = "Előadás ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Darabszám";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Jegy(ek) eladása";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Bezárás";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eladottJegyekMegtekintéseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(272, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eladottJegyekMegtekintéseToolStripMenuItem
            // 
            this.eladottJegyekMegtekintéseToolStripMenuItem.Name = "eladottJegyekMegtekintéseToolStripMenuItem";
            this.eladottJegyekMegtekintéseToolStripMenuItem.Size = new System.Drawing.Size(167, 20);
            this.eladottJegyekMegtekintéseToolStripMenuItem.Text = "Eladott jegyek megtekintése";
            this.eladottJegyekMegtekintéseToolStripMenuItem.Click += new System.EventHandler(this.eladottJegyekMegtekintéseToolStripMenuItem_Click);
            // 
            // SellTicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 188);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ElőadásId);
            this.Controls.Add(this.tb_Darab);
            this.Controls.Add(this.tb_EloadasId);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SellTicketForm";
            this.Text = "Jegy eladása";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_EloadasId;
        private System.Windows.Forms.TextBox tb_Darab;
        private System.Windows.Forms.Label ElőadásId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eladottJegyekMegtekintéseToolStripMenuItem;
    }
}