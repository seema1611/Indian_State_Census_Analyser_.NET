
using CensusAnalyserProblem;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblemTest
{
    public class CensusAnalyserTest
    {
        CensusAnalyser censusAnalyser;
        string indianCensusDataHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";

        string csvFilePath = @"C:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";
        string invalidCsvFilePath = @"D:\Users\User\source\repos\CensusAnalyserProblem\CensusAnalyserProblemTest\Resources\IndiaStateCensusData.csv";

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }

        //UC-1
        //TC-1.1
        [Test]
        public void givenIndianCensusCSVFile_WhenFileExist_ShouldReturnsTotalNumberOfRecords()
        {
            IEnumerable<string> indianCensusRecord = censusAnalyser.loadCSVFileData(indianCensusDataHeaders,csvFilePath);
            Assert.AreEqual(29, indianCensusRecord.Count());
        }

        //TC-1.2
        [Test]
        public void givenIndianCensusCSVFile_WhenFileNotExist_ShouldThrowFileNotFoundException()
        {
            var error = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.loadCSVFileData(indianCensusDataHeaders, invalidCsvFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, error.type);
        }
    }
}