﻿using BioCompiler;
using ToolSupporter.BioExceptions;

namespace TestCompiler.SignleOperationTest
{
    [TestClass]
    public class DropletOutputterTest
    {

        //===========================================================================================//
        //                                                                                           //
        //                                    Test for Function                                      //
        //                                                                                           //
        //===========================================================================================//

        /// <summary>
        /// Basic use of Output
        /// </summary>
        [TestMethod]
        public void OutputFunctionalityTest1()
        {
            string origin =
                "droplet d1;\r\n" +
                "input(d1,15,15,0.1);\r\n" +
                "move(d1,3,3);\r\n" +
                "output(d1,0,0);\r\n";
            string expect = "[\r\n  {\r\n    \"$type\": \"Executor.Model.Operation.DropletDeclarator, Executor\",\r\n    \"name\": \"d1\",\r\n    \"line\": 1\r\n  },\r\n  {\r\n    \"$type\": \"Executor.Model.Operation.DropletInputer, Executor\",\r\n    \"line\": 2,\r\n    \"name\": \"d1\",\r\n    \"xValue\": 15,\r\n    \"yValue\": 15,\r\n    \"size\": 0.1\r\n  },\r\n  {\r\n    \"$type\": \"Executor.Model.Operation.DropletMover, Executor\",\r\n    \"line\": 3,\r\n    \"name\": \"d1\",\r\n    \"xDest\": 3,\r\n    \"yDest\": 3\r\n  },\r\n  {\r\n    \"$type\": \"Executor.Model.Operation.DropletOutputer, Executor\",\r\n    \"line\": 4,\r\n    \"name\": \"d1\",\r\n    \"xValue\": 0,\r\n    \"yValue\": 0\r\n  }\r\n]";
            string result = new Runner().DoCompile(origin);
            Assert.AreEqual(expect, result);
        }


        //===========================================================================================//
        //                                                                                           //
        //                                    Test for Robustness                                    //
        //                                                                                           //
        //===========================================================================================//

        /// <summary>
        /// D1 is declared but not input
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(VariableNotAssignedValueException))]
        public void DropletDeclaredButNotAssignedValue()
        {
            string origin =
                "droplet d1;\r\n" +
                "output(d1,3,3);\r\n";
            new Runner().DoCompile(origin);
        }

        /// <summary>
        /// D1 is not declared and not input
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DropletNotDeclaredException))]
        public void DropletNotDeclared()
        {
            string origin = "output(d1,3,3);\r\n";
            new Runner().DoCompile(origin);
        }

        /// <summary>
        /// Key word error
        /// </summary>
        [TestMethod]
        public void KeyWordError()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetError(sw);
                string origin =
                    "droplet d1;\r\n" +
                    "input(d1,15,15,0.1);\r\n" +
                    "outputtttt(d1,3,3);\r\n";
                new Runner().DoCompile(origin);
                Assert.IsFalse(string.IsNullOrEmpty(sw.ToString()));
            }
        }


        /// <summary>
        /// Even output, the droplet does not need to declare again
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DropletDeclaredMoreThanOnceException))]
        public void OutputtedDropletDeclaredAgain()
        {
            string origin =
                "droplet d1;\r\n" +
                "input(d1,15,15,0.1);\r\n" +
                "output(d1,3,3);\r\n" +
                "droplet d1;\r\n";
            new Runner().DoCompile(origin);
        }


    }
}
