﻿namespace StingyJunk.Console.Example
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    internal static class SimpleExampleConsoleWindow
    {
        private static ConsoleWindow _consoleWindow;

        private static void Main()
        {
            Thread.CurrentThread.Name = nameof(SimpleExampleConsoleWindow);
            _consoleWindow = new ConsoleWindow();
            _consoleWindow.WriteLine($"This is any kind of message {DateTime.Now.TimeOfDay}");
            _consoleWindow.WriteLine($"Press ESC to close");
            _consoleWindow.WaitForKey(ConsoleKey.Escape);
            _consoleWindow.Close();
        }
    }
}