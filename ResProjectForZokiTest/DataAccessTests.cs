using System;
using System.Collections.Generic;
using System.Data;
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
        public void GetConsummationsFromInterval_3inList_2inInterval()
        {
            List<Consummation> inputList = new List<Consummation>
            {
                new Consummation(new DateTime(2018, 1, 1), 5, "BG"),
                new Consummation(new DateTime(2018, 1, 1), 6, "BG"),
                new Consummation(new DateTime(2018, 1, 3), 7, "NS"),
            };
            List<Consummation> outputList = new List<Consummation>
            {
                new Consummation(new DateTime(2018, 1, 1), 5, "BG"),
                new Consummation(new DateTime(2018, 1, 1), 6, "BG"),
            };
            IDatabase database = Substitute.For<IDatabase>();
            database.GetAll().Returns(inputList);
            IConverter converter = Substitute.For<IConverter>();
            IDataAccess dataAccess = new DataAccess(database, converter);

            var retVal = dataAccess.GetConsummationsFromInterval(new DateTime(2018, 1, 1), new DateTime(2018, 1, 2));

            CollectionAssert.AreEqual(outputList, retVal);
        }

        [TestMethod]
        public void GetConsummationsFromInterval_BadInterval_ThrowsException()
        {
            IDatabase database = Substitute.For<IDatabase>();
            IConverter converter = Substitute.For<IConverter>();
            IDataAccess dataAccess = new DataAccess(database, converter);
            DateTime from = new DateTime(2018, 1, 1);
            DateTime to = new DateTime(2017, 1, 2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => dataAccess.GetConsummationsFromInterval(from, to)
            );
        }

        [TestMethod]
        public void WriteToDataBase_Null_throwsException()
        {
            IDatabase database = Substitute.For<IDatabase>();
            IConverter converter = Substitute.For<IConverter>();
            IDataAccess dataAccess = new DataAccess(database, converter);

            Assert.ThrowsException<ArgumentNullException>( 
                () => dataAccess.WriteToDataBase(null) 
            );
        }

        [TestMethod]
        public void WriteToDataBase_NotNull_DoesntThrowsException()
        {
            List<Consummation> inputList = new List<Consummation>
            {
                new Consummation(new DateTime(2018, 1, 1), 5, "BG"),
                new Consummation(new DateTime(2018, 1, 1), 6, "BG"),
                new Consummation(new DateTime(2018, 1, 3), 7, "NS"),
            };

            IDatabase database = Substitute.For<IDatabase>();
            IConverter converter = Substitute.For<IConverter>();
            converter.ConvertDataTable(Arg.Any<DataTable>()).Returns(inputList);

            IDataAccess dataAccess = new DataAccess(database, converter);

            dataAccess.WriteToDataBase(new DataTable());
        }

        [TestMethod]
        public void DataAccssesConstructor_NoInput_Valid()
        {
            new DataAccess();
        }
    }
}
