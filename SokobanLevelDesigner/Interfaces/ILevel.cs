using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanLevelDesigner
{
        public interface ILevel 
    {
        Level CreateLevel(int width, int height);
        int GetLevelWidth();
        int GetLevelHeight();
        bool AddBlock(int gridX, int gridY);
        bool AddBlockRow(int gridY);
        bool AddBlockColumn(int gridX);
        bool AddPlayer(int gridX, int gridY);
        bool AddWall(int gridX, int gridY);
        bool AddWallRow(int gridY);
        bool AddWallColumn(int gridX);
        bool AddGoal(int gridX, int gridY);
        bool AddEmpty(int gridX, int gridY);
        bool AddEmptyRow(int gridY);
        bool AddEmptyColumn(int gridX);
        bool AddBlockOnGoal(int gridX, int gridY);
        bool AddBlockOnGoalRow(int gridY);
        bool AddBlockOnGoalColumn(int gridX);
        bool AddPlayerOnGoal(int gridX, int gridY);
        char GetPartAtIndex(int gridX, int gridY);
        void SaveMe();
        bool CheckValid();
    }


}

