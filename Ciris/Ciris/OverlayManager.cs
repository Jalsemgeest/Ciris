﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Concurrent;


// TODO
// Remove the registration of Hotkeys for the Profiles
// Add event handler for double click to open the GUI


namespace Ciris
{
    /// <summary>
    /// inherits from Form so that hot keys can be bound to its message loop
    /// </summary>
    partial class OverlayManager : Form
    {


        // Added Ciris;
        private Ciris ciris;

        private bool cirisOpen = false;

        /// <summary>
        /// control whether the main loop is paused or not.
        /// </summary>
        private bool mainLoopPaused = false;

        /// <summary>
        /// allow to exit the main loop
        /// </summary>
        private bool exiting = false;

        /// <summary>
        /// store the current color matrix.
        /// </summary>
        private float[,] currentMatrix = null;

        // /!\ The full screen magnifier seems not to be thread-safe on Windows 8 at least,
        // so every call after initialization must be done on the same thread.
        #region Inter-thread color effect calls

        /// <summary>
        /// allow to execute magnifer api calls on the correct thread.
        /// </summary>
        private ScreenColorEffect invokeColorEffect;
        private bool shouldInvokeColorEffect;
        private object invokeColorEffectLock = new object();

        /// <summary>
        /// Ask for a color effect change to be executed on the correct thread.
        /// </summary>
        /// <param name="colorEffect"></param>
        private void InvokeColorEffect(ScreenColorEffect colorEffect)
        {
            lock (invokeColorEffectLock)
            {
                invokeColorEffect = colorEffect;
                //SynchronizeMenuItemCheckboxesWithEffect(colorEffect);
                shouldInvokeColorEffect = true;
                
                // Check for the Windows Version
                // If Windows 8+
                if (Environment.OSVersion.Version > new Version(6, 2))
                {
                    //BuiltinMatrices.InterpolateColorEffect(currentMatrix, currentMatrix);
                    DoMagnifierApiInvoke();
                }
                // Otherwise we are on Windows 7 or below.
                else
                {
                    DoMagnifierApiInvoke();
                }
            }
        }

        /// <summary>
        /// Execute the specified color effect change, on the right thread.
        /// </summary>
        private void DoMagnifierApiInvoke()
        {
            lock (invokeColorEffectLock)
            {
                if (shouldInvokeColorEffect)
                {
                    SafeChangeColorEffect(invokeColorEffect.Matrix);
                }
                shouldInvokeColorEffect = false;
            }
        }

        #endregion

        private static OverlayManager _Instance;
        public static OverlayManager Instance
        {
            get
            {
                Initialize();
                return _Instance;
            }
        }

        public static void Initialize()
        {
            if (_Instance == null)
            {
                _Instance = new OverlayManager();
            }
        }

        private OverlayManager()
        {
            InitializeComponent();

            TryRegisterHotKeys(this.trayIcon);

            toggleInversionToolStripMenuItem.ShortcutKeyDisplayString = Configuration.Current.ToggleKey.ToString();
            exitToolStripMenuItem.ShortcutKeyDisplayString = Configuration.Current.ExitKey.ToString();
            //InitializeContextMenu();

            currentMatrix = Configuration.Current.InitialColorEffect.Matrix;
            //SynchronizeMenuItemCheckboxesWithEffect(Configuration.Current.InitialColorEffect); //requires the context menu to be initialized

            InitializeControlLoop();
        }

        private void TryRegisterHotKeys(NotifyIcon trayIcon)
        {

            StringBuilder sb = new StringBuilder("Unable to register one or more hot keys:\n");
            bool success = true;
            success &= TryRegisterHotKeyAppendError(Configuration.Current.ToggleKey, sb);
            success &= TryRegisterHotKeyAppendError(Configuration.Current.ExitKey, sb);
            foreach (var item in Configuration.Current.ColorEffects)
            {
                // Don't need to try to register them for configurations.
                /*if (item.Key != HotKey.Empty)
                {
                    //success &= TryRegisterHotKeyAppendError(item.Key, sb);
                }*/
            }
            if (!success)
            {
                trayIcon.ShowBalloonTip(4000, "Warning", sb.ToString(), ToolTipIcon.Warning);
            }
        }

        private bool TryRegisterHotKeyAppendError(HotKey hotkey, StringBuilder appendErrorTo)
        {
            AlreadyRegisteredHotKeyException ex;
            if (!TryRegisterHotKey(hotkey, out ex))
            {
                appendErrorTo.AppendFormat(" - \"{0}\" : {1}", ex.HotKey, (ex.InnerException == null ? "" : ex.InnerException.Message));
                return false;
            }
            return true;
        }

        //private void InitializeContextMenu()
        //{
        //    foreach (var item in Configuration.Current.ColorEffects)
        //    {
        //        var menuItem = new ToolStripMenuItem(item.Value.Description);
        //        menuItem.Tag = item.Value;
        //        menuItem.ShortcutKeyDisplayString = item.Key.ToString();
        //        menuItem.Click += (s, e) =>
        //        {
        //            var effect = (ScreenColorEffect)((ToolStripMenuItem)s).Tag;
        //            InvokeColorEffect(effect);
        //        };
        //        //this.changeModeToolStripMenuItem.DropDownItems.Add(menuItem);
        //    }
        //}

        private void InitializeControlLoop()
        {
            System.Threading.Thread t = new System.Threading.Thread(ControlLoop);
            t.SetApartmentState((System.Threading.ApartmentState.STA));
            t.Start();
        }

        /// <summary>
        /// Main loop, in charge of controlling the magnification api.
        /// </summary>
        private void ControlLoop()
        {
            if (!Configuration.Current.ActiveOnStartup)
            {
                mainLoopPaused = true;
                PauseLoop();
            }
            while (!exiting)
            {
                if (!NativeMethods.MagInitialize())
                {
                    throw new Exception("MagInitialize()", Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()));
                }
                ToggleColorEffect(fromNormal: true);
                while (!exiting)
                {
                    //System.Threading.Thread.Sleep(Configuration.Current.MainLoopRefreshTime);
                    //DoMagnifierApiInvoke();                                                                                                   // Will need to uncomment probabaly.
                    if (mainLoopPaused)
                    {
                        ToggleColorEffect(fromNormal: false);
                        if (!NativeMethods.MagUninitialize())
                        {
                            throw new Exception("MagUninitialize()", Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()));
                        }
                        PauseLoop();
                        //we need to reinitialize
                        break;
                    }
                }
            }
            this.Invoke((Action)(() =>
            {
                this.Dispose();
                Application.Exit();
            }));
        }

        private void PauseLoop()
        {
            while (mainLoopPaused && !exiting)
            {
                System.Threading.Thread.Sleep(Configuration.Current.MainLoopRefreshTime);
                DoMagnifierApiInvoke();
            }
        }

        // Setting up public API for Pausing, Starting and Changing the loop.

        public void toggleColor()
        {
            this.mainLoopPaused = !mainLoopPaused;
        }

        public bool isPaused()
        {
            return this.mainLoopPaused;
        }

        public void setMatrix(ScreenColorEffect effect)
        {
            this.InvokeColorEffect(effect);
        }

        public bool TryRegisterHotKey(HotKey hotkey, out AlreadyRegisteredHotKeyException exception)
        {
            bool ok = NativeMethods.RegisterHotKey(this.Handle, hotkey.Id, hotkey.Modifiers, hotkey.Key);
            if (!ok)
            {
                exception = new AlreadyRegisteredHotKeyException(hotkey, Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()));
                return false;
            }
            else
            {
                exception = null;
                return true;
            }
        }

        private void UnregisterHotKeys()
        {
            try
            {
                NativeMethods.UnregisterHotKey(this.Handle, Configuration.Current.ToggleKey.Id);
                NativeMethods.UnregisterHotKey(this.Handle, Configuration.Current.ExitKey.Id);

            }
            catch (Exception) { }
        }

        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                case (int)WindowMessage.WM_HOTKEY:
                    int HotKeyId = (int)m.WParam;
                    switch (HotKeyId)
                    {
                        case HotKey.ExitKeyId:
                            Exit();
                            break;
                        case HotKey.ToggleKeyId:
                            Toggle();
                            break;
                        default:
                            foreach (var item in Configuration.Current.ColorEffects)
                            {
                                if (item.Key.Id == HotKeyId)
                                {
                                    InvokeColorEffect(item.Value);
                                }
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Can be called from any thread.
        /// </summary>
        private void Exit()
        {
            if (!mainLoopPaused)
            {
                mainLoopPaused = true;
            }
            this.exiting = true;
        }

        /// <summary>
        /// Can be called from any thread.
        /// </summary>
        private void Toggle()
        {
            this.mainLoopPaused = !mainLoopPaused;
            if (this.ciris != null)
            {
                this.ciris.changeActivated(!this.mainLoopPaused);
            }
        }

        private void ToggleColorEffect(bool fromNormal)
        {
            if (fromNormal)
            {
                if (Configuration.Current.SmoothToggles)
                {
                    BuiltinMatrices.InterpolateColorEffect(BuiltinMatrices.Identity, currentMatrix);
                }
                else
                {
                    BuiltinMatrices.ChangeColorEffect(currentMatrix);
                }
            }
            else
            {
                if (Configuration.Current.SmoothToggles)
                {
                    // This is when it changes from the current, so it was setting it to the 'current' then setting it to the identity.
                    BuiltinMatrices.InterpolateColorEffect(currentMatrix, BuiltinMatrices.Identity);
                }
                else
                {
                    BuiltinMatrices.ChangeColorEffect(BuiltinMatrices.Identity);
                }
            }
        }

        /// <summary>
        /// Check if the magnification api is in a state where a color effect can be applied, then proceed.
        /// </summary>
        /// <param name="matrix"></param>
        private void SafeChangeColorEffect(float[,] matrix)
        {
            if (!mainLoopPaused && !exiting)
            {
                if (Configuration.Current.SmoothTransitions)
                {
                    BuiltinMatrices.InterpolateColorEffect(currentMatrix, matrix);
                }
                else
                {
                    BuiltinMatrices.ChangeColorEffect(matrix);
                }
            }
            currentMatrix = matrix;
            if (this.ciris != null)
            {
                this.ciris.changeActivated(!this.mainLoopPaused);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                UnregisterHotKeys();
                NativeMethods.MagUninitialize();
            }
            base.Dispose(disposing);
        }

        //private void SynchronizeMenuItemCheckboxesWithEffect(ScreenColorEffect effect)
        //{
        //    ToolStripMenuItem currentItem = null;
        //    foreach (ToolStripMenuItem effectItem in this.changeModeToolStripMenuItem.DropDownItems)
        //    {
        //        effectItem.Checked = false; //reset all the check boxes
        //        var castItem = (ScreenColorEffect)effectItem.Tag;
        //        if (castItem.Matrix == effect.Matrix) currentItem = effectItem; //TODO: should implement equality comparison...
        //    }
        //    if (currentItem != null)
        //    {
        //        currentItem.Checked = true;
        //    }
        //}

        #region Event Handlers

        private void OverlayManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit();
        }

        private void toggleInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Toggle();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        //private void editConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (!System.IO.File.Exists(Configuration.DefaultConfigurationFileName))
        //    {
        //        System.IO.File.WriteAllText(Configuration.DefaultConfigurationFileName, Configuration.DefaultConfiguration);
        //    }
        //    System.Diagnostics.Process.Start("notepad", Configuration.DefaultConfigurationFileName);
        //}

        //private void trayIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //    {
        //        // Don't want it to toggle it for now.
        //        //Toggle();
        //    }
        //}

        private void trayIcon_DoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (ciris == null || !cirisOpen)
                {
                    ciris = new Ciris();
                    ciris.FormClosed += ciris_FormClosed;
                    cirisOpen = true;
                }
                ciris.Show();
            }
        }

        // This is called when the GUI is closed.  It creates another GUI so it can be reopened if need be.
        void ciris_FormClosed(object sender, FormClosedEventArgs e)
        {
            cirisOpen = false;
        }

        #endregion

    }
}

