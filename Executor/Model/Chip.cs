﻿using Executor.Model.Operation;


namespace Executor.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Chip
    {

        int xLength;

        int yLength;

        public OperationManager manager { get; set; }

        public Chip(List<CompilerOperation> operations, int x, int y)
        {
            this.xLength = x;
            this.yLength = y;
            manager = new OperationManager(operations, x, y);
        }

        public void DoNextStep()
        {
            int i = 0;
            while (!manager.AllTasksCompleted() && i < 20)
            {
                manager.BeforeExecuting();
                manager.Executing();
                manager.AfterExecute();
                i++;
                Console.WriteLine("i=" + i);
            }
            Console.WriteLine("Executing completed!");
        }

    }
}
