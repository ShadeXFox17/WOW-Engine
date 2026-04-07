using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GLFW;
using static OpenGL.GL;

namespace WorldsOfWonder.Engine
{
    internal class WindowManager
    {
        public static Window Window { get; private set; }
        public static Vector2 WindowSize { get; private set; }
        public static Vector4 ClearColor { get; set; }

        public static unsafe void CreateWindow(int _width, int _height, string _title)
        {
            WindowSize = new Vector2(_width, _height);

            Glfw.Init();

            // OpenGL 3.3 core; this refers to a specific instance of OpenGL.
            // Btw, this is the window config code.
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);

            Glfw.WindowHint(Hint.Focused, true);
            Glfw.WindowHint(Hint.Resizable, false);

            // Open the window
            Window = Glfw.CreateWindow(_width, _height, _title, GLFW.Monitor.None, Window.None);

            if (Window == Window.None)
            {
                Console.WriteLine("Failed to create game window. Whoops!");
                return;
            }

            // Set window size and position.
            Rectangle _screen = Glfw.PrimaryMonitor.WorkArea;
            int _x = (_screen.Width - _width) / 2;
            int _y = (_screen.Height - _height) / 2;

            Glfw.SetWindowPosition(Window, _x, _y);

            Glfw.MakeContextCurrent(Window);

            // Import all OpenGL functions.
            Import(Glfw.GetProcAddress);

            glViewport(0, 0, _width, _height);

            // GL Setting
            Glfw.SwapInterval(0); // VSync

            glClearDepth(1);

            glEnable(GL_BLEND);
            glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

            glEnable(GL_DEPTH_TEST);
            glDepthFunc(GL_LEQUAL);

            // Error handler.
            Glfw.SetErrorCallback((code, message) => { Console.WriteLine($"GLFW ERROR: {code} {message}");});
            // That line fuckin hurts to look at but I'm keeping it that way so it looks clean...
        }

        public static void CloseWindow()
        {
            Glfw.DestroyWindow(Window);
            Glfw.Terminate();
        }
    }
}
