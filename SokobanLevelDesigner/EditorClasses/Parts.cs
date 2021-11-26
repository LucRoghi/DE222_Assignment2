using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanLevelDesigner
{
    public enum Part
    {
        Wall = '#',
        Empty = '-',
        Player = '@',
        Goal = '.',
        Block = '$',
        BlockOnGoal = '*',
        PlayerOnGoal = '+'
    }
}
