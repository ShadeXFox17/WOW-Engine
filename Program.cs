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

        while (!Glfw.WindowShouldClose(WindowManager.Window))
        {
            Glfw.PollEvents();

            // Update


            // Render
            glClearColor(WindowManager.ClearColor.X, WindowManager.ClearColor.Y, WindowManager.ClearColor.Z, WindowManager.ClearColor.W);
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);



            Glfw.SwapBuffers(WindowManager.Window);
        }

        WindowManager.CloseWindow();
    }
}