using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace The_Planet_Forge_AGAIN.graphics
{
    public class OpenGLRenderer : BaseRenderer
    {
        public override void Dispose()
        {
            
        }

        public override void Initialize()
        {
            
        }

        public override void Render()
        {
            

            Color4 backColor;
            backColor.A = 1.0f;
            backColor.R = 0.1f;
            backColor.G = 0.1f;
            backColor.B = 0.3f;
            GL.ClearColor(backColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SwapBuffers();
        }

        public override void Update()
        {

        }
    }
}
