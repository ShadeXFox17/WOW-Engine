using System;
using GLFW;
using WorldsOfWonder.Engine;
using static OpenGL.GL;

class Program
{
    static void Main(string[] args)
    {
        WindowManager.CreateWindow(1280, 720, "Engine");
        WindowManager.ClearColor = new System.Numerics.Vector4(1,0,1,1);

        Shader _shader = new Shader("Shader/modelShader.vs", "Shader/modelShader.fs");

        float[] _vertices = {
                -0.5f,  0.5f, 1.0f,     1.0f, 0.0f, 0.0f, // top left
                 0.5f,  0.5f, 1.0f,     1.0f, 0.0f, 0.0f, // top right
                -0.5f, -0.5f, 1.0f,     0.0f, 1.0f, 0.0f, // bottom left
                                                   
                 0.5f,  0.5f, 1.0f,     1.0f, 0.0f, 0.0f, // top right
                 0.5f, -0.5f, 1.0f,     1.0f, 1.0f, 0.0f, // bottom right
                -0.5f, -0.5f, 1.0f,     0.0f, 1.0f, 0.0f, // bottom left
            };

        Model _model = new Model(_vertices);

        while (!Glfw.WindowShouldClose(WindowManager.Window))
        {
            Glfw.PollEvents();

            // Update


            // Render
            glClearColor(WindowManager.ClearColor.X, WindowManager.ClearColor.Y, WindowManager.ClearColor.Z, WindowManager.ClearColor.W);
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

            _shader.Bind();

            _model.BindVAO();
            glDrawArrays(GL_TRIANGLES, 0, (int)_model.GetVertexBufferSize());
            _model.UnBindVAO();


            Glfw.SwapBuffers(WindowManager.Window);
        }

        WindowManager.CloseWindow();
    }
}