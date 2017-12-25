using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Planet_Forge_AGAIN.graphics
{
    public abstract class BaseRenderer
    {
        public abstract void Initialize();
        public abstract void Update();
        public abstract void Render();
        public abstract void Dispose();
    }
}
