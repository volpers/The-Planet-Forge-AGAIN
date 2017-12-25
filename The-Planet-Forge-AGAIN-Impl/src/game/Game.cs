using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using The_Planet_Forge_AGAIN.graphics;
using The_Planet_Forge_AGAIN.input;

namespace The_Planet_Forge_AGAIN.game
{
    /// <summary>
    /// The basic Game-Class
    /// </summary>
    public class Game
    {
        private GraphicsFactory graphicsFactory = new GraphicsFactory();
        private InputFactory inputFactory = new InputFactory();

        private OpenGLRenderer renderer;
        private OpenGLInputHandler input;

        private double timeToNextUpdateTick = 0d;
        private double timeToNextFrameTick = 0d;


        public Game()
        {
            renderer = graphicsFactory.CreateOpenGLRenderer();
            input = inputFactory.CreateOpenGLInputHandler();
        }

        internal void OnLoad()
        {
            renderer.Initialize();
        }

        internal void Update(FrameEventArgs e)
        {
            timeToNextUpdateTick += e.Time;
            if(timeToNextUpdateTick >= GameConstants.SECS_PER_UPDATE) { 
                input.Update(Keyboard.GetState());
                renderer.Update();
                timeToNextUpdateTick = 0d;
            }
        }

        internal void Render(FrameEventArgs e)
        {
            timeToNextFrameTick += e.Time;
            if(timeToNextFrameTick >= GameConstants.SECS_PER_FRAME) { 
                renderer.Render();
                timeToNextFrameTick = 0d;
            }
        }

        internal void Exit()
        {
            renderer.Dispose();
        }

        internal void OnClosed()
        {
            renderer.Dispose();   
        }
    }
}
