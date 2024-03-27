using System.Collections.Generic;

namespace Cosmos.System.ScanMaps
{
    ///<summary>
    ///Improved homebrew Hungarian keyboard layout
    ///</summary>

    public class HUNewLayout:ScanMapBase{
        /// <summary>
        /// Initializes a new instance of the <see cref="HUNewLayout"/> class.
        /// </summary>
        public HUNewLayout()
        {
        }
        protected override void InitKeys()
        {
            Keys = new List<KeyMapping>(102);
            #region THE KEYS
            Keys.Add(new KeyMapping(0x00, ConsoleKeyEx.NoName));
            Keys.Add(new KeyMapping(0x01, ConsoleKeyEx.Escape));

            //Function row F1-F12, PrtSc, ScrLk, Pause/Brk
            Keys.Add(new KeyMapping(0x3B, ConsoleKeyEx.F1));
            Keys.Add(new KeyMapping(0x3C, ConsoleKeyEx.F2));
            Keys.Add(new KeyMapping(0x3D, ConsoleKeyEx.F3));
            Keys.Add(new KeyMapping(0x3E, ConsoleKeyEx.F4));
            Keys.Add(new KeyMapping(0x3F, ConsoleKeyEx.F5));
            Keys.Add(new KeyMapping(0x40, ConsoleKeyEx.F6));
            Keys.Add(new KeyMapping(0x41, ConsoleKeyEx.F7));
            Keys.Add(new KeyMapping(0x42, ConsoleKeyEx.F8));
            Keys.Add(new KeyMapping(0x43, ConsoleKeyEx.F9));
            Keys.Add(new KeyMapping(0x44, ConsoleKeyEx.F10));
            Keys.Add(new KeyMapping(0x57, ConsoleKeyEx.F11));
            Keys.Add(new KeyMapping(0x58, ConsoleKeyEx.F12));

            Keys.Add(new KeyMapping(0x45, ConsoleKeyEx.NumLock));
            Keys.Add(new KeyMapping(0x46, ConsoleKeyEx.ScrollLock));

            //Uppermost row 0-9, öüó, bksp
            Keys.Add(new KeyMapping(0x29, '0', '§', '0', '0', '§', '0', ConsoleKeyEx.Backquote));
            Keys.Add(new KeyMapping(0x02, '1', '\'', '1', '1', '1', '1', '~', ConsoleKeyEx.D1));
            Keys.Add(new KeyMapping(0x03, '2', '\"', '2', '2', '2', '2', 'ˇ', ConsoleKeyEx.D2));
            Keys.Add(new KeyMapping(0x04, '3', '+', '3', '^', '+', '3', '³', ConsoleKeyEx.D3));
            Keys.Add(new KeyMapping(0x05, '4', '!', '4', '˘', '!', '4', '£', '£', ConsoleKeyEx.D4));
            Keys.Add(new KeyMapping(0x06, '5', '%', '5', '°', '%', '5', ConsoleKeyEx.D5));
            Keys.Add(new KeyMapping(0x07, '6', '/', '6', '˛', '/', '6', ConsoleKeyEx.D6));
            Keys.Add(new KeyMapping(0x08, '7', '=', '7', '`', '=', '7', '{', ConsoleKeyEx.D7));
            Keys.Add(new KeyMapping(0x09, '8', '(', '8', '˙', '(', '8', '[', ConsoleKeyEx.D8));
            Keys.Add(new KeyMapping(0x0A, '9', ')', '9', '´', ')', '9', ']', ConsoleKeyEx.D9));

            Keys.Add(new KeyMapping(0x0B, 'ö', 'Ö', 'ö', '˝', 'Ö', 'Ö', '}', ConsoleKeyEx.D0));
            Keys.Add(new KeyMapping(0x0C, 'ü', 'Ü', 'ü', '¨', 'Ü', 'ü', '\\', ConsoleKeyEx.Minus));
            Keys.Add(new KeyMapping(0x0D, 'ó', 'Ó', 'ó', '¸', 'Ó', 'ó', ConsoleKeyEx.Equal));
            Keys.Add(new KeyMapping(0x0E, ConsoleKeyEx.Backspace));

            //Top row tab, q-p, ő ú
            Keys.Add(new KeyMapping(0x0F, ConsoleKeyEx.Tab));
            Keys.Add(new KeyMapping(0x10, 'q', 'Q', 'q', 'Q', 'q', 'q', '\\', ConsoleKeyEx.Q));
            Keys.Add(new KeyMapping(0x11, 'w', 'W', 'w', '|', 'w', 'W', ConsoleKeyEx.W));
            Keys.Add(new KeyMapping(0x12, 'e', 'E', 'e', 'Ä', 'e', 'E', '€', ConsoleKeyEx.E));
            Keys.Add(new KeyMapping(0x13, 'r', 'R', 'r', 'R', 'r', 'R', ConsoleKeyEx.R));
            Keys.Add(new KeyMapping(0x14, 't', 'T', 't', 'T', 't', 'T', ConsoleKeyEx.T));
            Keys.Add(new KeyMapping(0x15, 'z', 'Z', 'z', 'Z', 'z', 'Z', ConsoleKeyEx.Y));
            Keys.Add(new KeyMapping(0x16, 'u', 'U', 'u', '€', 'u', 'U', ConsoleKeyEx.U));
            Keys.Add(new KeyMapping(0x17, 'i', 'I', 'i', 'Í', 'i', 'I', ConsoleKeyEx.I));
            Keys.Add(new KeyMapping(0x18, 'o', 'O', 'o', 'O', 'o', 'O', ConsoleKeyEx.O));
            Keys.Add(new KeyMapping(0x19, 'p', 'P', 'p', 'P', 'p', 'P', ConsoleKeyEx.P));
            Keys.Add(new KeyMapping(0x1A, 'ö', 'Ö', 'ö', '÷', 'ö', 'Ö', ConsoleKeyEx.LBracket));
            Keys.Add(new KeyMapping(0x1B, 'ú', 'Ú', 'ú', '×', 'ú', 'Ú', '~', ConsoleKeyEx.RBracket));

            //Home row Caps Lock, a-l, é á ű, Enter
            Keys.Add(new KeyMapping(0x3A, ConsoleKeyEx.CapsLock));

            #endregion
        }
    }
}