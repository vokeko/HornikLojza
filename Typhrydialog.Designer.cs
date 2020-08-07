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
            this.potvrd_tlacitko = new System.Windows.Forms.Button();
            this.tick_trackbar = new System.Windows.Forms.TrackBar();
            this.rychlost_label = new System.Windows.Forms.Label();
            this.kamenu_label = new System.Windows.Forms.Label();
            this.rychlostpadani_textbox = new System.Windows.Forms.TextBox();
            this.Kamenu_trackbar = new System.Windows.Forms.TrackBar();
            this.kamenu_textbox = new System.Windows.Forms.TextBox();
            this.drahokamu_trackbar = new System.Windows.Forms.TrackBar();
            this.drahokamu_textbox = new System.Windows.Forms.TextBox();
            this.drahokamu_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tick_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kamenu_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drahokamu_trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // standartihra_tlacitko
            // 
            this.standartihra_tlacitko.Location = new System.Drawing.Point(63, 50);
            this.standartihra_tlacitko.Name = "standartihra_tlacitko";
            this.standartihra_tlacitko.Size = new System.Drawing.Size(253, 58);
            this.standartihra_tlacitko.TabIndex = 0;
            this.standartihra_tlacitko.Text = "Standartní hra";
            this.standartihra_tlacitko.UseVisualStyleBackColor = true;
            this.standartihra_tlacitko.Click += new System.EventHandler(this.standartihra_tlacitko_Click);
            // 
            // vlastnihra_tlacitko
            // 
            this.vlastnihra_tlacitko.Location = new System.Drawing.Point(63, 143);
            this.vlastnihra_tlacitko.Name = "vlastnihra_tlacitko";
            this.vlastnihra_tlacitko.Size = new System.Drawing.Size(253, 58);
            this.vlastnihra_tlacitko.TabIndex = 1;
            this.vlastnihra_tlacitko.Text = "Vlastní hra";
            this.vlastnihra_tlacitko.UseVisualStyleBackColor = true;
            this.vlastnihra_tlacitko.Click += new System.EventHandler(this.vlastnihra_tlacitko_Click);
            // 
            // vratitse_tlacitko
            // 
            this.vratitse_tlacitko.Location = new System.Drawing.Point(262, 263);
            this.vratitse_tlacitko.Name = "vratitse_tlacitko";
            this.vratitse_tlacitko.Size = new System.Drawing.Size(105, 28);
            this.vratitse_tlacitko.TabIndex = 2;
            this.vratitse_tlacitko.Text = "Vrátit se";
            this.vratitse_tlacitko.UseVisualStyleBackColor = true;
            this.vratitse_tlacitko.Click += new System.EventHandler(this.vratitse_tlacitko_Click);
            // 
            // potvrd_tlacitko
            // 
            this.potvrd_tlacitko.Location = new System.Drawing.Point(12, 263);
            this.potvrd_tlacitko.Name = "potvrd_tlacitko";
            this.potvrd_tlacitko.Size = new System.Drawing.Size(108, 28);
            this.potvrd_tlacitko.TabIndex = 3;
            this.potvrd_tlacitko.Text = "Potvrdit";
            this.potvrd_tlacitko.UseVisualStyleBackColor = true;
            this.potvrd_tlacitko.Click += new System.EventHandler(this.potvrd_tlacitko_Click);
            // 
            // tick_trackbar
            // 
            this.tick_trackbar.Location = new System.Drawing.Point(12, 32);
            this.tick_trackbar.Maximum = 2000;
            this.tick_trackbar.Minimum = 10;
            this.tick_trackbar.Name = "tick_trackbar";
            this.tick_trackbar.Size = new System.Drawing.Size(104, 56);
            this.tick_trackbar.SmallChange = 25;
            this.tick_trackbar.TabIndex = 4;
            this.tick_trackbar.TickFrequency = 200;
            this.tick_trackbar.Value = 125;
            this.tick_trackbar.Scroll += new System.EventHandler(this.tick_trackbar_Scroll);
            // 
            // rychlost_label
            // 
            this.rychlost_label.AutoSize = true;
            this.rychlost_label.Location = new System.Drawing.Point(12, 11);
            this.rychlost_label.Name = "rychlost_label";
            this.rychlost_label.Size = new System.Drawing.Size(163, 17);
            this.rychlost_label.TabIndex = 5;
            this.rychlost_label.Text = "Rychlost padání kamenů";
            // 
            // kamenu_label
            // 
            this.kamenu_label.AutoSize = true;
            this.kamenu_label.Location = new System.Drawing.Point(12, 71);
            this.kamenu_label.Name = "kamenu_label";
            this.kamenu_label.Size = new System.Drawing.Size(98, 17);
            this.kamenu_label.TabIndex = 6;
            this.kamenu_label.Text = "Počet kamenů";
            // 
            // rychlostpadani_textbox
            // 
            this.rychlostpadani_textbox.Location = new System.Drawing.Point(122, 32);
            this.rychlostpadani_textbox.Name = "rychlostpadani_textbox";
            this.rychlostpadani_textbox.ReadOnly = true;
            this.rychlostpadani_textbox.Size = new System.Drawing.Size(39, 22);
            this.rychlostpadani_textbox.TabIndex = 7;
            // 
            // Kamenu_trackbar
            // 
            this.Kamenu_trackbar.Location = new System.Drawing.Point(12, 90);
            this.Kamenu_trackbar.Maximum = 50;
            this.Kamenu_trackbar.Name = "Kamenu_trackbar";
            this.Kamenu_trackbar.Size = new System.Drawing.Size(104, 56);
            this.Kamenu_trackbar.SmallChange = 25;
            this.Kamenu_trackbar.TabIndex = 8;
            this.Kamenu_trackbar.TickFrequency = 5;
            this.Kamenu_trackbar.Value = 30;
            this.Kamenu_trackbar.Scroll += new System.EventHandler(this.Kamenu_trackbar_Scroll);
            // 
            // kamenu_textbox
            // 
            this.kamenu_textbox.Location = new System.Drawing.Point(122, 90);
            this.kamenu_textbox.Name = "kamenu_textbox";
            this.kamenu_textbox.ReadOnly = true;
            this.kamenu_textbox.Size = new System.Drawing.Size(39, 22);
            this.kamenu_textbox.TabIndex = 9;
            // 
            // drahokamu_trackbar
            // 
            this.drahokamu_trackbar.Location = new System.Drawing.Point(16, 152);
            this.drahokamu_trackbar.Maximum = 30;
            this.drahokamu_trackbar.Name = "drahokamu_trackbar";
            this.drahokamu_trackbar.Size = new System.Drawing.Size(104, 56);
            this.drahokamu_trackbar.SmallChange = 25;
            this.drahokamu_trackbar.TabIndex = 10;
            this.drahokamu_trackbar.TickFrequency = 3;
            this.drahokamu_trackbar.Value = 10;
            this.drahokamu_trackbar.Scroll += new System.EventHandler(this.drahokamu_trackbar_Scroll);
            // 
            // drahokamu_textbox
            // 
            this.drahokamu_textbox.Location = new System.Drawing.Point(122, 143);
            this.drahokamu_textbox.Name = "drahokamu_textbox";
            this.drahokamu_textbox.ReadOnly = true;
            this.drahokamu_textbox.Size = new System.Drawing.Size(39, 22);
            this.drahokamu_textbox.TabIndex = 11;
            // 
            // drahokamu_label
            // 
            this.drahokamu_label.AutoSize = true;
            this.drahokamu_label.Location = new System.Drawing.Point(12, 123);
            this.drahokamu_label.Name = "drahokamu_label";
            this.drahokamu_label.Size = new System.Drawing.Size(119, 17);
            this.drahokamu_label.TabIndex = 12;
            this.drahokamu_label.Text = "Počet drahokamů";
            // 
            // Typhrydialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 303);
            this.ControlBox = false;
            this.Controls.Add(this.drahokamu_label);
            this.Controls.Add(this.drahokamu_textbox);
            this.Controls.Add(this.drahokamu_trackbar);
            this.Controls.Add(this.kamenu_textbox);
            this.Controls.Add(this.Kamenu_trackbar);
            this.Controls.Add(this.rychlostpadani_textbox);
            this.Controls.Add(this.kamenu_label);
            this.Controls.Add(this.rychlost_label);
            this.Controls.Add(this.tick_trackbar);
            this.Controls.Add(this.potvrd_tlacitko);
            this.Controls.Add(this.vratitse_tlacitko);
            this.Controls.Add(this.vlastnihra_tlacitko);
            this.Controls.Add(this.standartihra_tlacitko);
            this.Name = "Typhrydialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typhrydialog";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Typhrydialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tick_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kamenu_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drahokamu_trackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button standartihra_tlacitko;
        private System.Windows.Forms.Button vlastnihra_tlacitko;
        private System.Windows.Forms.Button vratitse_tlacitko;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button potvrd_tlacitko;
        private System.Windows.Forms.TrackBar tick_trackbar;
        private System.Windows.Forms.Label rychlost_label;
        private System.Windows.Forms.Label kamenu_label;
        private System.Windows.Forms.TextBox rychlostpadani_textbox;
        private System.Windows.Forms.TrackBar Kamenu_trackbar;
        private System.Windows.Forms.TextBox kamenu_textbox;
        private System.Windows.Forms.TrackBar drahokamu_trackbar;
        private System.Windows.Forms.TextBox drahokamu_textbox;
        private System.Windows.Forms.Label drahokamu_label;
    }
}