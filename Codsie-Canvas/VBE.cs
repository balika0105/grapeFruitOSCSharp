using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapeFruitCSharp.Codsie_Canvas
{
    public unsafe class VBE
    {
        public static bool Ininitialized = false;

        public static int Width, Height;
        public static int*[] Buffer;
        private Cosmos.HAL.Drivers.VBEDriver vbeDriver;

        public VBE(int width, int height)
        {
            Width = width;
            Height = height;
            Buffer = new int*[Width * Height];

            vbeDriver = new((ushort)Width, (ushort)Height, 32);

            Ininitialized = true;
        }
    }
}
