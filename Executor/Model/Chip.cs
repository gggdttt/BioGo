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

        public OperationManager operationManager { get; set; }

        public MovementManager movementManager { get; set; }

        public Chip(List<CompilerOperation> operations, int x, int y , string router)
        {
            this.xLength = x;
            this.yLength = y;
            operationManager = new OperationManager(operations, x, y);

            if(router.ToLower().Equals("astar"))
            {
                movementManager = new MovementManager(x, y, Router.RouterOption.AStar);
            }
            else if (router.ToLower().Equals("simplexy"))
            {
                movementManager = new MovementManager(x, y, Router.RouterOption.SimpleXY);
            }
            else
            {
                // default is AStar
                movementManager = new MovementManager(x, y, Router.RouterOption.AStar);
            }
        }

        public void StartOpearions()
        {
            int i = 0;
            while (!operationManager.AllTasksCompleted())
            {
                operationManager.BeforeExecuting();
                operationManager.Executing(movementManager);
                operationManager.AfterExecute();
                i++;
            }
        }

    }
}
