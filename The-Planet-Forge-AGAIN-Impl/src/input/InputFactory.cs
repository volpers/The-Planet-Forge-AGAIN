using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Planet_Forge_AGAIN.input
{
    public class InputFactory
    {
        public OpenGLInputHandler CreateOpenGLInputHandler() {
            return new OpenGLInputHandler();
        }
    }
}
