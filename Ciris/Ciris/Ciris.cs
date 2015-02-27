using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Ciris
{
    public partial class Ciris : Form
    {

        //private List<KeyValuePair<ProfileKey, ScreenColorEffect>> effects;
        private OverlayManager overlay = null;

        public Ciris()
        {
            // Setting up the overlay connection so we can access the methods from within it.
            overlay = OverlayManager.Instance;

            InitializeComponent();
        }

        private void setColor(String color)
        {
            foreach (var effect in Configuration.Current.ColorEffects)
            {
                if (effect.Value.Description == color)
                {
                    this.overlay.setMatrix(effect.Value);
                }
            }
        }


        #region Event Handlers

        // Sets it to NORMAL.
        private void toggleButton(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Set it to Normal - IE. The Identity Matrix
                this.overlay.toggleColor();
                // Disable the slider.
            }
        }

        private void setProtanopiaButton(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // If it's paused, then set the color on.
                //if (this.overlay.isPaused()) { this.overlay.toggleColor(); }
                // Set it to Protanopia
                setColor("Protanopia2");
                // Enable the slider.
            }
        }

        private void setDeutranopiaButton(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // If it's paused, then set the color on.
                //if (this.overlay.isPaused()) { this.overlay.toggleColor(); }
                // Set it to Deutranopia
                setColor("Protanopia2");
                // Enable the slider...
            }
        }

        private void setTritanopiaButton(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Set it to Tritanopia
                setColor("Tritanopia");

                //System.Threading.Thread.Sleep(80);

                // If it's paused, then set the color on.
                //if (this.overlay.isPaused()) { this.overlay.toggleColor(); }

                // Enable the slider...
            }
        }

        #endregion
    }
}
