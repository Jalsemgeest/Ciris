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
            this.selectedProfile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.activated = new System.Windows.Forms.Label();
            this.strengthBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setPower = new System.Windows.Forms.Label();
            this.applyProfile = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.trit = new System.Windows.Forms.Button();
            this.deut = new System.Windows.Forms.Button();
            this.prot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.strengthBar)).BeginInit();
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
            // selectedProfile
            // 
            this.selectedProfile.AutoSize = true;
            this.selectedProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedProfile.Location = new System.Drawing.Point(240, 298);
            this.selectedProfile.Name = "selectedProfile";
            this.selectedProfile.Size = new System.Drawing.Size(86, 20);
            this.selectedProfile.TabIndex = 2;
            this.selectedProfile.Text = "Protanopia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selected Profile:";
            // 
            // activated
            // 
            this.activated.AutoSize = true;
            this.activated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activated.ForeColor = System.Drawing.Color.Green;
            this.activated.Location = new System.Drawing.Point(386, 298);
            this.activated.Name = "activated";
            this.activated.Size = new System.Drawing.Size(32, 20);
            this.activated.TabIndex = 4;
            this.activated.Text = "ON";
            // 
            // strengthBar
            // 
            this.strengthBar.Location = new System.Drawing.Point(512, 78);
            this.strengthBar.Maximum = 100;
            this.strengthBar.Name = "strengthBar";
            this.strengthBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.strengthBar.Size = new System.Drawing.Size(45, 168);
            this.strengthBar.TabIndex = 8;
            this.strengthBar.TickFrequency = 10;
            this.strengthBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.strengthBar.Value = 60;
            this.strengthBar.ValueChanged += new System.EventHandler(this.strengthChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Strong";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Off";
            // 
            // setPower
            // 
            this.setPower.AutoSize = true;
            this.setPower.Location = new System.Drawing.Point(499, 179);
            this.setPower.Name = "setPower";
            this.setPower.Size = new System.Drawing.Size(27, 13);
            this.setPower.TabIndex = 9;
            this.setPower.Text = "60%";
            // 
            // applyProfile
            // 
            this.applyProfile.Enabled = false;
            this.applyProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyProfile.Location = new System.Drawing.Point(502, 279);
            this.applyProfile.Name = "applyProfile";
            this.applyProfile.Size = new System.Drawing.Size(67, 48);
            this.applyProfile.TabIndex = 10;
            this.applyProfile.Text = "Apply";
            this.applyProfile.UseVisualStyleBackColor = true;
            this.applyProfile.Click += new System.EventHandler(this.applyProfile_Click);
            // 
            // leftPanel
            // 
            this.leftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
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
            // Ciris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(569, 327);
            this.Controls.Add(this.applyProfile);
            this.Controls.Add(this.setPower);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.strengthBar);
            this.Controls.Add(this.activated);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectedProfile);
            this.Controls.Add(this.toggle);
            this.Controls.Add(this.leftPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ciris";
            this.Text = "Ciris";
            ((System.ComponentModel.ISupportInitialize)(this.strengthBar)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button toggle;
        private System.Windows.Forms.Label selectedProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label activated;
        private System.Windows.Forms.TrackBar strengthBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label setPower;
        private System.Windows.Forms.Button applyProfile;
        private System.Windows.Forms.TableLayoutPanel leftPanel;
        private System.Windows.Forms.Button prot;
        private System.Windows.Forms.Button deut;
        private System.Windows.Forms.Button trit;

    }
}