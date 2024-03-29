﻿// Project:  MicroFluidCompiler  
// Author: Wenjie Fan (s210310)
// Department: Applied Mathematics and Computer Science
// DTU(Technical University of Denmark)


using ToolSupporter.BioExceptions;

namespace Executor.Model.Operation
{
    /// <summary>
    /// move(<droplet_name>, x_dest, y_dest);
    ///         string, int ,int 
    /// </summary>
    public class DropletMover : CompilerOperation
    {

        public int line { get; }
        public string name { get; }
        public int xDest { get; }
        public int yDest { get; }

        public DropletMover(string name, int xDest, int yDest, int line)
        {
            this.name = name;
            this.xDest = xDest;
            this.yDest = yDest;
            this.line = line;
        }

        public int GetLine()
        {
            return line;
        }

        /// <summary>
        /// If occ and dec both not have the droplet, the droplet is not declared
        /// If occ contains but dec does not, the droplet is declared but not input, so not assigned
        /// </summary>
        /// <param name="declaredSet"></param>
        /// <param name="occupiedSet"></param>
        /// <returns></returns>
        public void DeclarationCheck(HashSet<string> declaredSet, HashSet<string> occupiedSet)
        {
            if (!occupiedSet.Contains(name) && !declaredSet.Contains(name))
                throw new DropletNotDeclaredException(line);
            else if(!occupiedSet.Contains(name) && declaredSet.Contains(name))
                throw new VariableNotAssignedValueException(line);
            
        }

        public bool IsExecutable(List<Droplet> activeDroplets, List<Droplet> busyDroplets)
        {
            if (activeDroplets.Where(droplet => droplet.name.Equals(name)).Count() == 1)
            {
                Active2Busy(activeDroplets, busyDroplets);
                return true;
            }
            return false;
        }

        private void Active2Busy(List<Droplet> activeDroplets, List<Droplet> busyDroplets)
        {
            //droplet active->busy
            Droplet d1 = activeDroplets.Where(droplet => droplet.name.Equals(name)).First();
            activeDroplets.Remove(d1);
            busyDroplets.Add(d1);
        }

        public void ExecuteOperation(List<Droplet> activeDroplets, List<Droplet> busyDroplets, MovementManager manager)
        {
            List<Droplet> temp = busyDroplets.Where(droplet => droplet.name.Equals(name)).ToList();
            // If it has not moved to dest
            if (temp != null && (temp.First().xValue != xDest || temp.First().yValue != yDest))
            {
                manager.MoveByOneStep(temp.First(), xDest, yDest, activeDroplets, busyDroplets);
            }

            // Check if it has moved to dest after the this movement
            // If it has moved to dest successfully, remove it from busy droplets and add it to active droplets
            if (temp != null && temp.First().xValue == xDest && temp.First().yValue == yDest)
            {
                busyDroplets.Remove(temp.First());
                activeDroplets.Add(temp.First());
            }
        }

        public bool HasExecuted(List<Droplet> activeDroplets, List<Droplet> busyDroplets)
        {
            List<Droplet> testDroplets = activeDroplets.Where(droplet => droplet.name.Equals(name)).ToList();
            return testDroplets.Count() == 1
                && testDroplets.First().xValue == xDest
                && testDroplets.First().yValue == yDest;
        }

        public override string ToString()
        {
            return "DropletMover: " + name;
        }
    }
}
