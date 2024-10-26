#pragma warning disable IDE0049 // Use framework type
using Cosmos.System;
using System;

namespace grapeFruitRebuild
{
    /// <summary>
    /// Represents a customised keymapping from physical to virtual, Alt key can be used
    /// </summary>
    public class CustomKeyMapping : KeyMapping
    {
        /// <summary>
        /// The text character value of the key with the Alt
        /// key modifier being active. 
        /// </summary>
        public char Alt;
        /// <summary>
        /// Empty character literal
        /// </summary>
        public const char emptyC = '\0';

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomKeyMapping"/> class.
        /// </summary>
        /// <param name="scanCode">The physical scan code of the key.</param>
        /// <param name="value">The text character value of the key with no modifiers being active.</param>
        /// <param name="shift">The text character value of the key with the Shift modifier being active.</param>
        /// <param name="capsLock">The text character value of the key with the Caps Lock modifier being active.</param>
        /// <param name="alt">The text character value of the key with the Alt modifier being active.</param>
        /// <param name="consoleKey">The virtual key that the physical key-press maps to.</param>
        public CustomKeyMapping(byte scanCode, char value, char shift, char capsLock, char alt, ConsoleKeyEx consoleKey): base(scanCode, value, shift, value, capsLock, shift, shift, alt, consoleKey)
        {
            ScanCode = scanCode;
            Value = value;
            Shift = shift;
            CapsLock = capsLock;
            Alt = alt;
            Key = consoleKey;
        }
    }
}
