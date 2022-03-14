using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

using System.Drawing;

using GrapeFruitCSharp.Codsie_Canvas;

namespace GrapeFruitCSharp
{
    //Disabling annoying suggestions
    #pragma warning disable IDE0059
    #pragma warning disable IDE0090
    public class GraphicsTest
    {
        static GrapeFruitCSharp.Codsie_Canvas.Canvas canvas;
        static GrapeFruitCSharp.Codsie_Canvas.VBE vbe;
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
            try
            {
                Console.Clear();
                //Font currentFont = Font.Default;
                vbe = new(1024, 768);

                canvas = new();
                Canvas.Clear();
                canvas.Update();
            }
            catch (Exception ex)
            {
                ErrorScreen.Main(ex);
            }
        }

        static void Main()
        {
            try
            {
                Canvas.Clear(Color.DarkGreen);
                //Canvas.DrawString(10, 10, "Hello world", Color.White);
                Canvas.DrawFilledTriangle(30, 40, 20, 30, 40, 30, Color.DarkRed);
                canvas.Update();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                ErrorScreen.Main(ex);
            }
        }
    }
}
