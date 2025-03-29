namespace IDM.Key
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnFreeze = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.richSalida = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnActivate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReadme = new System.Windows.Forms.Button();
            this.btnLanguage = new System.Windows.Forms.Button();
            this.contextLang = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.contextLang.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFreeze
            // 
            this.btnFreeze.Enabled = false;
            this.btnFreeze.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFreeze.Location = new System.Drawing.Point(187, 36);
            this.btnFreeze.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFreeze.Name = "btnFreeze";
            this.btnFreeze.Size = new System.Drawing.Size(112, 27);
            this.btnFreeze.TabIndex = 6;
            this.btnFreeze.Text = "Freeze trial";
            this.btnFreeze.UseVisualStyleBackColor = true;
            this.btnFreeze.Click += new System.EventHandler(this.btnFreeze_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(305, 201);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // richSalida
            // 
            this.richSalida.BackColor = System.Drawing.Color.Black;
            this.richSalida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richSalida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richSalida.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richSalida.ForeColor = System.Drawing.Color.White;
            this.richSalida.Location = new System.Drawing.Point(0, 0);
            this.richSalida.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.richSalida.Name = "richSalida";
            this.richSalida.ReadOnly = true;
            this.richSalida.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richSalida.ShortcutsEnabled = false;
            this.richSalida.Size = new System.Drawing.Size(384, 139);
            this.richSalida.TabIndex = 1;
            this.richSalida.Text = "\n\nReady";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 25);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.richSalida);
            this.panel2.Location = new System.Drawing.Point(10, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 139);
            this.panel2.TabIndex = 9;
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReset.Location = new System.Drawing.Point(10, 36);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(169, 27);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset trial / activation";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.Enabled = false;
            this.btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnActivate.Location = new System.Drawing.Point(307, 36);
            this.btnActivate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(88, 27);
            this.btnActivate.TabIndex = 11;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Options menu";
            // 
            // btnReadme
            // 
            this.btnReadme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReadme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReadme.Location = new System.Drawing.Point(13, 201);
            this.btnReadme.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReadme.Name = "btnReadme";
            this.btnReadme.Size = new System.Drawing.Size(88, 27);
            this.btnReadme.TabIndex = 13;
            this.btnReadme.Text = "Readme";
            this.btnReadme.UseVisualStyleBackColor = true;
            this.btnReadme.Click += new System.EventHandler(this.btnReadme_Click);
            // 
            // btnLanguage
            // 
            this.btnLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLanguage.ContextMenuStrip = this.contextLang;
            this.btnLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLanguage.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15F);
            this.btnLanguage.Location = new System.Drawing.Point(109, 201);
            this.btnLanguage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(27, 27);
            this.btnLanguage.TabIndex = 14;
            this.btnLanguage.Text = "";
            this.btnLanguage.UseVisualStyleBackColor = true;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // contextLang
            // 
            this.contextLang.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.españolToolStripMenuItem});
            this.contextLang.Name = "contextLang";
            this.contextLang.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextLang.Size = new System.Drawing.Size(139, 48);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.englishToolStripMenuItem.Text = "English [EN]";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // españolToolStripMenuItem
            // 
            this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            this.españolToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.españolToolStripMenuItem.Text = "Español [ES]";
            this.españolToolStripMenuItem.Click += new System.EventHandler(this.españolToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 240);
            this.Controls.Add(this.btnLanguage);
            this.Controls.Add(this.btnReadme);
            this.Controls.Add(this.btnFreeze);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.contextLang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFreeze;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.RichTextBox richSalida;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReadme;
        private System.Windows.Forms.Button btnLanguage;
        private System.Windows.Forms.ContextMenuStrip contextLang;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
    }
}

