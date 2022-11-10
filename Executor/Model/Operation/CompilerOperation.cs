﻿// Project:  MicroFluidCompiler  
// Author: Wenjie Fan (s210310)
// Department: Applied Mathematics and Computer Science
// DTU(Technical University of Denmark)

namespace Executor.Model.Operation
{

    public interface CompilerOperation
    {
        public int getLine();
        public void Executed();
        public bool DeclarationCheck(HashSet<string> declaredSet, HashSet<string> occupiedSet);
    }
}
