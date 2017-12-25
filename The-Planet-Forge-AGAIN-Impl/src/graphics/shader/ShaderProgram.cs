using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace The_Planet_Forge_AGAIN.src.graphics.shader
{
    public class ShaderProgram
    {
        private int programId;

        private int vertexShaderId;

        private int fragmentShaderId;

        public ShaderProgram()
        {
            programId = GL.CreateProgram();

            if (programId == 0) {
                throw new Exception("Could not create ShaderProgramm");
            }
        }

        public void CreateVertexShader(string shaderCode)
        {
            vertexShaderId = CreateShader(shaderCode, ShaderType.VertexShader);
        }

        public void CreateFragmentShader(string shaderCode) {
            fragmentShaderId = CreateShader(shaderCode, ShaderType.FragmentShader);
        }

        private int CreateShader(string shaderCode, ShaderType shaderType)
        {
            int shaderId = GL.CreateShader(shaderType);

            if (shaderId == 0)
            {
                throw new Exception("Error creating shader. Type: " + shaderType);
            }

            GL.ShaderSource(shaderId, shaderCode);
            GL.CompileShader(shaderId);

            GL.GetShader(shaderId, ShaderParameter.CompileStatus, out int shaderState);
            if (shaderState == 0)
            {
                throw new Exception("Error compiling Shader code: " + GL.GetShaderInfoLog(shaderId));
            }

            GL.AttachShader(programId, shaderId);

            return shaderId;
        }

        public void Link()
        {
            GL.LinkProgram(programId);

            GL.GetProgram(programId, GetProgramParameterName.LinkStatus, out int programState);
            if (programState == 0)
            {
                throw new Exception("Error linking Shader code: " + GL.GetProgramInfoLog(programId));
            }

            if (vertexShaderId != 0)
            {
                GL.DetachShader(programId, vertexShaderId);
            }

            if (fragmentShaderId != 0)
            {
                GL.DetachShader(programId, fragmentShaderId);
            }

            GL.ValidateProgram(programId);

            GL.GetProgram(programId, GetProgramParameterName.ValidateStatus, out programState);
            if (programState == 0)
            {
                Console.WriteLine("Warning validating Shader code: " + GL.GetProgramInfoLog(programId));
            }

        }

        public void Bind()
        {
            GL.UseProgram(programId);
        }

        public void Unbind()
        {
            GL.UseProgram(0);
        }

        public void CleanUp()
        {
            Unbind();
            if (programId != 0)
            {
                GL.DeleteProgram(programId);
            }
        }
    }
}
