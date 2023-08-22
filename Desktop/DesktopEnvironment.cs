using System.Collections.Generic;

using Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Cosmos.System.Graphics.Fonts;
using Cosmos.HAL;
using Cosmos.Core;

namespace GrapeFruit_CosmosRolling.Desktop
{
    public class DesktopEnvironment
    {
        static byte[] fontData = Globals.fontData;
        static List<UnicodeMapping> mappings = new List<UnicodeMapping>();
        static PCScreenFont font;

        static VGACanvas vgaCanvas;

        static int cursorXpos, cursorYpos;

        public static void Init()
        {
            Logger.Debug("Initialising Graphical ENV");
            #region Setting up font
            var mapping = new UnicodeMapping
            {
                FontPosition = mappings.Count,
                UnicodeCharacters = new List<ushort>(),
                UnicodeCharactersWithModifiers = new List<ushort[]>(),
                ASCIICharacters = new List<byte>()
            };

            mappings.Add(mapping);

            byte mode = fontData[2];
            byte charHeight = fontData[3];
            byte charWidth = 8;
            #endregion
            vgaCanvas = new VGACanvas();
            vgaCanvas.Mode = new Mode(640, 480, ColorDepth.ColorDepth4);
            PCScreenFont font = new PCScreenFont(charWidth, charHeight, fontData, mappings);
            vgaCanvas.Clear(Color.DarkBlue);
            vgaCanvas.DrawString("GrapeFruitOS Graphics Mode", font, Color.White, 0, 0);
            RenderLoop();
            return;
        }

        static void RenderLoop()
        {
            Logger.Debug("Start graphics render loop");

            bool run = true;

            /*INTs.IRQContext context = new INTs.IRQContext();
            PS2Mouse ps2Mouse = new PS2Mouse();
            ps2Mouse.HandleMouse(ref context);*/


            while (run)
            {
                
                MouseManager.HandleMouse(MouseManager.DeltaX, MouseManager.DeltaY, (int)MouseManager.MouseState, 0);
                Logger.Debug("Render");
                cursorXpos = (int)MouseManager.X;
                cursorYpos = (int)MouseManager.Y;

                vgaCanvas.DrawTriangle(Color.White, cursorXpos, cursorYpos, (cursorXpos - 5), (cursorYpos - 5), (cursorXpos + 5), (cursorYpos + 5));
                Logger.Debug($"Mouse X: {cursorXpos} | Mouse Y: {cursorYpos}");
            }
            return;
        }
    }
}
