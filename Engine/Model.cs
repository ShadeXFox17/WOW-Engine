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

        private unsafe Model(float[] _vertexData)
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

            }
        }
    }
}
