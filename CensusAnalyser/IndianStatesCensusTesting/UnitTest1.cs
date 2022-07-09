using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.DTO;
namespace IndianStatesCensusTesting
{
    public class Tests
    {
        string stateCensusFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\WrongIndianPopulation.csv";
        string wrongTypeFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongDelimiterFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";

        public CSVAdapterFactory csvAdapter = null;
        Dictionary<string, CensusDTO> stateRecords = null;

        [SetUp]
        public void SetUp()
        {
            csvAdapter = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        //TC 1.1 Given correct path To ensure number of records matches
        [Test]
        public void GivenStateCensusCsvReturnStateRecords()
        {
            int expected = 29;
            stateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(expected, stateRecords.Count);
        }
        
        //TC 1.2 Given incorrect file should return custom exception - File not found
        [Test]
        public void GivenWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }
        
        //TC 1.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [Test]
        public void GivenWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [Test]
        public void GivenWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [Test]
        public void GivenWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }
        
    }
}

//Result TC.1.1
//IndianStatesCensusTesting
//  Tests in group: 1

//  Total Duration: 16.5 min

//Outcomes
//   1 Passed
//------------------------------------//
//TC.1.2
//IndianStatesCensusTesting
//  Tests in group: 2

//  Total Duration: 1.8 min

//Outcomes
//   2 Passed
//------------------------------------//
//TC.1.3
//IndianStatesCensusTesting
//  Tests in group: 3

//  Total Duration: 2.6 min

//Outcomes
//   3 Passed
//------------------------------------//
//TC.1.4
//IndianStatesCensusTesting
//  Tests in group: 4

//  Total Duration: 4.4 min

//Outcomes
//   4 Passed
//------------------------------------//
//TC.1.5
//IndianStatesCensusTesting
//  Tests in group: 5

//  Total Duration: 5.3 min

//Outcomes
//   5 Passed
//------------------------------------//