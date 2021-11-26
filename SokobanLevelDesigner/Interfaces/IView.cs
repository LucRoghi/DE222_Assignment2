using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanLevelDesigner
{
    public interface IView
    {
        void Start();

        void Stop();

        void Pause();

        void DisplayLevel(Level level);

        void Display<T>(T msg1);

        public string Read(string prompt);
    }
}
