using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSceneGraph
{
    public class App 
    {
        public static Random Random { get; private set; }
        public static GraphicsDevice GraphicsDevice { get; private set; }
        public static Scene Scene { get; private set; }

        public App(GraphicsDevice graphicsDevice)
        {
 
            Random = new Random();
            GraphicsDevice = graphicsDevice;            
            Scene = new Scene();
        }

        GraphicsDeviceManager graphics;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static void Update(GameTime gameTime)
        {
            Scene.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static void Draw(GameTime gameTime)
        {
            Scene.Draw(gameTime);
        }

    }
}
