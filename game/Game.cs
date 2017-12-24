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
    public class Game
    {
        private GraphicsFactory graphicsFactory = new GraphicsFactory();
        private InputFactory inputFactory = new InputFactory();

        private OpenGLRenderer renderer;
        private OpenGLInputHandler input;

        public Game()
        {
            renderer = graphicsFactory.CreateOpenGLRenderer();
            input = inputFactory.CreateOpenGLInputHandler();
        }

        internal void OnLoad()
        {
            renderer.Initialize();
        }

        internal void Update()
        {
            input.Update(Keyboard.GetState());
            renderer.Update();
        }

        internal void Render()
        {
            renderer.Render();
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
