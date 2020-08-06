namespace Hornik_Lojza
{
    partial class Menuform
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
            this.components = new System.ComponentModel.Container();
            this.novaHra_tlacitko = new System.Windows.Forms.Button();
            this.nastaveni_tlacitko = new System.Windows.Forms.Button();
            this.tutorial_tlacitko = new System.Windows.Forms.Button();
            this.Ukoncit_tlacitko = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.zpatkytlacitko = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // novaHra_tlacitko
            // 
            this.novaHra_tlacitko.Location = new System.Drawing.Point(81, 12);
            this.novaHra_tlacitko.Name = "novaHra_tlacitko";
            this.novaHra_tlacitko.Size = new System.Drawing.Size(306, 57);
            this.novaHra_tlacitko.TabIndex = 0;
            this.novaHra_tlacitko.Text = "Nová hra";
            this.novaHra_tlacitko.UseVisualStyleBackColor = true;
            this.novaHra_tlacitko.Click += new System.EventHandler(this.novaHra_tlacitko_Click);
            // 
            // nastaveni_tlacitko
            // 
            this.nastaveni_tlacitko.Location = new System.Drawing.Point(81, 75);
            this.nastaveni_tlacitko.Name = "nastaveni_tlacitko";
            this.nastaveni_tlacitko.Size = new System.Drawing.Size(306, 57);
            this.nastaveni_tlacitko.TabIndex = 1;
            this.nastaveni_tlacitko.Text = "Nastavení";
            this.nastaveni_tlacitko.UseVisualStyleBackColor = true;
            this.nastaveni_tlacitko.Click += new System.EventHandler(this.nastaveni_tlacitko_Click);
            // 
            // tutorial_tlacitko
            // 
            this.tutorial_tlacitko.Location = new System.Drawing.Point(81, 138);
            this.tutorial_tlacitko.Name = "tutorial_tlacitko";
            this.tutorial_tlacitko.Size = new System.Drawing.Size(306, 57);
            this.tutorial_tlacitko.TabIndex = 2;
            this.tutorial_tlacitko.Text = "Tutoriál";
            this.tutorial_tlacitko.UseVisualStyleBackColor = true;
            this.tutorial_tlacitko.Click += new System.EventHandler(this.tutorial_tlacitko_Click);
            // 
            // Ukoncit_tlacitko
            // 
            this.Ukoncit_tlacitko.Location = new System.Drawing.Point(81, 201);
            this.Ukoncit_tlacitko.Name = "Ukoncit_tlacitko";
            this.Ukoncit_tlacitko.Size = new System.Drawing.Size(306, 57);
            this.Ukoncit_tlacitko.TabIndex = 3;
            this.Ukoncit_tlacitko.Text = "Ukončit";
            this.Ukoncit_tlacitko.UseVisualStyleBackColor = true;
            this.Ukoncit_tlacitko.Click += new System.EventHandler(this.Ukoncit_tlacitko_Click);
            // 
            // zpatkytlacitko
            // 
            this.zpatkytlacitko.Location = new System.Drawing.Point(380, 303);
            this.zpatkytlacitko.Name = "zpatkytlacitko";
            this.zpatkytlacitko.Size = new System.Drawing.Size(90, 29);
            this.zpatkytlacitko.TabIndex = 4;
            this.zpatkytlacitko.Text = "Zpátky";
            this.zpatkytlacitko.UseVisualStyleBackColor = true;
            this.zpatkytlacitko.Visible = false;
            this.zpatkytlacitko.Click += new System.EventHandler(this.zpatkytlacitko_Click);
            // 
            // Menuform
            // 
            this.AcceptButton = this.novaHra_tlacitko;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(482, 344);
            this.ControlBox = false;
            this.Controls.Add(this.zpatkytlacitko);
            this.Controls.Add(this.Ukoncit_tlacitko);
            this.Controls.Add(this.tutorial_tlacitko);
            this.Controls.Add(this.nastaveni_tlacitko);
            this.Controls.Add(this.novaHra_tlacitko);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimumSize = new System.Drawing.Size(100, 350);
            this.Name = "Menuform";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hlavní menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button novaHra_tlacitko;
        private System.Windows.Forms.Button nastaveni_tlacitko;
        private System.Windows.Forms.Button tutorial_tlacitko;
        private System.Windows.Forms.Button Ukoncit_tlacitko;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Button zpatkytlacitko;
    }
}