using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ResProjectForZoki.DataAccessModul;
using ResProjectForZoki.Interfaces;

namespace ResProjectForZokiTest
{
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        public void GetConsummationsFromInterval_4inList_2inInterval()
        {
            List<Consummation> inputList = new List<Consummation> { /*...*/ };
            List<Consummation> outputList = new List<Consummation> { /*...*/ };
            IDatabase database = Substitute.For<IDatabase>();
            database.GetAll().Returns(inputList);

            IDataAccess dataAccess = new DataAccess(database);
            var retVal = dataAccess.GetConsummationsFromInterval(new DateTime(), new DateTime());

            CollectionAssert.AreEquivalent(outputList, retVal);
        }

        [TestMethod]
        public void WriteToDataBase_Null_throwsException()
        {
            IDatabase database = Substitute.For<IDatabase>();

            IDataAccess dataAccess = new DataAccess(database);

            Assert.ThrowsException<ArgumentNullException>( () => dataAccess.WriteToDataBase(null) );
        }

        [TestMethod]
        public void WriteToDataBase_NotNull_DoesntThrowsException()
        {
            IDatabase database = Substitute.For<IDatabase>();

            IDataAccess dataAccess = new DataAccess(database);

             dataAccess.WriteToDataBase(new System.Data.DataTable());
        }
    }
}
