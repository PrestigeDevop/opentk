﻿using System;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenTK.Windowing.Desktop
{
    internal static class Joysticks
    {
        public static event GLFWCallbacks.JoystickCallback JoystickCallback;

        private static readonly GLFWCallbacks.JoystickCallback _joystickCallback;

        static Joysticks()
        {
            GLFWProvider.EnsureInitialized();

            if (!GLFWProvider.IsOnMainThread)
            {
                throw new InvalidOperationException("Only GLFW main thread can access this class.");
            }

            _joystickCallback = (id, state) => JoystickCallback(id, state);

            GLFW.SetJoystickCallback(_joystickCallback);
        }
    }
}
