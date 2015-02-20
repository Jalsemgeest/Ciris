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
            // Getting the icon and setting it.
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ciris));
            this.Text = "Ciris";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("mainIcon")));

            // Instantiating the buttons
            this.toggle = new System.Windows.Forms.Button();
            this.prot = new System.Windows.Forms.Button();
            this.deut = new System.Windows.Forms.Button();
            this.trit = new System.Windows.Forms.Button();

            // Suspending the layout so we can add buttons.
            this.SuspendLayout();
            //
            // Normal Button
            this.toggle.Text = "Toggle";
            this.toggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggle.Location = new System.Drawing.Point(0, 0);
            this.toggle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.toggleButton);
            this.Controls.Add(this.toggle);
            //
            // Protanopia Button
            //
            this.prot.Text = "Protanopia";
            this.prot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.prot.Location = new System.Drawing.Point(0, 22);
            this.prot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setProtanopiaButton);
            this.Controls.Add(this.prot);
            //
            // Deutranopia Button
            //
            this.deut.Text = "Deutranopia";
            this.deut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deut.Location = new System.Drawing.Point(0, 44);
            this.deut.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setDeutranopiaButton);
            this.Controls.Add(this.deut);
            //
            // Tritanopia Button
            //
            this.trit.Text = "Tritanopia";
            this.trit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.trit.Location = new System.Drawing.Point(0, 66);
            this.trit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.setTritanopiaButton);
            this.Controls.Add(this.trit);
            //
            //
            this.ResumeLayout();
        }

        #endregion

        private System.Windows.Forms.Button toggle;
        private System.Windows.Forms.Button prot;
        private System.Windows.Forms.Button deut;
        private System.Windows.Forms.Button trit;

    }
}