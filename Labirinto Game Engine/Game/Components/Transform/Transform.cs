using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GameEngine
{
    public class Transform : Component
    {
        public Vector3 Position { get; set; } = Vector3.Zero;
        public Vector3 Rotation { get; set; } = Vector3.Zero;
        public Vector3 Scale { get; set; } = Vector3.Zero;
    }
}
