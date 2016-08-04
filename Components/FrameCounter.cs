using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph.Components
{
    public class FrameCounter : Component
    {
        public FrameCounter(SpriteFont font, Color color, float x, float y) : base(null)
        {
            this.font = font;
            this.color = color;
            position.X = x;
            position.Y = y;
        }

        private Color color;
        private SpriteFont font;

        public long TotalFrames { get; private set; }
        public float TotalSeconds { get; private set; }
        public float AverageFramesPerSecond { get; private set; }
        public float CurrentFramesPerSecond { get; private set; }

        public const int MAXIMUM_SAMPLES = 100;

        private Queue<float> _sampleBuffer = new Queue<float>();

        private void calculateFPS(float deltaTime)
        {
            CurrentFramesPerSecond = 1.0f / deltaTime;

            _sampleBuffer.Enqueue(CurrentFramesPerSecond);

            if (_sampleBuffer.Count > MAXIMUM_SAMPLES)
            {
                _sampleBuffer.Dequeue();
                AverageFramesPerSecond = _sampleBuffer.Average(i => i);
            }
            else
            {
                AverageFramesPerSecond = CurrentFramesPerSecond;
            }

            TotalFrames++;
            TotalSeconds += deltaTime;
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            base.Draw(gameTime, batch);

            calculateFPS((float)gameTime.ElapsedGameTime.TotalSeconds);
            
            var fps = $"FPS: { Math.Round(AverageFramesPerSecond) }";
            batch.DrawString(font, fps, position, color);
        }
    }
}
