using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameSceneGraph.Support;
using Viewport = MonoGameSceneGraph.Support.Viewport;

namespace MonoGameSceneGraph
{
    public class App 
    {
        public static RandomNumberCache Random { get; private set; }
        public static GraphicsDevice GraphicsDevice { get; private set; }
        public static Scene Scene { get; private set; }
        public static GameTime GameTime { get; private set; }
        public static Viewport Viewport { get; private set; }

        public static float PI { get; private set; } = (float)System.Math.PI;
        public static float PI2 { get; private set; } = (float)System.Math.PI * 2;

        public static void Init(GraphicsDevice graphicsDevice, float viewportWidth, float viewportHeight)
        {
            GameTime = new GameTime();            
            GraphicsDevice = graphicsDevice;            
            Scene = new Scene();

            // Init random LUT
            Random = new RandomNumberCache(2500);

            Viewport = new Viewport(graphicsDevice, viewportWidth, viewportHeight);
            
        }

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
