﻿using System.Collections.Generic;

namespace Cosmos.System.ScanMaps
{
    /// <summary>
    /// Represents the standard German (DE) keyboard layout.
    /// </summary>
    public class HUStandardLayout : ScanMapBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HUStandardLayout"/> class.
        /// </summary>
        public HUStandardLayout()
        {
        }

        protected override void InitKeys()
        {
            Keys = new List<KeyMapping>(101);

            #region Keys

            /*     Scan  Norm Shift Ctrl Alt     Num  Caps ShCaps ShNum ConsoleKeyEx */
            //public KeyMapping(byte scanCode, char normal, char shift, char num, char caps, char shiftCapsLock, char shiftNumLock, char ctrlAlt, char ctrlAltShift, char ctrl, char shiftCtrl, ConsoleKeyEx key, ConsoleKeyEx numKey)
            Keys.Add(new KeyMapping(0x00, ConsoleKeyEx.NoName));
            Keys.Add(new KeyMapping(0x01, ConsoleKeyEx.Escape));
            /* ^1234567890ß´        °!"§$%&/()=?`       __²³£__{[]}\_ */
            /*Keys.Add(cKeyMap = new GrapeFruit_CosmosRolling.CustomKeyMapping(0x29, '0', '§', '0', '0', ConsoleKeyEx.Backquote));
            Keys.Add(cKeyMap = new GrapeFruit_CosmosRolling.CustomKeyMapping(0x29, '1', '\'', '1', '~', ConsoleKeyEx.D1));
            Keys.Add(cKeyMap = new GrapeFruit_CosmosRolling.CustomKeyMapping(0x29, '2', '"', '2', 'ˇ', ConsoleKeyEx.D2));*/

            Keys.Add(new GrapeFruit_CosmosRolling.CustomKeyMapping(0x01, '0', '§', '0', '0', ConsoleKeyEx.D0));

            //Keys.Add(new KeyMapping(0x01, '0', '§', '0', '0', '0', '0', ConsoleKeyEx.D0));
            Keys.Add(new KeyMapping(0x02, '1', '\'', '1', '1', '1', '1', ConsoleKeyEx.D1));
            Keys.Add(new KeyMapping(0x03, '2', '\"', '2', '2', '2', '2', ConsoleKeyEx.D2));
            Keys.Add(new KeyMapping(0x04, '3', '+', '3', '^', '+', '3', '³', ConsoleKeyEx.D3));
            Keys.Add(new KeyMapping(0x05, '4', '!', '4', '˘', '!', '4', '£', '£', ConsoleKeyEx.D4));
            Keys.Add(new KeyMapping(0x06, '5', '%', '5', '°', '%', '5', ConsoleKeyEx.D5));
            Keys.Add(new KeyMapping(0x07, '6', '/', '6', '˛', '/', '6', ConsoleKeyEx.D6));
            Keys.Add(new KeyMapping(0x08, '7', '=', '7', '`', '=', '7', '{', ConsoleKeyEx.D7));
            Keys.Add(new KeyMapping(0x09, '8', '(', '8', '˙', '(', '8', '[', ConsoleKeyEx.D8));
            Keys.Add(new KeyMapping(0x0A, '9', ')', '9', '´', ')', '9', ']', ConsoleKeyEx.D9));
            Keys.Add(new KeyMapping(0x0B, 'ö', 'Ö', 'ö', '˝', 'Ö', 'Ö', '}', ConsoleKeyEx.D0));
            /* -, =, Bksp, Tab */
            Keys.Add(new KeyMapping(0x0C, 'ü', 'Ü', 'ü', '¨', 'Ü', 'ü', '\\', ConsoleKeyEx.Minus));
            Keys.Add(new KeyMapping(0x0D, 'ó', 'Ó', 'ó', '¸', 'Ó', 'ó', ConsoleKeyEx.Equal));
            Keys.Add(new KeyMapping(0x0E, ConsoleKeyEx.Backspace));
            Keys.Add(new KeyMapping(0x0F, ConsoleKeyEx.Tab));
            /* qwertzuiopü+         QWERTZUIOPÜ*        @_€________~ */
            //Keys.Add(new KeyMapping(0x10, 'q', 'Q', 'q', '\\', 'q', 'Q', '@', ConsoleKeyEx.Q));
            Keys.Add(new GrapeFruit_CosmosRolling.CustomKeyMapping(0x10, 'q', 'Q', 'Q', '\\', ConsoleKeyEx.Q));


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
            /* ENTER, CTRL */
            Keys.Add(new KeyMapping(0x1C, ConsoleKeyEx.Enter));
            Keys.Add(new KeyMapping(0x1D, ConsoleKeyEx.LCtrl));
            /* asdfghjklöä#         ASDFGHJKLÖÄ'        ____________ */
            Keys.Add(new KeyMapping(0x1E, 'a', 'A', 'ä', 'A', 'a', 'A', ConsoleKeyEx.A));
            Keys.Add(new KeyMapping(0x1F, 's', 'S', 's', 'đ', 's', 'S', ConsoleKeyEx.S));
            Keys.Add(new KeyMapping(0x20, 'd', 'D', 'd', 'Đ', 'd', 'D', ConsoleKeyEx.D));
            Keys.Add(new KeyMapping(0x21, 'f', 'F', 'f', '[', 'f', 'F', ConsoleKeyEx.F));
            Keys.Add(new KeyMapping(0x22, 'g', 'G', 'g', ']', 'g', 'G', ConsoleKeyEx.G));
            Keys.Add(new KeyMapping(0x23, 'h', 'H', 'h', 'H', 'h', 'H', ConsoleKeyEx.H));
            Keys.Add(new KeyMapping(0x24, 'j', 'J', 'j', 'í', 'j', 'J', ConsoleKeyEx.J));
            Keys.Add(new KeyMapping(0x25, 'k', 'K', 'k', 'ł', 'k', 'K', ConsoleKeyEx.K));
            Keys.Add(new KeyMapping(0x26, 'l', 'L', 'l', 'Ł', 'l', 'L', ConsoleKeyEx.L));
            Keys.Add(new KeyMapping(0x27, 'é', 'É', 'é', '$', 'é', 'É', ConsoleKeyEx.Semicolon));
            Keys.Add(new KeyMapping(0x28, 'á', 'Á', 'á', 'ß', 'á', 'Á', ConsoleKeyEx.Apostrophe));
            Keys.Add(new KeyMapping(0x29, 'ü', 'Ü', 'ü', '¤', 'ü', 'Ü', ConsoleKeyEx.Backslash));
            /* Left Shift*/
            Keys.Add(new KeyMapping(0x2A, ConsoleKeyEx.LShift));
            /* <yxcvbnm,.-          >YXCVBNM;:_         |______µ___ */
            Keys.Add(new KeyMapping(0x2B, 'í', 'Í', 'í', 'Í', 'í', 'Í', '|', '|', ConsoleKeyEx.OEM102));
            Keys.Add(new KeyMapping(0x2C, 'y', 'Y', 'y', 'Y', 'y', 'Y', ConsoleKeyEx.Z));
            Keys.Add(new KeyMapping(0x2D, 'x', 'X', 'x', 'X', 'x', 'X', ConsoleKeyEx.X));
            Keys.Add(new KeyMapping(0x2E, 'c', 'C', 'c', 'C', 'c', 'C', ConsoleKeyEx.C));
            Keys.Add(new KeyMapping(0x2F, 'v', 'V', 'v', 'V', 'v', 'V', ConsoleKeyEx.V));
            Keys.Add(new KeyMapping(0x30, 'b', 'B', 'b', 'B', 'b', 'B', ConsoleKeyEx.B));
            Keys.Add(new KeyMapping(0x31, 'n', 'N', 'n', 'N', 'n', 'N', ConsoleKeyEx.N));
            Keys.Add(new KeyMapping(0x32, 'm', 'M', 'm', 'M', 'm', 'M', 'µ', ConsoleKeyEx.M));
            Keys.Add(new KeyMapping(0x33, ',', '?', ',', ';', '?', ';', ConsoleKeyEx.Comma));
            Keys.Add(new KeyMapping(0x34, '.', ':', '.', ':', '.', ':', ConsoleKeyEx.Period));
            Keys.Add(new KeyMapping(0x35, '-', '_', '-', '*', '-', '_', ConsoleKeyEx.Slash));
            /* Right Shift */
            Keys.Add(new KeyMapping(0x36, ConsoleKeyEx.RShift));
            /* Print Screen */
            Keys.Add(new KeyMapping(0x37, 'n', 's', 'c', 'a', 'b', 'e', ConsoleKeyEx.NumMultiply));
            // also numpad multiply
            /* Alt  */
            Keys.Add(new KeyMapping(0x38, ConsoleKeyEx.LAlt));
            /* Space */
            Keys.Add(new KeyMapping(0x39, ' ', ConsoleKeyEx.Spacebar));
            /* Caps */
            Keys.Add(new KeyMapping(0x3A, ConsoleKeyEx.CapsLock));
            /* F1-F12 */
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
            /* Num Lock, Scrl Lock */
            Keys.Add(new KeyMapping(0x45, ConsoleKeyEx.NumLock));
            Keys.Add(new KeyMapping(0x46, ConsoleKeyEx.ScrollLock));
            /* HOME, Up, Pgup, -kpad, left, center, right, +keypad, end, down, pgdn, ins, del */
            Keys.Add(new KeyMapping(0x4A, '-', '-', '-', '-', '-', '-', ConsoleKeyEx.NumMinus));
            Keys.Add(new KeyMapping(0x4E, '+', '+', '+', '+', '+', '+', ConsoleKeyEx.NumPlus));
            Keys.Add(new KeyMapping(0x47, '\0', '\0', '7', '\0', '\0', '\0', ConsoleKeyEx.Home, ConsoleKeyEx.Num7));
            Keys.Add(new KeyMapping(0x48, '\0', '\0', '8', '\0', '\0', '\0', ConsoleKeyEx.UpArrow, ConsoleKeyEx.Num8));
            Keys.Add(new KeyMapping(0x49, '\0', '\0', '9', '\0', '\0', '\0', ConsoleKeyEx.PageUp, ConsoleKeyEx.Num9));
            Keys.Add(new KeyMapping(0x4B, '\0', '\0', '4', '\0', '\0', '\0', ConsoleKeyEx.LeftArrow, ConsoleKeyEx.Num4));
            Keys.Add(new KeyMapping(0x4C, '\0', '\0', '5', '\0', '\0', '\0', ConsoleKeyEx.Num5));
            Keys.Add(new KeyMapping(0x4D, '\0', '\0', '6', '\0', '\0', '\0', ConsoleKeyEx.RightArrow, ConsoleKeyEx.Num6));
            Keys.Add(new KeyMapping(0x4F, '\0', '\0', '1', '\0', '\0', '\0', ConsoleKeyEx.End, ConsoleKeyEx.Num1));
            Keys.Add(new KeyMapping(0x50, '\0', '\0', '2', '\0', '\0', '\0', ConsoleKeyEx.DownArrow, ConsoleKeyEx.Num2));
            Keys.Add(new KeyMapping(0x51, '\0', '\0', '3', '\0', '\0', '\0', ConsoleKeyEx.PageDown, ConsoleKeyEx.Num3));
            Keys.Add(new KeyMapping(0x52, '\0', '\0', '0', '\0', '\0', '\0', ConsoleKeyEx.Insert, ConsoleKeyEx.Num0));
            Keys.Add(new KeyMapping(0x53, '\b', '\b', ',', '\b', '\b', '\b', ConsoleKeyEx.Delete, ConsoleKeyEx.NumPeriod));

            Keys.Add(new KeyMapping(0x5b, ConsoleKeyEx.LWin));
            Keys.Add(new KeyMapping(0x5c, ConsoleKeyEx.RWin));

            #endregion
        }
    }
}
