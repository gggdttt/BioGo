﻿// Project:  MicroFluidCompiler  
// Author: Wenjie Fan (s210310)
// Department: Applied Mathematics and Computer Science
// DTU(Technical University of Denmark)


using ToolSupporter.BioExceptions;

namespace Executor.Model.Operation
{
    /// <summary>
    /// merge(<out_dest_droplet_name>,<in_1_droplet_name>,<in_2_droplet_name>,x_dest,y_dest
    ///         string, string, string, int, int 
    /// </summary>
    public class DropletMerger : CompilerOperation
    {

        public int line { get; }
        public string outDropletName { get; }
        public string inDroplet1Name { get; }
        public string inDroplet2Name { get; }
        public int xDest { get; }
        public int yDest { get; }

        private double mergedSize { get; set; }

        public DropletMerger(string outDropletName, string inDroplet1Name, string inDroplet2Name, int xValue, int yValue, int line)
        {
            this.outDropletName = outDropletName;
            this.inDroplet1Name = inDroplet1Name;
            this.inDroplet2Name = inDroplet2Name;
            xDest = xValue;
            yDest = yValue;
            this.line = line;
        }

        public int GetLine()
        {
            return line;
        }

        /// <summary>
        /// If its name is not in declaredSet, return false 
        /// If it has been included in, return true and move it from declared Set to occupiedSet
        /// </summary>
        /// <param name="declaredSet"></param>
        /// <param name="occupiedSet"></param>
        public void DeclarationCheck(HashSet<string> declaredSet, HashSet<string> occupiedSet)
        {

            if (declaredSet.Contains(outDropletName)
                && occupiedSet.Contains(inDroplet1Name)
                && occupiedSet.Contains(inDroplet2Name))
            {
                declaredSet.Remove(outDropletName);
                occupiedSet.Add(outDropletName);

                occupiedSet.Remove(inDroplet1Name);
                declaredSet.Add(inDroplet1Name);

                occupiedSet.Remove(inDroplet2Name);
                declaredSet.Add(inDroplet2Name);
            }
            else if (occupiedSet.Contains(outDropletName)
                && occupiedSet.Contains(inDroplet1Name)
                && occupiedSet.Contains(inDroplet2Name)
                && (outDropletName.Equals(inDroplet1Name) || outDropletName.Equals(inDroplet2Name))
                && !inDroplet1Name.Equals(inDroplet2Name))
            { //merge(d1,d2,d1,....) d1,d2 ->d1
              // do nothing
            }
            else if (!occupiedSet.Contains(inDroplet1Name) && declaredSet.Contains(inDroplet1Name)
                || !occupiedSet.Contains(inDroplet2Name) && declaredSet.Contains(inDroplet2Name))
            {
                throw new VariableNotAssignedValueException(line);
            }
            else if(occupiedSet.Contains(outDropletName))
            {
                throw new VariableNotReleasedException(line);
            }
            // TODO: need to check the logic here carefully.
            else throw new DropletNotDeclaredException(line);
        }

        public bool IsExecutable(List<Droplet> activeDroplets, List<Droplet> busyDroplets)
        {
            // special case1: d1 d2  -> d1 
            if (outDropletName.Equals(inDroplet1Name)
                && !outDropletName.Equals(inDroplet2Name)
                && activeDroplets.Where(droplet => droplet.name.Equals(inDroplet1Name)).Count() == 1
                && activeDroplets.Where(droplet => droplet.name.Equals(inDroplet2Name)).Count() == 1)
            {
                Active2Busy(activeDroplets, busyDroplets);
                return true;
            }
            // special case2:  d2 d1 ->d1
            if (outDropletName.Equals(inDroplet2Name)
                && !outDropletName.Equals(inDroplet1Name)
                && activeDroplets.Where(droplet => droplet.name.Equals(outDropletName)).Count() == 1
                && activeDroplets.Where(droplet => droplet.name.Equals(inDroplet1Name)).Count() == 1)
            {
                Active2Busy(activeDroplets, busyDroplets);
                return true;
            }

            // the out droplet does not exist
            // the in droplet1 and indroplet2 are in activeDroplets 
            if (activeDroplets.Where(droplet => droplet.name.Equals(outDropletName)).Count() == 0
                && activeDroplets.Where(droplet => droplet.name.Equals(inDroplet1Name)).Count() == 1
                && activeDroplets.Where(droplet => droplet.name.Equals(inDroplet2Name)).Count() == 1)
            {
                Active2Busy(activeDroplets, busyDroplets);
                return true;
            }
            return false;
        }

        private void Active2Busy(List<Droplet> activeDroplets, List<Droplet> busyDroplets)
        {
            // input1, input2: active -> busy
            Droplet d1 = activeDroplets.Where(droplet => droplet.name.Equals(inDroplet1Name)).First();
            Droplet d2 = activeDroplets.Where(droplet => droplet.name.Equals(inDroplet2Name)).First();
            activeDroplets.Remove(d1);
            activeDroplets.Remove(d2);
            busyDroplets.Add(d1);
            busyDroplets.Add(d2);
        }

        public void ExecuteOperation(List<Droplet> activeDroplets, List<Droplet> busyDroplets, MovementManager manager)
        {
            // after executing, a new droplet will generate
            // outDroplet will be added to active droplets
            Droplet d1 = busyDroplets.Where(droplet => droplet.name.Equals(inDroplet1Name)).First();
            Droplet d2 = busyDroplets.Where(droplet => droplet.name.Equals(inDroplet2Name)).First();

            // if they have both arrived at the position
            if (d1.xValue == xDest && d2.xValue == xDest && d1.yValue == yDest && d2.yValue == yDest)
            {
                busyDroplets.Remove(d1);
                busyDroplets.Remove(d2);
                activeDroplets.Add(new Droplet(outDropletName, xDest, xDest, d1.volume + d2.volume));
                mergedSize = d1.volume + d2.volume;
            }
            else
            {
                // TODO: Consider the process of merger.
                if (d1.xValue != xDest || d1.yValue != yDest)
                    manager.MoveByOneStep(d1, xDest, yDest, activeDroplets, busyDroplets);
                if (d2.xValue != xDest || d2.yValue != yDest)
                    manager.MoveByOneStep(d2, xDest, xDest, activeDroplets, busyDroplets);
            }
        }

        public bool HasExecuted(List<Droplet> activeDroplets, List<Droplet> busyDroplets)
        {
            List<Droplet> tempList = activeDroplets.Where(droplet => droplet.name.Equals(outDropletName)).ToList();
            return
                tempList != null
                && activeDroplets.Where(droplet => droplet.name.Equals(outDropletName)).Count() == 1
                && tempList.First().xValue == xDest
                && tempList.First().yValue == yDest
                && tempList.First().volume == mergedSize;
        }

        public override string ToString()
        {
            return "DropletMerger: " + " outDropletName:" + outDropletName
                + " inDroplet1Name:" + inDroplet1Name + " inDroplet2Name:" + inDroplet2Name;
        }

    }
}
