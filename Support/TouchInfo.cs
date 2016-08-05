using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;


namespace MonoGameSceneGraph.Support
{
    public class TouchInfo 
    {
        public Vector2 Position { get; private set; }
        public float Pressure { get; private set; }
        public TouchLocationState State { get; private set; }

        
        public TouchInfo(Vector2 position, float pressure, TouchLocationState state)
        {
            Position = position;
            Pressure = pressure;
            State = state;
        }

        
    }
}
