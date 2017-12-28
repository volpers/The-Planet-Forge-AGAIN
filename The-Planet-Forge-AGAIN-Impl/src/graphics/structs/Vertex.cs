using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Planet_Forge_AGAIN.src.graphics.structs
{
    public struct Vertex
    {
        public const int SIZE = (4 + 4) * 4; //Size of struct in bytes

        private readonly Vector3 _position;
        private readonly Color4 _color;
        
        public Vertex(float x, float y, float z)
        {
            _position = new Vector3(x, y, z);
            _color = Color4.Black;
        }
    }
}
