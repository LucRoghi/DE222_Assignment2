using System;

namespace SokobanLevelDesigner
{
    class Program
    {
        static void Main(string[] args)
        {
            new EditorController(new ConsoleView(), new Level(0, 0)).Go();
        }
    }
}
