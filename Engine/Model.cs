using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenGL.GL;

namespace WorldsOfWonder.Engine
{
    internal class Model
    {
        private uint vao;
        private uint vbo;
        private uint vertexBufferSize;

        public unsafe Model(float[] _vertexData)
        {
            vertexBufferSize = (uint)_vertexData.Length;

            vao = glGenVertexArray();
            vbo = glGenBuffer();

            glBindVertexArray(vao);
            glBindBuffer(GL_ARRAY_BUFFER, vbo);

            //This loads our vertex buffers into a specific memory address, DON'T TOUCH.
            fixed (float * _ptrVertices = &_vertexData[0])
            {
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * _vertexData.Length, _ptrVertices, GL_STATIC_DRAW);


                // Position
                glVertexAttribPointer(0, 3, GL_FLOAT, false, 6 * sizeof(float), (void*)0);
                glEnableVertexAttribArray(0);

                // Color
                glVertexAttribPointer(1, 3, GL_FLOAT, false, 6 * sizeof(float), (void*)(3 * sizeof(float)));
                glEnableVertexAttribArray(1);

                // XYZ, then RGB. XYZ, then RGB. XYZ, then RGB. XYZ, then RGB. XYZ, then RGB. XYZ, then RGB.

                glBindBuffer(GL_ARRAY_BUFFER, 0);
                glBindVertexArray(0);

            }
        }

        ~Model()
        {
            Delete();
        }

        public void BindVAO()
        {
            glBindVertexArray(vao);
        }

        public void UnBindVAO()
        {
            glBindVertexArray(0);
        }

        public uint GetVertexBufferSize()
        {
            return vertexBufferSize;
        }

        public void Delete()
        {
            glDeleteBuffer(vbo);
            glDeleteVertexArray(vao);

            vao = 0;
            vbo = 0;
        }
    }
}
