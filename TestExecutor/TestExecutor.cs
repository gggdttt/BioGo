﻿using BioCompiler;
using Executor.Model;
using Executor;

namespace TestExecutor
{
    [TestClass]
    public class TestExecutor
    {

        Chip GetChipAndRun(string origin, int width, int length)
        {
            string content = new Runner().DoCompile(origin);
            ProcessExecutor executor = new ProcessExecutor();
            Chip c = new Chip(executor.GetOperationsListFromJSON(content), width, length);
            c.DoNextStep();
            return c;
        }


        [TestMethod]
        public void TestMultiMove()
        {
            string origin =
                "droplet d1;\r\n" +
                "droplet d2;\r\n\r\n" +
                "input(d1,1,1,1.0);\r\n" +
                "input(d2,4,4,0.5);\r\n\r\n\r\n" +
                "move(d1,3,3);\r\n" +
                "move(d2,7,7);\r\n\r\n" +
                "move(d1,3,3);\r\n" +
                "move(d2,7,7);\r\n\r\n\r\n" +
                "move(d1,3,3);\r\n" +
                "move(d2,7,7);\r\n\r\n\r\n" +
                "output(d1,0,0);\r\n" +
                "output(d2,0,0);\r\n";

            Chip c = GetChipAndRun(origin, 20, 20);
            Assert.AreEqual(true, c.manager.AllTasksCompleted());
        }

        [TestMethod]
        public void TestInputAndOuput()
        {
            string origin =
                "droplet d1;\r\n" +
                "droplet d2;\r\n\r\n" +
                "input(d1,1,1,1.0);\r\n" +
                "input(d2,4,4,0.5);\r\n" +
                "output(d1,0,0);\r\n" +
                "output(d2,0,0);\r\n";

            Chip c = GetChipAndRun(origin, 20, 20);
            Assert.AreEqual(true, c.manager.AllTasksCompleted());
        }

        [TestMethod]
        public void TestMultiInputAndOuput()
        {
            string origin =
                "droplet d1;\r\n" +
                "droplet d2;\r\n\r\n" +
                "input(d1,1,1,1.0);\r\n" +
                "input(d2,4,4,0.5);\r\n" +
                "output(d1,0,0);\r\n" +
                "output(d2,0,0);\r\n" +
                "input(d1,1,1,1.0);\r\n" +
                "input(d2,4,4,0.5);\r\n" +
                "output(d1,0,0);\r\n" +
                "output(d2,0,0);\r\n";

            Chip c = GetChipAndRun(origin, 20, 20);
            Assert.AreEqual(true, c.manager.AllTasksCompleted());
        }


        [TestMethod]
        public void TestAll()
        {
            string origin =
                "droplet d1;\r\n" +
                "droplet d2;\r\n" +
                "droplet d3;\r\n\r\n" +
                "# droplet input\r\n" +
                "input(d1,1,1,1.0);\r\n" +
                "input(d2,4,4,0.5);\r\n" +
                "input(d3,10,10,3.2);\r\n\r\n" +
                "# move\r\n" +
                "move(d1,3,3);\r\n" +
                "move(d2,7,7);\r\n" +
                "move(d3,9,9);\r\n\r\n" +
                "droplet d4;\r\n" +
                "droplet d5;\r\n" +
                "split(d4,d5,d3,12,12,15,15,0.5);\r\n\r\n" +
                "merge(d3,d4,d5,5,9);\r\n\r\n" +
                "mix(d3,2,2,2,2,5);\r\n\r\n" +
                "store(d3,5,5,2.0);\r\n\r\n" +
                "output(d1,0,0);\r\n" +
                "output(d2,0,0);\r\n" +
                "output(d3,0,0);\r\n";

            Chip c = GetChipAndRun(origin, 20, 20);
            Assert.AreEqual(true, c.manager.AllTasksCompleted());
        }


        [TestMethod]
        public void TestAllSpecialCase1()
        {
            // containing d1,d2-> d1
            string origin =
                "droplet d1;\r\n" +
                "droplet d2;\r\n" +
                "droplet d3;\r\n\r\n" +
                "# droplet input\r\n" +
                "input(d1,1,1,1.0);\r\n" +
                "input(d2,4,4,0.5);\r\n" +
                "input(d3,10,10,3.2);\r\n\r\n" +
                "move(d1,3,3);\r\n" +
                "move(d2,7,7);\r\n" +
                "move(d3,9,9);\r\n\r\n" +
                "droplet d4;\r\n" +
                "split(d4,d3,d3,12,12,15,15,0.5);\r\n\r\n" +
                "merge(d3,d4,d3,5,9);\r\n\r\n" +
                "mix(d3,2,2,2,2,5);\r\n\r\n" +
                "store(d3,5,5,2.0);\r\n\r\n" +
                "output(d1,0,0);\r\n" +
                "output(d2,0,0);\r\n" +
                "output(d3,0,0);\r\n";

            Chip c = GetChipAndRun(origin, 20, 20);
            Assert.AreEqual(true, c.manager.AllTasksCompleted());
        }
    }
}