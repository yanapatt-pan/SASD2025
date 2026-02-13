using SDL3;
using System.Diagnostics;


namespace SkiaLiteUI;

// https://github.com/edwardgushchin/SDL3-CS/blob/master/SDL3-CS.Examples/Create%20Window/Program.cs
// good article on keyboard: https://wiki.libsdl.org/SDL3/BestKeyboardPractices

public class WinTest
{
    public void Run()
    {
        //RunComplexLogic();
        new GLWindow("Title", 1920, 1080).Run();  // 1. Facade make easy to call.

        //new AdapterExample.Example().Run();       // 2. Adapter
    }

    void RunComplexLogic()
    {
        // 1. SDL Init
        SDLx.Init(SDL.InitFlags.Video);

        // 2. Create Window
        int clientX = 1920;
        int clientY = 1080;
        var window = SDLx.CreateWindow("SDL3 Create Window", clientX, clientY,
                                        SDL.WindowFlags.HighPixelDensity | 
                                        SDL.WindowFlags.OpenGL | 
                                        SDL.WindowFlags.Borderless); // Don't have window border, You can't resize window.

        // https://wiki.libsdl.org/SDL3/README-highdpi
        float scale = SDL.GetWindowPixelDensity(window);

        // 3. Create GL Context
        var context = SDL.GLCreateContext(window);
        SDL.GLMakeCurrent(window, context);
        SDL.GLSetSwapInterval(1); // 1 - VSync On

        var skiaTest = new SkiaTest();
        skiaTest.Init((int)(clientX * scale), (int)(clientY * scale));

        Stopwatch timer = Stopwatch.StartNew();
        //int loopCount = 0;
        bool isLoop = true;
        while (isLoop)
        {
            while (SDL.PollEvent(out var e))
            {
                if (e.Type == (uint)SDL.EventType.Quit)
                    isLoop = false;

                else if (e.Type == (uint)SDL.EventType.KeyDown
                        && e.Key.Key == SDL.Keycode.Escape)
                    isLoop = false;
            }

            var dt = timer.Elapsed.TotalSeconds;
            timer.Restart();
            skiaTest.Render((float)dt);

            //if(loopCount % 2 == 0 )
                SDLx.GLSwapWindow(window);
            //loopCount++;
        }

        skiaTest.Dispose();
        SDL.GLDestroyContext(context);
        SDL.DestroyWindow(window);
        SDL.Quit();
    }
}
