using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Planet_Forge_AGAIN.game
{
    public class GameConstants
    {
        public const int WIDTH = 1280;
        public const int HEIGHT = 720;

        public const int TARGET_FPS = 60;
        public const int TARGET_UPS = 30;

        public const double SECS_PER_FRAME = 1.0d / TARGET_FPS;
        public const double SECS_PER_UPDATE = 1.0d / TARGET_UPS;
    }
}
