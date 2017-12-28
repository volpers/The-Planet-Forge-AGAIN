using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Planet_Forge_AGAIN.game;
using The_Planet_Forge_AGAIN.graphics;
using The_Planet_Forge_AGAIN.input;

namespace The_Planet_Forge_AGAIN.window
{
    public sealed class OpenGLMainWindow : GameWindow
    {
        private Game game;

        public OpenGLMainWindow() 
        : base(1280, // initial width
            720, // initial height
            GraphicsMode.Default,
            "The Planet Forge",  // initial title
            GameWindowFlags.Default,
            DisplayDevice.Default,
            4, // OpenGL major version
            0, // OpenGL minor version
            GraphicsContextFlags.ForwardCompatible)
        {
            Title += ": OpenGL Version: " + GL.GetString(StringName.Version);
            game = new Game(this);
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CursorVisible = true;
            game.OnLoad();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);            
            game.Update(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            Title = $"(Vsync: {VSync}) FPS: {1f / e.Time:0}";
            game.Render(e);

            SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);            
            //GL.Viewport(0, 0, Width, Height);
        }       

        public override void Exit()
        {
            base.Exit();
            game.Exit();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            game.OnClosed();
        }
    }
}
