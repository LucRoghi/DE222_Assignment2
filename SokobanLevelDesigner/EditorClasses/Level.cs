using System;
using System.Collections.Generic;


namespace SokobanLevelDesigner
{
    public class Level : ILevel
    {
        // Create the level with a set height and width
        public int _height;
        public int _width;
        // Create the storage to hold the grid
        // The grid is made of a 2d dimensional array. This is because the coordinates of the grid are on a 2d plane with x and y coordinates
        // However the coordinates follow the same convention as a matrix. Hence, x travels left till right but y travels from top to bottom.
        // The coordinates are layed out as (y, x)
        public char[,] _level_grid;
        // Create the object with initial attributes of height and width being defined
        public Level(int width, int height)
        {
            _height = height;
            _width = width;

            //The level grid is created then populated with empty entities until the user defines otherwise
            _level_grid = new char[_height, _width];

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    _level_grid[x, y] = (char)Part.Empty;
                }
            }
        }
        // Method to set a coordinate to a block entity
        public bool AddBlock(int gridX, int gridY)
        {
            this._level_grid[gridY, gridX] = (char)Part.Block;
            return true;
        }

        public bool AddBlockColumn(int gridX)
        {
            for (int y = 0; y < this._height; y++) 
            {
                this.AddBlock(y, gridX);
            }
            return true;
        }
        public bool AddBlockRow(int gridY)
        {
            for (int x = 0; x < this._width; x++)
            {
                this.AddBlock(gridY, x);
            }
            return true;
        }

        // Method to set a coordinate to a block on goal entity
        public bool AddBlockOnGoal(int gridX, int gridY)
        {
            this._level_grid[gridY, gridX] = (char)Part.BlockOnGoal;
            return true;
        }

        public bool AddBlockOnGoalRow(int gridY) 
        {
            for (int x = 0; x < this._width; x++)
            {
                this.AddBlockOnGoal(gridY, x);
            }
            return true;
        }

        public bool AddBlockOnGoalColumn(int gridX) 
        {
            for (int y = 0; y < this._height; y++)
            {
                this.AddBlockOnGoal(y, gridX);
            }
            return true;
        }

        // Method to set a coordinate to a empty entity
        public bool AddEmpty(int gridX, int gridY)
        {
            this._level_grid[gridY, gridX] = (char)Part.Empty;
            return true;
        }

        public bool AddEmptyRow(int gridY)
        {
            for (int x = 0; x < this._width; x++)
            {
                this.AddEmpty(x, gridY);
            }
            return true;
        }

        public bool AddEmptyColumn(int gridX)
        {
            for (int y = 0; y < this._height; y++)
            {
                this.AddEmpty(gridX, y);
            }
            return true;
        }

        // Method to set a coordinate to a goal entity
        public bool AddGoal(int gridX, int gridY)
        {
            this._level_grid[gridY, gridX] = (char)Part.Goal;
            return true;
        }

        // Method to set a coordinate to a player entity
        public bool AddPlayer(int gridX, int gridY)
        {
            this._level_grid[gridY, gridX] = (char)Part.Player;
            return true;
        }

        // Method to set a coordinate to a player on top of a goal entity
        public bool AddPlayerOnGoal(int gridX, int gridY)
        {
            this._level_grid[gridY, gridX] = (char)Part.PlayerOnGoal;
            return true;
        }

        // Method to set a coordinate to a wall entity
        public bool AddWall(int gridX, int gridY)
        {
            this._level_grid[gridY, gridX] = (char)Part.Wall;
            return true;
        }

        public bool AddWallColumn(int gridX)
        {
            for (int y = 0; y < this._height; y++)
            {
                this.AddWall(y, gridX);
            }
            return true;
        }

        public bool AddWallRow(int gridY)
        {
            for (int x = 0; x < this._width; x++)
            {
                this.AddWall(gridY, x);
            }
            return true;
        }

        // Method to check if the nessecary blocks are placed on the level in order to complete it
        // This method does not check if the level is possible as it does not include any pathing algorthms
        public bool CheckValid()
        {
            bool hasPlayer = false;
            bool hasGoal = false;
            bool hasBlock = false;
            bool hasPlayerOnGoal = false;
            bool hasBlockOnGoal = false;

            foreach (char entity in this._level_grid)
            {
                if (entity == (char)Part.Player) { hasPlayer = true; }
                else if ((entity == (char)Part.Player) && (hasPlayer = true)) { return false; }
                else if (entity == (char)Part.Goal) { hasGoal = true; }
                else if (entity == (char)Part.Block) { hasBlock = true; }
                else if (entity == (char)Part.PlayerOnGoal) { hasPlayerOnGoal = true; }
                else if (entity == (char)Part.BlockOnGoal) { hasBlockOnGoal = true; }
            }

            if ((hasPlayer && hasGoal && hasBlock || (hasPlayerOnGoal && hasBlockOnGoal)) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // This method return a new instance of the level class with the height and width defined
        public Level CreateLevel(int width, int height)
        {
            return new Level(width, height);
        }

        // Returns the height of the level
        public int GetLevelHeight()
        {
            return this._height;
        }

        // Returns the width of the level
        public int GetLevelWidth()
        {
            return this._width;
        }

        // Returns the entity at the coordinate
        public char GetPartAtIndex(int gridX, int gridY)
        {
            return _level_grid[gridY, gridX];
        }

        // Method to be able to write the edited level to a file
        // Not yet implemented.
        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        
    }
}
