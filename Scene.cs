using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public class Scene : IEnumerable<Layer>
    {
        private readonly List<Layer> layers;
        private readonly GraphicsDevice graphicsDevice;

        public Scene(GraphicsDevice graphiceDevice)
        {
            layers = new List<Layer>();
            this.graphicsDevice = graphiceDevice;
        }

        public IEnumerator<Layer> GetEnumerator()
        {
            return layers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(Layer layer)
        {
            layer.Init(graphicsDevice);
            layers.Add(layer);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            TouchCollection touchCollection = TouchPanel.GetState();

            foreach (var layer in layers)
                layer.Update(gameTime, touchCollection);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(GameTime gameTime)
        {
            graphicsDevice.Clear(Color.Black);

            foreach (var layer in layers)
                layer.Draw(gameTime);
        }
    }
}
