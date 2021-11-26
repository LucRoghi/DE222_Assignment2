using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanLevelDesigner
{
    public class EditorController
    {
        private IView _view;
        public ILevel _level;
        public Level _createdLevel;
        

        public EditorController(IView view, ILevel level) 
        {
            _view = view;
            _level = level;
        }

            public void Go() 
        {
            _view.Start();
            if (_view.Read("Would like to create a new level (Y/N)? ") == "Y")
            {
                NewEditorInstance();
                while (true) 
                {
                    Menu();              
                }
            }
        }

        public Dictionary<int, Delegate> InstantiateFunctionDictionary() 
        {
            var functionDictionary = new Dictionary<int, Delegate>();
            functionDictionary[1] = new Func<int, int, bool>(_level.AddBlock);
            functionDictionary[2] = new Func<int, int, bool>(_level.AddBlockOnGoal);
            functionDictionary[3] = new Func<int, int, bool>(_level.AddPlayer);
            functionDictionary[4] = new Func<int, int, bool>(_level.AddPlayerOnGoal);
            functionDictionary[5] = new Func<int, int, bool>(_level.AddGoal);
            functionDictionary[6] = new Func<int, int, bool>(_level.AddWall);
            functionDictionary[7] = new Func<int, int, bool>(_level.AddEmpty);
            return functionDictionary;
    }

        public void NewEditorInstance() 
        {
            int height = Int16.Parse(_view.Read("What is the desired height of the level? "));
            int width = Int16.Parse(_view.Read("What is the desired width of the level? "));
            _createdLevel = _level.CreateLevel(width, height);
            _view.Display($"A sokoban level with dimension {_createdLevel._width} x {_createdLevel._height} had been created");
            _view.DisplayLevel(_createdLevel);
            _view.Pause();
        }

        public void Menu()
        {
             int rowEdit = -5;
            int columnEdit = -5;
            int gridX = -5;
            int gridY = -5;
            _view.Start();
            string editMode = _view.Read($"Would you like to edit a row, column or coordinate? ");
            try
            {
                if (editMode == "row")
                { 
                    rowEdit = Int16.Parse(_view.Read($"Input the row to edit: "));
                }
                else if (editMode == "column") 
                { 
                    columnEdit = Int16.Parse(_view.Read($"Input the column to edit: ")); 
                }
                else if (editMode == "coordinate") 
                { 
                    gridX = Int16.Parse(_view.Read($"Input the X coordinate to edit (grid starts at 0,0): "));
                    gridX = Int16.Parse(_view.Read($"Input the Y coordinate to edit (grid starts at 0,0): "));
                }
                else 
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException) 
            {
                _view.Display("Input must be row, column or coordinate");
                _view.Pause();
                Menu();
            }

            if (gridX != -5 && gridY != -5)
            {
                setCoordinate(gridX, gridY);
            }
            else if (rowEdit != -5)
            {
                setRow(rowEdit);
            }
            else if (columnEdit != -5) 
            {
                setColumn(columnEdit);
            }
        }

        public void entityOptions() 
        {
            _view.Display("Items placeable on the level: ");
            _view.Display("1. Block");
            _view.Display("2. Block on Goal");
            _view.Display("3. Player");
            _view.Display("4. Player on Goal");
            _view.Display("5. Goal");
            _view.Display("6. Wall");
            _view.Display("7. Empty");
        }

        public void setCoordinate(int gridX, int gridY)
        {
            entityOptions();
            Dictionary<int, Delegate> options = InstantiateFunctionDictionary();
            int selection = Int16.Parse(_view.Read("Which entity would you like placed? "));
            options[selection].DynamicInvoke(gridX, gridY);
            _view.DisplayLevel(_createdLevel);
            _view.Pause();
        }

        public void setRow(int gridY) 
        {
            entityOptions();
            Dictionary<int, Delegate> options = InstantiateFunctionDictionary();
            int selection = Int16.Parse(_view.Read("Which entity would you like placed? "));
            for (int j = 0; j < _createdLevel._width; j++)
            {
                options[selection].DynamicInvoke(j, gridY);
            }
            _view.DisplayLevel(_createdLevel);
            _view.Pause();
        }

        public void setColumn(int gridx)
        {
            entityOptions();
            Dictionary<int, Delegate> options = InstantiateFunctionDictionary();
            int selection = Int16.Parse(_view.Read("Which entity would you like placed? "));
            for (int j = 0; j < _createdLevel._height; j++)
            {
                options[selection].DynamicInvoke(gridx, j);
            }
            _view.DisplayLevel(_createdLevel);
            _view.Pause();
        }
    }
}
