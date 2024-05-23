using System.Collections.Generic;
using System.Drawing;

namespace Assignment7_V2
{
    class MapObjectives
    {
        #region ----- PROPERTIES
        /// <summary>A list of objectives containing completionstatus and objectivedata</summary>
        public List<Objectives> ObjectiveList { get => objectiveList; set => objectiveList = value; }
        List<Objectives> objectiveList;
        #endregion

        #region ----- CONSTRUCTOR
        /// <summary>Constructor generating a list of objectives </summary>
        public MapObjectives()
        {
            objectiveList = new List<Objectives>();

            int i = 0;
            bool recursion = true;

            do // a recursive loop generating all objectives upon constructing
            {
                var newObjective = new Objectives(i++);
                recursion = newObjective.ObjectiveData.CreateObjectiveData();
                objectiveList.Add(newObjective);
            } while (recursion);
        }
        #endregion

        #region ----- METHODS
        /// <summary>Updates objective completionstatus for an objective if it's location is being targeted</summary>
        /// <param name="location">Current target location</param>
        public void UpdateObjective(Point location)
        {
            foreach (Objectives item in objectiveList)
            {
                if (item.ObjectiveData.Location == location)
                {
                    item.CompletionStatus = true;
                    break;
                }
            }
        }

        /// <summary>Finds and returns objective message</summary>
        /// <param name="point">@Target location</param>
        /// <returns></returns>
        public string FindObjective(Point point)
        {
            string message = string.Empty;

            foreach (Objectives item in objectiveList) // itterates objective list
            {
                int x = item.ObjectiveData.Location.X; // current itteration coordinates
                int y = item.ObjectiveData.Location.Y;

                if (point.X == x && point.Y == y) // matches current with input coordinates
                {
                    message = item.ObjectiveData.Message;
                    break;
                }
            }

            return message;
        }

        /// <summary>Returns an objective based on a point - used for map interaction</summary>
        /// <param name="point">Targeted point</param>
        public Objectives FindObjectiveX(Point point)
        {
            Objectives obj = null; // creates an empty objective

            foreach (Objectives item in objectiveList) // itterates all objectives in the list
            {
                int x = item.ObjectiveData.Location.X;
                int y = item.ObjectiveData.Location.Y;

                if (point.X == x && point.Y == y) // compares input point to current objective point
                {
                    obj = item; // and returns the objective if it's a match
                    break;
                }
            }

            return obj;
        }
        #endregion

    }
}