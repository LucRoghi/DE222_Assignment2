using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanLevelDesigner
{
    public class ConsoleView : IView
    {
        public void Display<T>(T msg1)
        {
            Console.WriteLine(msg1);
        }
        public void DisplayLevel(Level level)
        {
            for (int y = 0; y < level._height; y++)
            {
                for (int x = 0; x < level._width; x++)
                {
                    Console.Write(level._level_grid[y, x] + " ");
                }
                Console.WriteLine();
            }
        }

        public string Read(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public void Start()
        {
            Console.Clear();
        }

        public void Stop()
        {
            Console.WriteLine("Press any key to finish");
            Console.ReadKey();
        }

        public void Pause()
        {
            Console.WriteLine("Pres any key to continue");
            Console.ReadKey();
        }

    }
}

