namespace Ciris
{
    partial class Ciris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ciris));
            this.toggle = new System.Windows.Forms.Button();
            this.prot = new System.Windows.Forms.Button();
            this.deut = new System.Windows.Forms.Button();
            this.trit = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toggle
            // 
            this.toggle.BackColor = System.Drawing.Color.BurlyWood;
            this.toggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.toggle.FlatAppearance.BorderSize = 0;
            this.toggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggle.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggle.ForeColor = System.Drawing.Color.White;
            this.toggle.Location = new System.Drawing.Point(0, 0);
            this.toggle.Margin = new System.Windows.Forms.Padding(0);
            this.toggle.Name = "toggle";
            this.toggle.Size = new System.Drawing.Size(569, 53);
            this.toggle.TabIndex = 0;
            this.toggle.Text = "Toggle";
            this.toggle.UseVisualStyleBackColor = false;
            this.toggle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.toggleButton);
            // 
            // prot
            // 
            this.prot.BackColor = System.Drawing.Color.Silver;
            this.prot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.prot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prot.FlatAppearance.BorderSize = 0;
            this.prot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prot.ForeColor = System.Drawing.Color.White;
            this.prot.Location = new System.Drawing.Point(0, 0);
            this.prot.Margin = new System.Windows.Forms.Padding(0);
            this.prot.Name = "prot";
            this.prot.Size = new System.Drawing.Size(107, 91);
            this.prot.TabIndex = 0;
            this.prot.Text = "Protanopia";
            this.prot.UseVisualStyleBackColor = false;
            this.prot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setProtanopiaButton);
            // 
            // deut
            // 
            this.deut.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.deut.BackColor = System.Drawing.Color.Silver;
            this.deut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deut.FlatAppearance.BorderSize = 0;
            this.deut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deut.ForeColor = System.Drawing.Color.White;
            this.deut.Location = new System.Drawing.Point(0, 91);
            this.deut.Margin = new System.Windows.Forms.Padding(0);
            this.deut.Name = "deut";
            this.deut.Size = new System.Drawing.Size(107, 91);
            this.deut.TabIndex = 1;
            this.deut.Text = "Deutranopia";
            this.deut.UseMnemonic = false;
            this.deut.UseVisualStyleBackColor = false;
            this.deut.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setDeutranopiaButton);
            // 
            // trit
            // 
            this.trit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.trit.BackColor = System.Drawing.Color.Silver;
            this.trit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.trit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trit.FlatAppearance.BorderSize = 0;
            this.trit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trit.ForeColor = System.Drawing.Color.White;
            this.trit.Location = new System.Drawing.Point(0, 182);
            this.trit.Margin = new System.Windows.Forms.Padding(0);
            this.trit.Name = "trit";
            this.trit.Size = new System.Drawing.Size(107, 92);
            this.trit.TabIndex = 2;
            this.trit.Text = "Tritanopia";
            this.trit.UseVisualStyleBackColor = false;
            this.trit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setTritanopiaButton);
            // 
            // leftPanel
            // 
            this.leftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftPanel.Controls.Add(this.prot);
            this.leftPanel.Controls.Add(this.deut);
            this.leftPanel.Controls.Add(this.trit);
            this.leftPanel.Location = new System.Drawing.Point(0, 53);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.leftPanel.Size = new System.Drawing.Size(107, 274);
            this.leftPanel.TabIndex = 1;
            // 
            // Ciris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(569, 327);
            this.Controls.Add(this.toggle);
            this.Controls.Add(this.leftPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ciris";
            this.Text = "Ciris";
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toggle;
        private System.Windows.Forms.Button prot;
        private System.Windows.Forms.Button deut;
        private System.Windows.Forms.Button trit;
        private System.Windows.Forms.TableLayoutPanel leftPanel;

    }
}