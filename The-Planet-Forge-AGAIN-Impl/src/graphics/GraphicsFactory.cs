using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Planet_Forge_AGAIN.graphics
{
    public class GraphicsFactory
    {
        public OpenGLRenderer CreateOpenGLRenderer(GameWindow window) {
            return new OpenGLRenderer(window);
        }
    }
}
