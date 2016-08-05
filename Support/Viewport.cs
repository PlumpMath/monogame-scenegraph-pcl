using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameSceneGraph.Core;

namespace MonoGameSceneGraph.Support
{
    public class Viewport
    {
        public float Width { get; private set; }
        public float Height { get; private set; }
        public Matrix Matrix { get; private set; }
        public Matrix MatrixInv { get; private set; }

        public Viewport(GraphicsDevice graphicsDevice, float viewportWidth, float viewportHeight)
        {
            // create res independant scale matrix
            Height = viewportHeight;
            Width = viewportWidth;
            var scaleX = (float)App.GraphicsDevice.DisplayMode.Width / Width;
            var scaleY = (float)App.GraphicsDevice.DisplayMode.Height / Height;

            Matrix = Matrix.CreateScale(scaleX, scaleY, 1.0f);
            MatrixInv = Matrix.Invert(Matrix);
        }
    }
}
