using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

using System.Drawing;

using GrapeFruitCSharp.Codsie_Canvas;

namespace GrapeFruitCSharp
{
    public class GraphicsTest
    {

        static Canvas canvas;
        public static void CallThisFromOutside()
        {
            Console.WriteLine("This is currently only in a testing phase");
            Console.WriteLine("You might have to reboot manually to exit this \"application\"");
            Console.WriteLine("\nPress a key to continue");
            Console.ReadKey();
            Init();
        }
        static void Init()
        {
            VBE vbe = new VBE(1024, 768);

            Font currentFont = new Font(Font.Default.Width, Font.Default.Height, Font.Default.MS.ToString());
            canvas = new Canvas();
            Canvas.Clear();
            canvas.Update();
        }

        static void Main()
        {
            Canvas.Clear(Color.DarkGreen);
            Canvas.DrawString(10, 10, "Hello world", Color.White);
            canvas.Update();
            Console.ReadKey();
        }
    }
}
