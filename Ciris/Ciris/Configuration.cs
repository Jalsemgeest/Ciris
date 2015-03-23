using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;

/**
 * This is where the configuration of the program takes place.  Most of this is for startup and is not used otherwise.
 * The profiles are brought in at this point and Hotkeys are initialized.
 **/


// TODO
// Remove Hotkeys for Profiles                              - COMPLETED (I think...)
// Remove Configuration File - LATER


namespace CirisTest
{
    class Configuration : IConfigurable
    {
        #region Default Configuration
        public const string DefaultConfigurationFileName = "ciris.conf";
        public const string DefaultConfiguration = @"# comments: if the character '#' is found, the rest of the line is ignored.
# quotes: allow to place a '#' inside a value. they do not appear in the final result.
# i.e. blah=""hello #1!"" will create a parameter blah with a value of: hello #1!
# To place a quotation mark inside quotes, double it.
# i.e. blah=""hello"""""" will create a parameter blah with a value of: hello""

#Predefined keys
# You can use the following modifiers: alt, ctrl, shift, win
# and a key from http://msdn.microsoft.com/en-us/library/system.windows.forms.keys%28v=vs.71%29.aspx
# You can either use its textual representation, or its numerical value.
# WARNING: if the key is not valid, the program will probably crash...

Toggle=win+alt+N
Exit=win+alt+H

SmoothTransitions=true
SmoothToggles=true

# in miliseconds
MainLoopRefreshTime=100

InitialColorEffect=""Smart Inversion""

ActiveOnStartup=true

ShowAeroWarning=true

#Matrices definition
# The left hand is used as a description, while the right hand is broken down in two parts:
# - the hot key combination, followed by a new line, (this part is optional)
# - the matrix definition, with or without new lines between rows.
# The matrices must have 5 rows and 5 columns,
# each line between curved brackets,
# the elements separated by commas.
# The decimal separator is a dot.

#Protanopia
Protanopia=
{  1,  0,  0.6,  0,  0 }
{  0,  1,  0,  0,  0 }
{  0,  0,  0.4,  0,  0 }
{  0,  0,  0,  1,  0 }
{  0,  0,  0,  0,  1 }

#Tritanopia
Tritanopia=
{  1.0,  0.0,  0.0,  0.0,  0.0 }
{ -0.1, -0.1, -0.1,  0.0,  0.0 }
{  0.0,  1.0,  1.0,  0.0,  0.0 }
{  0.0,  0.0,  0.0,  1.0,  0.0 }
{  0.0,  0.0,  0.0,  0.0,  1.0 }

#Temp
Temp=
{  0,  0,  1,  0,  0 }
{  0,  1,  0,  0,  0 }
{  1,  0,  0,  0,  0 }
{  0,  0,  0,  1,  0 }
{  0,  0,  0,  0,  1 }

#temp2
Temp2=
{  0,  0,  1,  0,  0 }
{  1,  1,  0,  0,  0 }
{  0,  0,  0,  0,  0 }
{  0,  0,  0,  1,  0 }
{  0,  0,  0,  0,  1 }

#Protanopia Simulation
Protanopia Simulation=
{  0.00,  0.00,  0.00,  0.00,  0.00 }
{  0.50,  0.50,  0.00,  0.00,  0.00 }
{  1.00,  0.65,  1.00,  0.00,  0.00 }
{  0.00,  0.00,  0.00,  1.00,  0.00 }
{  0.00,  0.00,  0.00,  0.00,  1.00 }

#NewProt
New Protanopia=
{  1.0,  -0.25,  0,  0.0,  0.0 }
{  0.25,  1.0,  0,  0.0,  0.0 }
{  0.0,  0.0,  1,  0.0,  0.0 }
{  0.0,  0.0,  0.0,  1.0,  0.0 }
{  0.0,  0.0,  0.0,  0.0,  1.0 }

";
        #endregion 

        private static Configuration _current;
        public static Configuration Current
        {
            get
            {
                Initialize();
                return _current;
            }
        }

        public static void Initialize()
        {
            if (_current == null)
            {
                _current = new Configuration();
            }
        }

        private Configuration()
        {
            ColorEffects = new List<KeyValuePair<ProfileKey, ScreenColorEffect>>();

            string configFileContents;

            try
            {
                configFileContents = System.IO.File.ReadAllText(DefaultConfigurationFileName);
            }
            catch (Exception)
            {
                                                                                                        // Set this to be the default if we don't want people to edit the configurations.
                configFileContents = DefaultConfiguration;
            }

            // Reading in the configuration file string.
            Parser.AssignConfiguration(configFileContents, this, new HotKeyParser(), new ProfileKeyParser(), new MatrixParser());
            if (!string.IsNullOrWhiteSpace(InitialColorEffectName))
            {
                try
                {
                    // Try setting it to the Protanopia standard.
                    this.InitialColorEffect = new ScreenColorEffect(BuiltinMatrices.ProtanopiaSim, "Protanopia Sim");
                }
                catch (Exception)
                {
                    // Probably not ideal
                    this.InitialColorEffect = new ScreenColorEffect(BuiltinMatrices.ProtanopiaSim, "Protanopia Sim");
                }
            }
        }
        [CorrespondTo("Toggle", CustomParameter = HotKey.ToggleKeyId)]
		public HotKey ToggleKey { get; protected set; }

		[CorrespondTo("Exit", CustomParameter = HotKey.ExitKeyId)]
		public HotKey ExitKey { get; protected set; }

		[CorrespondTo("SmoothTransitions")]
		public bool SmoothTransitions { get; set; }

		[CorrespondTo("SmoothToggles")]
		public bool SmoothToggles { get; protected set; }

		[CorrespondTo("MainLoopRefreshTime", CustomParameter = 100)]
		public int MainLoopRefreshTime { get; protected set; }

		[CorrespondTo("ActiveOnStartup", CustomParameter = true)]
		public bool ActiveOnStartup { get; protected set; }

		[CorrespondTo("ShowAeroWarning", CustomParameter = true)]
		public bool ShowAeroWarning { get; protected set; }

		[CorrespondTo("InitialColorEffect")]
		public string InitialColorEffectName { get; protected set; }

		public ScreenColorEffect InitialColorEffect { get; protected set; }

		public List<KeyValuePair<ProfileKey, ScreenColorEffect>> ColorEffects { get; protected set; }

        public void HandleDynamicKey(string key, string value) {
            // value is already trimmed
            if (value.StartsWith("{")) {
                // No hotkey
                this.ColorEffects.Add(new KeyValuePair<ProfileKey, ScreenColorEffect>(
                    ProfileKey.Empty,
                    new ScreenColorEffect(MatrixParser.StaticParseMatrix(value), key)));
            }
            else {
                // First part is the hotkey, second part is the matrix
                var splitted = value.Split(new char[] { '\n' }, 2);
                if (splitted.Length < 2) {
                    throw new Exception(string.Format(
                        "The value assigned to \"{0}\" is unexpected.", key));
                }
                this.ColorEffects.Add(new KeyValuePair<ProfileKey,ScreenColorEffect>(
                    ProfileKeyParser.StaticParse(splitted[0]),
                    new ScreenColorEffect(MatrixParser.StaticParseMatrix(splitted[1]), key)));
            }
        }
    }

    class ProfileKeyParser : ICustomParser
    {
        public Type ReturnType
        {
            get { return typeof(ProfileKey);  }
        }

        public object Parse(string rawValue, object customParameter)
        {
            int defaultId = -1;
            if (customParameter is int)
            {
                defaultId = (int)customParameter;
            }
            return StaticParse(rawValue, defaultId);
        }

        public static ProfileKey StaticParse(string rawValue, int defaultId = -1)
        {
            return new ProfileKey(defaultId);
        }
    }

    class HotKeyParser : ICustomParser
	{

		public Type ReturnType
		{
			get { return typeof(HotKey); }
		}

		public object Parse(string rawValue, object customParameter)
		{
			int defaultId = -1;
			if (customParameter is int)
			{
				defaultId = (int)customParameter;
			}
			return StaticParse(rawValue, defaultId);
		}

        public static HotKey StaticParse(string rawValue, int defaultId = -1)
		{
			KeyModifiers modifiers = KeyModifiers.NONE;
			Keys key = Keys.None;
			string trimmed = rawValue.Trim();
			var splitted = trimmed.Split('+');
			foreach (var item in splitted)
			{
				//modifier
				switch (item.ToLowerInvariant())
				{
					case "alt":
						modifiers |= KeyModifiers.MOD_ALT;
						break;
					case "ctrl":
						modifiers |= KeyModifiers.MOD_CONTROL;
						break;
					case "shift":
						modifiers |= KeyModifiers.MOD_SHIFT;
						break;
					case "win":
						modifiers |= KeyModifiers.MOD_WIN;
						break;
					default:
						//key
						if (!Enum.TryParse(item, true, out key))
						{
							//try to parse numeric value
							int numericValue;
							if (int.TryParse(item, out numericValue))
							{
								if (Enum.IsDefined(typeof(Keys), numericValue))
								{
									key = (Keys)numericValue;
								}
							}
						}
						break;
				}

			}
			return new HotKey(modifiers, key, defaultId);
		}
	}

    class MatrixParser : ICustomParser
	{

		public Type ReturnType
		{
			get { return typeof(float[,]); }
		}

		public object Parse(string rawValue, object customParameter)
		{
			return StaticParseMatrix(rawValue);
		}

		public static float[,] StaticParseMatrix(string rawValue)
		{
			float[,] matrix = new float[5, 5];
			var rows = System.Text.RegularExpressions.Regex.Matches(rawValue, @"{(?<row>.*?)}",
				System.Text.RegularExpressions.RegexOptions.ExplicitCapture);
			if (rows.Count != 5)
			{
				throw new Exception("The matrices must have 5 rows.");
			}
			for (int x = 0; x < rows.Count; x++)
			{
				var row = rows[x];
                // Split the rows into columns based on the commas.
				var columnSplit = row.Groups["row"].Value.Split(',');
				if (columnSplit.Length != 5)
				{
					throw new Exception("The matrices must have 5 columns.");
				}
                // For 0 --> 4
				for (int y = 0; y < matrix.GetLength(1); y++)
				{
					float value;
                    // If we cannot translate the value into a float...
					if (!float.TryParse(columnSplit[y],
						System.Globalization.NumberStyles.Float,
						System.Globalization.NumberFormatInfo.InvariantInfo,
						out value))
					{
						throw new Exception(string.Format("Unable to parse \"{0}\" to a float.", columnSplit[y]));
					}
                    // Otherwise put the value in the matrix...
					matrix[x, y] = value;
				}
			}
			return matrix;
		}
	}

    // Custom Struct for the Profile Keys... does not include a Hotkey.
    struct ProfileKey
    {

        public static readonly ProfileKey Empty;

        private static int CurrentId = 100;

        public int Id { get; private set; }

        static ProfileKey()
        {
            Empty = new ProfileKey()
            {
                Id = 0
            };
        }

        public ProfileKey(int id = -1)
			: this()
		{
			if (id == -1)
			{
				this.Id = CurrentId;
				CurrentId++;
			}
			else
			{
				this.Id = id;
			}
		}

		public override int GetHashCode()
		{
			return Id << 20;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is ProfileKey)
			{
				return obj.GetHashCode() == this.GetHashCode();
			}
			else
			{
				return false;
			}
		}

		public static bool operator ==(ProfileKey a, ProfileKey b)
		{
			return a.GetHashCode() == b.GetHashCode();
		}

		public static bool operator !=(ProfileKey a, ProfileKey b)
		{
			return a.GetHashCode() != b.GetHashCode();
		}

        public override string ToString()
        {
            return "";
        }
    }

    struct HotKey
	{
		public const int ToggleKeyId = 42;
		public const int ExitKeyId = 43;

		private static int CurrentId = 100;

		public static readonly HotKey Empty;

		public KeyModifiers Modifiers { get; private set; }
		public Keys Key { get; private set; }
		public int Id { get; private set; }

		static HotKey()
		{
			Empty = new HotKey()
			{
				Id = 0,
				Key = Keys.None,
				Modifiers = KeyModifiers.NONE
			};
		}

		public HotKey(KeyModifiers modifiers, Keys key, int id = -1)
			: this()
		{
			this.Modifiers = modifiers;
			//65535
			this.Key = key & Keys.KeyCode;
			if (id == -1)
			{
				this.Id = CurrentId;
				CurrentId++;
			}
			else
			{
				this.Id = id;
			}
		}

		public override int GetHashCode()
		{
			return (int)Key | (int)Modifiers << 16 | Id << 20;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is HotKey)
			{
				return obj.GetHashCode() == this.GetHashCode();
			}
			else
			{
				return false;
			}
		}

		public static bool operator ==(HotKey a, HotKey b)
		{
			return a.GetHashCode() == b.GetHashCode();
		}

		public static bool operator !=(HotKey a, HotKey b)
		{
			return a.GetHashCode() != b.GetHashCode();
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			if (Modifiers.HasFlag(KeyModifiers.MOD_ALT))
			{
				sb.Append("Alt+");
			}
			if (Modifiers.HasFlag(KeyModifiers.MOD_CONTROL))
			{
				sb.Append("Ctrl+");
			}
			if (Modifiers.HasFlag(KeyModifiers.MOD_SHIFT))
			{
				sb.Append("Shift+");
			}
			if (Modifiers.HasFlag(KeyModifiers.MOD_WIN))
			{
				sb.Append("Win+");
			}
			sb.Append(Enum.GetName(typeof(Keys), Key) ?? ((int)Key).ToString());
			return sb.ToString();
		}
	}

    struct ScreenColorEffect
	{
		public float[,] Matrix { get; private set; }
		public string Description { get; private set; }

		public ScreenColorEffect(float[,] matrix, string description)
			: this()
		{
			this.Matrix = matrix;
			this.Description = description;
		}

	}

}
