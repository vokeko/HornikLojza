namespace Hornik_Lojza
{
    partial class Typhrydialog
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
            this.standartihra_tlacitko = new System.Windows.Forms.Button();
            this.vlastnihra_tlacitko = new System.Windows.Forms.Button();
            this.vratitse_tlacitko = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // standartihra_tlacitko
            // 
            this.standartihra_tlacitko.Location = new System.Drawing.Point(63, 12);
            this.standartihra_tlacitko.Name = "standartihra_tlacitko";
            this.standartihra_tlacitko.Size = new System.Drawing.Size(253, 58);
            this.standartihra_tlacitko.TabIndex = 0;
            this.standartihra_tlacitko.Text = "Standartní hra";
            this.standartihra_tlacitko.UseVisualStyleBackColor = true;
            this.standartihra_tlacitko.Click += new System.EventHandler(this.standartihra_tlacitko_Click);
            // 
            // vlastnihra_tlacitko
            // 
            this.vlastnihra_tlacitko.Location = new System.Drawing.Point(63, 90);
            this.vlastnihra_tlacitko.Name = "vlastnihra_tlacitko";
            this.vlastnihra_tlacitko.Size = new System.Drawing.Size(253, 58);
            this.vlastnihra_tlacitko.TabIndex = 1;
            this.vlastnihra_tlacitko.Text = "Vlastní hra";
            this.vlastnihra_tlacitko.UseVisualStyleBackColor = true;
            this.vlastnihra_tlacitko.Click += new System.EventHandler(this.vlastnihra_tlacitko_Click);
            // 
            // vratitse_tlacitko
            // 
            this.vratitse_tlacitko.Location = new System.Drawing.Point(262, 186);
            this.vratitse_tlacitko.Name = "vratitse_tlacitko";
            this.vratitse_tlacitko.Size = new System.Drawing.Size(105, 28);
            this.vratitse_tlacitko.TabIndex = 2;
            this.vratitse_tlacitko.Text = "Vrátit se";
            this.vratitse_tlacitko.UseVisualStyleBackColor = true;
            this.vratitse_tlacitko.Click += new System.EventHandler(this.vratitse_tlacitko_Click);
            // 
            // Typhrydialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 226);
            this.ControlBox = false;
            this.Controls.Add(this.vratitse_tlacitko);
            this.Controls.Add(this.vlastnihra_tlacitko);
            this.Controls.Add(this.standartihra_tlacitko);
            this.Name = "Typhrydialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typhrydialog";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Typhrydialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button standartihra_tlacitko;
        private System.Windows.Forms.Button vlastnihra_tlacitko;
        private System.Windows.Forms.Button vratitse_tlacitko;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}