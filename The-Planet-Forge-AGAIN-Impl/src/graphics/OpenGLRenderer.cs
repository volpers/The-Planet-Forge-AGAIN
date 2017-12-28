using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using The_Planet_Forge_AGAIN.src.graphics.shader;
using The_Planet_Forge_AGAIN.src.graphics.structs;
using The_Planet_Forge_AGAIN.src.utils;

namespace The_Planet_Forge_AGAIN.graphics
{
    public class OpenGLRenderer
    {
        private ShaderProgram shaderProgram;

        private int vboId;

        private int vaoId;

        private readonly GameWindow window;

        public OpenGLRenderer(GameWindow window) {
            this.window = window;
        }

        public void Initialize()
        {
            window.Resize += OnWindowResized;

            shaderProgram = new ShaderProgram();
            shaderProgram.CreateVertexShader(Utils.ReadResource("res/shaders/vertex.vs"));
            shaderProgram.CreateFragmentShader(Utils.ReadResource("res/shaders/fragment.fs"));
            shaderProgram.Link();

            Vertex[] vertices = new Vertex[]
            {
                new Vertex(0.0f, 0.5f, 0.0f),
                new Vertex(-0.5f, -0.5f, 0.0f),
                new Vertex(0.5f, -0.5f, 0.0f)
            };

            try
            {
                //Create the Vertex Array Object
                GL.GenVertexArrays(1, out vaoId);
                GL.BindVertexArray(vaoId);

                //Create the Vertex Buffer Object
                GL.GenBuffers(1, out vboId);
                GL.BindBuffer(BufferTarget.ArrayBuffer, vboId);
                GL.BufferData(BufferTarget.ArrayBuffer, Vertex.SIZE * vertices.Length, vertices, BufferUsageHint.StaticDraw);

                //Define structure of the data
                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

                //Unbind VBO and VAO
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                GL.BindVertexArray(0);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }       

        public void Render()
        {
            shaderProgram.Bind();

            //Bind the VAO
            GL.BindVertexArray(vaoId);
            GL.EnableVertexAttribArray(0);

            //Draw the vertices
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            //Reset everything
            GL.DisableVertexAttribArray(0);
            GL.BindVertexArray(0);

            shaderProgram.Unbind();

            GL.ClearColor(Color4.AliceBlue);
            Clear();           
            
        }

        public void Update()
        {

        }

        public void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void CleanUp()
        {
            if (shaderProgram != null)
            {
                shaderProgram.CleanUp();
            }

            GL.DisableVertexAttribArray(0);

            //Delete VBO
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(vboId);

            //Delete VAO
            GL.BindVertexArray(0);
            GL.DeleteVertexArray(vboId);
        }

        private void OnWindowResized(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
        }
    }
}
