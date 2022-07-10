using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.DTO;
namespace IndianStatesCensusTesting
{
    public class Tests
    {
        //UC1 - File Paths for indian state census
        string stateCensusFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\WrongIndianPopulation.csv";
        string wrongTypeFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongDelimiterFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        string stateCensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";

        //UC2 - File paths for indian state codes
        string statCodeFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\IndiaStateCode.csv";
        string wrongStateCodeFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\WrongIndiaStateCodeNotExist.csv";
        string wrongStateCodeTypeFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongStateCodeDelimiterFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";
        string wrongStateCodeHeaderFilePath = @"C:\Users\4shiv\OneDrive\Desktop\Fellowship\Assignments\Assignment_Day_29\CensusAnalyser\CensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
        string stateCodeHeader = "SrNo,State Name,TIN,StateCode";


        public CSVAdapterFactory csvAdapter = null;
        Dictionary<string, CensusDTO> stateRecords = null;
        Dictionary<string, CensusDTO> stateCodeRecords = null;

        [SetUp]
        public void SetUp()
        {
            csvAdapter = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
            stateCodeRecords = new Dictionary<string, CensusDTO>();
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
        //TC 2.1 Given correct path To ensure number of records matches
        [Test]
        public void GivenStateCodesCsvReturnStateRecords()
        {
            int expected = 37;
            stateCodeRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, statCodeFilePath, stateCodeHeader);
            Assert.AreEqual(expected, stateCodeRecords.Count);
        }

        //TC 2.2 Given incorrect file should return custom exception - File not found
        [Test]
        public void GivenStateCodesWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [Test]
        public void GivenStateCodesWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeTypeFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [Test]
        public void GivenStateCodesWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeDelimiterFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [Test]
        public void GivenStateCodesWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.Throws<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeHeaderFilePath, stateCodeHeader));
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
//TC.2.1
//IndianStatesCensusTesting
//  Tests in group: 1

//  Total Duration: 3 min

//Outcomes
//   1 Passed
//------------------------------------//
//TC.2.2
//Tests
//  Tests in group: 2

//  Total Duration: 3.1 min

//Outcomes
//   2 Passed
//------------------------------------//
//TC.2.3
//Tests
//  Tests in group: 3

//  Total Duration: 3.1 min

//Outcomes
//   3 Passed
//------------------------------------//
//TC.2.4
//Tests
//  Tests in group: 4

//  Total Duration: 3.1 min

//Outcomes
//   4 Passed
//------------------------------------//
//TC.2.5
//Tests
//  Tests in group: 5

//  Total Duration: 3.1 min

//Outcomes
//   5 Passed
//------------------------------------//