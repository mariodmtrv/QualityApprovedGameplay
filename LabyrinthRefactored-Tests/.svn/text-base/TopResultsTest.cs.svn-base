namespace LabyrinthRefactoredTests
{
    using System;
    using LabyrinthRefactored;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class TopResultsTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }

            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void TryQualify_WhenResultIs5BoardIsFullWorstIs4_ShouldNotQualify()
        {
            TopResults target = new TopResults();
            target.AddResultToTopResults(4, "Ivan");
            target.AddResultToTopResults(3, "Peter");
            target.AddResultToTopResults(3, "Ivan");
            target.AddResultToTopResults(3, "Joro");
            target.AddResultToTopResults(4, "Stefan");
            int result = 5;
            bool expected = false;
            bool actual;
            actual = target.ResultQualifiesForTopResults(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TryQualify_WhenResultIs50BoardIsNotFull_ShouldQualify()
        {
            TopResults target = new TopResults();
            target.AddResultToTopResults(4, "Ivan");
            target.AddResultToTopResults(3, "Peter");
            target.AddResultToTopResults(3, "Ivan");
            int result = 50;
            bool expected = true;
            bool actual;
            actual = target.ResultQualifiesForTopResults(result);
            Assert.AreEqual(expected, actual);
        }
    }
}
