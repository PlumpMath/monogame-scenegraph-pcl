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
        public static GameTime GameTime { get; private set; }
        public App(GraphicsDevice graphicsDevice)
        {
            GameTime = new GameTime();
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
            // here we are updating the global GameTime once per logic frame instead
            // of once per tick. Still this is good enough for most things that need
            // to access game time outside of an Update() or Draw()
            GameTime = gameTime;
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
