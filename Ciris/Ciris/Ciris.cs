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

        private String currentEffect = null;

        private ScreenColorEffect forSlider;

        public Ciris()
        {
            // Setting up the overlay connection so we can access the methods from within it.
            overlay = OverlayManager.Instance;
            currentEffect = "Protanopia";
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

        private void setColor(float[,] matrix, String profile)
        {
            forSlider = new ScreenColorEffect(matrix, profile);
            this.overlay.setMatrix(forSlider);
        }


        #region Event Handlers

        // Sets it to NORMAL.
        private void toggleButton(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Set it to Normal - IE. The Identity Matrix
                this.overlay.toggleColor();
                if (this.overlay.isPaused())
                {
                    activated.Text = "OFF";
                    activated.ForeColor = Color.Red;
                }
                else
                {
                    activated.Text = "ON";
                    activated.ForeColor = Color.Green;
                }
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
                setColor("Protanopia");
                currentEffect = "Protanopia";
                selectedProfile.Text = currentEffect;
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
                setColor("Protanopia");
                currentEffect = "Deutranopia";
                selectedProfile.Text = currentEffect;
                // Enable the slider...
            }
        }

        private void setTritanopiaButton(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // Set it to Tritanopia
                setColor("Tritanopia");
                currentEffect = "Tritanopia";
                selectedProfile.Text = currentEffect;
                //System.Threading.Thread.Sleep(80);

                // If it's paused, then set the color on.
                //if (this.overlay.isPaused()) { this.overlay.toggleColor(); }

                // Enable the slider...
            }
        }

        private void strengthChanged(object sender, System.EventArgs e)
        {
            setPower.Text = strengthBar.Value.ToString()+"%";
            applyProfile.Enabled = true;


            Configuration.Current.SmoothTransitions = false;

            applyProfile.Enabled = false;

            activated.Text = currentEffect;

            float upper = ((float)strengthBar.Value) / 100;
            float lower = 1.0f - (((float)strengthBar.Value) / 100);

            float[,] matrix;

            if (currentEffect.Equals("Protanopia"))
            {
                matrix = new float[,] {
                {  1.0f,  0.0f,  upper,  0.0f,  0.0f },
                {  0.0f,  1.0f,  0.0f,  0.0f,  0.0f },
                {  0.0f,  0.0f,  lower,  0.0f,  0.0f },
                {  0.0f,  0.0f,  0.0f,  1.0f,  0.0f },
                {  0.0f,  0.0f,  0.0f,  0.0f,  1.0f }};
            }
            else if (currentEffect.Equals("Deutranopia"))
            {
                matrix = new float[,] {
                {  1.0f,  0.0f,  upper,  0.0f,  0.0f },
                {  0.0f,  1.0f,  0.0f,  0.0f,  0.0f },
                {  0.0f,  0.0f,  lower,  0.0f,  0.0f },
                {  0.0f,  0.0f,  0.0f,  1.0f,  0.0f },
                {  0.0f,  0.0f,  0.0f,  0.0f,  1.0f }};
            }
            else
            {
                matrix = new float[,] {
                {  1.0f,  0.0f,  0.0f,  0.0f,  0.0f },
                { -(0.1f * upper), 1.0f(lower - (-0.1f * upper)), -(0.1f*upper),  0.0f,  0.0f },
                {  0.0f,  upper,  1.0f,  0.0f,  0.0f},
                {  0.0f,  0.0f,  0.0f,  1.0f,  0.0f },
                {  0.0f, 0.0f,  0.0f,  0.0f,  1.0f }};
            }

            setColor(matrix, "Protanopia");


            Configuration.Current.SmoothTransitions = true;

        }

        #endregion

        private void applyProfile_Click(object sender, EventArgs e)
        {
            Configuration.Current.SmoothTransitions = false;

            applyProfile.Enabled = false;

            activated.Text = currentEffect;

            float upper = ((float)strengthBar.Value) / 100;
            float lower = 1.0f - (((float)strengthBar.Value) / 100);

            float[,] matrix;

            if (currentEffect.Equals("Protanopia"))
            {
                matrix = new float[,] {
                {  1.0f,  0.0f,  upper,  0.0f,  0.0f },
                {  0.0f,  1.0f,  0.0f,  0.0f,  0.0f },
                {  0.0f,  0.0f,  lower,  0.0f,  0.0f },
                {  0.0f,  0.0f,  0.0f,  1.0f,  0.0f },
                {  0.0f,  0.0f,  0.0f,  0.0f,  1.0f }};
            }
            else if (currentEffect.Equals("Deutranopia"))
            {
                matrix = new float[,] {
                {  1.0f,  0.0f,  upper,  0.0f,  0.0f },
                {  0.0f,  1.0f,  0.0f,  0.0f,  0.0f },
                {  0.0f,  0.0f,  lower,  0.0f,  0.0f },
                {  0.0f,  0.0f,  0.0f,  1.0f,  0.0f },
                {  0.0f,  0.0f,  0.0f,  0.0f,  1.0f }};
            }
            else
            {
                matrix = new float[,] {
                {  1.0f,  0.0f,  0.0f,  0.0f,  0.0f },
                { -0.1f, -0.1f, -0.1f,  0.0f,  0.0f },
                {  0.0f,  1.0f,  1.0f,  0.0f,  0.0f},
                {  0.0f,  0.0f,  0.0f,  1.0f,  0.0f },
                {  0.0f, 0.0f,  0.0f,  0.0f,  1.0f }};
            }
            
            setColor(matrix, "Protanopia");


            Configuration.Current.SmoothTransitions = true;

        }
    }
}
