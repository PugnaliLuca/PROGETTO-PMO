namespace GESTORE_VILLAGGIO
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flwPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSeeCalendar = new System.Windows.Forms.Button();
            this.pnlDropDown = new System.Windows.Forms.Panel();
            this.btnDeleteBookings = new System.Windows.Forms.Button();
            this.btnAddBookings = new System.Windows.Forms.Button();
            this.btnManageBookings = new System.Windows.Forms.Button();
            this.ucAddBookings1 = new GESTORE_VILLAGGIO.UCAddBookings();
            this.ucDeleteBookings1 = new GESTORE_VILLAGGIO.UCDeleteBookings();
            this.ucSeeCalendar1 = new GESTORE_VILLAGGIO.UCSeeCalendar();
            this.flwPanelMenu.SuspendLayout();
            this.pnlDropDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // flwPanelMenu
            // 
            this.flwPanelMenu.Controls.Add(this.btnSeeCalendar);
            this.flwPanelMenu.Controls.Add(this.pnlDropDown);
            this.flwPanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.flwPanelMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flwPanelMenu.Location = new System.Drawing.Point(0, 0);
            this.flwPanelMenu.Name = "flwPanelMenu";
            this.flwPanelMenu.Size = new System.Drawing.Size(200, 553);
            this.flwPanelMenu.TabIndex = 0;
            // 
            // btnSeeCalendar
            // 
            this.btnSeeCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSeeCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeeCalendar.Font = new System.Drawing.Font("Century Gothic", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeeCalendar.ForeColor = System.Drawing.Color.Black;
            this.btnSeeCalendar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeeCalendar.Location = new System.Drawing.Point(3, 3);
            this.btnSeeCalendar.Name = "btnSeeCalendar";
            this.btnSeeCalendar.Size = new System.Drawing.Size(197, 71);
            this.btnSeeCalendar.TabIndex = 1;
            this.btnSeeCalendar.Text = "Vedi calendario";
            this.btnSeeCalendar.UseVisualStyleBackColor = false;
            this.btnSeeCalendar.Click += new System.EventHandler(this.btnSeeCalendar_Click);
            // 
            // pnlDropDown
            // 
            this.pnlDropDown.Controls.Add(this.btnDeleteBookings);
            this.pnlDropDown.Controls.Add(this.btnAddBookings);
            this.pnlDropDown.Controls.Add(this.btnManageBookings);
            this.pnlDropDown.Location = new System.Drawing.Point(3, 80);
            this.pnlDropDown.MaximumSize = new System.Drawing.Size(200, 195);
            this.pnlDropDown.MinimumSize = new System.Drawing.Size(200, 73);
            this.pnlDropDown.Name = "pnlDropDown";
            this.pnlDropDown.Size = new System.Drawing.Size(200, 73);
            this.pnlDropDown.TabIndex = 1;
            // 
            // btnDeleteBookings
            // 
            this.btnDeleteBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDeleteBookings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteBookings.Font = new System.Drawing.Font("Century Gothic", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBookings.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteBookings.Location = new System.Drawing.Point(0, 133);
            this.btnDeleteBookings.Name = "btnDeleteBookings";
            this.btnDeleteBookings.Size = new System.Drawing.Size(197, 60);
            this.btnDeleteBookings.TabIndex = 4;
            this.btnDeleteBookings.Text = "Cancella prenotazinoe";
            this.btnDeleteBookings.UseVisualStyleBackColor = false;
            this.btnDeleteBookings.Click += new System.EventHandler(this.btnDeleteBookings_Click);
            // 
            // btnAddBookings
            // 
            this.btnAddBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddBookings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddBookings.Font = new System.Drawing.Font("Century Gothic", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBookings.ForeColor = System.Drawing.Color.Black;
            this.btnAddBookings.Location = new System.Drawing.Point(0, 72);
            this.btnAddBookings.Name = "btnAddBookings";
            this.btnAddBookings.Size = new System.Drawing.Size(197, 60);
            this.btnAddBookings.TabIndex = 3;
            this.btnAddBookings.Text = "Effettua prenotazione";
            this.btnAddBookings.UseVisualStyleBackColor = false;
            this.btnAddBookings.Click += new System.EventHandler(this.btnAddBookings_Click);
            // 
            // btnManageBookings
            // 
            this.btnManageBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnManageBookings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManageBookings.Font = new System.Drawing.Font("Century Gothic", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageBookings.ForeColor = System.Drawing.Color.Black;
            this.btnManageBookings.Location = new System.Drawing.Point(0, 0);
            this.btnManageBookings.Name = "btnManageBookings";
            this.btnManageBookings.Size = new System.Drawing.Size(197, 71);
            this.btnManageBookings.TabIndex = 2;
            this.btnManageBookings.Text = "Gestisci prenotaizoni";
            this.btnManageBookings.UseVisualStyleBackColor = false;
            this.btnManageBookings.Click += new System.EventHandler(this.btnManageBookings_Click);
            // 
            // ucAddBookings1
            // 
            this.ucAddBookings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ucAddBookings1.Form = null;
            this.ucAddBookings1.Location = new System.Drawing.Point(207, 3);
            this.ucAddBookings1.Name = "ucAddBookings1";
            this.ucAddBookings1.Size = new System.Drawing.Size(790, 550);
            this.ucAddBookings1.TabIndex = 2;
            // 
            // ucDeleteBookings1
            // 
            this.ucDeleteBookings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ucDeleteBookings1.Form = null;
            this.ucDeleteBookings1.Location = new System.Drawing.Point(207, 3);
            this.ucDeleteBookings1.Name = "ucDeleteBookings1";
            this.ucDeleteBookings1.Size = new System.Drawing.Size(790, 550);
            this.ucDeleteBookings1.TabIndex = 1;
            // 
            // ucSeeCalendar1
            // 
            this.ucSeeCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ucSeeCalendar1.Form = null;
            this.ucSeeCalendar1.Location = new System.Drawing.Point(207, 3);
            this.ucSeeCalendar1.Name = "ucSeeCalendar1";
            this.ucSeeCalendar1.Size = new System.Drawing.Size(790, 550);
            this.ucSeeCalendar1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1004, 553);
            this.Controls.Add(this.flwPanelMenu);
            this.Controls.Add(this.ucSeeCalendar1);
            this.Controls.Add(this.ucAddBookings1);
            this.Controls.Add(this.ucDeleteBookings1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Gestione Camping";
            this.flwPanelMenu.ResumeLayout(false);
            this.pnlDropDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flwPanelMenu;
        private System.Windows.Forms.Button btnSeeCalendar;
        private System.Windows.Forms.Panel pnlDropDown;
        private System.Windows.Forms.Button btnDeleteBookings;
        private System.Windows.Forms.Button btnAddBookings;
        private System.Windows.Forms.Button btnManageBookings;
        private UCDeleteBookings ucDeleteBookings1;
        private UCAddBookings ucAddBookings1;
        private UCSeeCalendar ucSeeCalendar1;
    }
}

