using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment7_V2
{
    class Objectives
    {
        #region ----- PROPERTIES
        /// <summary>Data for each objective</summary>
        public ObjectiveData ObjectiveData { get => objectiveData; set => objectiveData = value; }
        private ObjectiveData objectiveData;

        /// <summary>Property for completionstatus of quests belonging to a map</summary>
        public bool CompletionStatus { get => completionStatus; set => completionStatus = value; }
        private bool completionStatus;
        #endregion

        /// <summary>Constructor with input recursive itteration used to create new objective data</summary>
        /// <param name="recursion"></param>
        public Objectives(int recursion)
        {
            this.completionStatus = false; // naturally all objectives are set to incomplete upon creation
            this.objectiveData = new ObjectiveData(recursion);
        }
    }
}