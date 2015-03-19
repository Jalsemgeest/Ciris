using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// TODO
// May not need this class as hotkeys will not be for Profiles.

namespace Ciris
{
    class AlreadyRegisteredHotKeyException : Exception
    {

        public HotKey HotKey { get; protected set; }

        public AlreadyRegisteredHotKeyException(HotKey hotkey, Exception innerException = null)
            : base(string.Format("Unable to register \"{0}\", this hot key is already registered.", hotkey), innerException)
        {
            this.HotKey = hotkey;
        }

    }
}
