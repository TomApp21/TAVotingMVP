using Newtonsoft.Json.Linq;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests
{
    [Trait("Category", "Model Validations")]
    public class VoterServicesValidation : IClassFixture<VoterServicesFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private VoterServicesFixture _voterServicesFixture;
        public VoterServicesValidation(VoterServicesFixture voterServicesFixture, ITestOutputHelper testOutputHelper)
        {
            this._voterServicesFixture = voterServicesFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();
        }

        [Fact]
        public void ShouldNotThrowExceptionForDefaultTestValuesOnAnnotations()
        {
            var exception =
                Record.Exception(() => _voterServicesFixture.VoterServices.ValidateModelDataAnnotations(_voterServicesFixture.VoterModel));

            Assert.Null(exception);

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionIfAnyDataAnnotationCheckFails()
        {
            _voterServicesFixture.VoterModel.DateOfBirth = "02//07//1999";
            _voterServicesFixture.VoterModel.NationalInsurance = "PX4876";


            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _voterServicesFixture.VoterServices.ValidateModelDataAnnotations(_voterServicesFixture.VoterModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForFirstEmpty()
        {
            _voterServicesFixture.VoterModel.FirstName = "";

            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _voterServicesFixture.VoterServices.ValidateModelDataAnnotations(_voterServicesFixture.VoterModel));

            WriteExceptionTestResult(exception);
        }

       

        private void SetValidSampleValues()
        {
            _voterServicesFixture.VoterModel.FirstName = "David";
            _voterServicesFixture.VoterModel.LastName = "Brent";
            _voterServicesFixture.VoterModel.AddressLine1 = "18 Highton";
            _voterServicesFixture.VoterModel.AddressLine2 = "Littlerock";
            _voterServicesFixture.VoterModel.Postcode = "S11 8RA";
            _voterServicesFixture.VoterModel.NationalInsurance = "PE776854A";
            _voterServicesFixture.VoterModel.DateOfBirth = "05/05/1999";


        }

        private void WriteExceptionTestResult(Exception exception)
        {
            if (exception != null)
            {
                _testOutputHelper.WriteLine(exception.Message);
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                JObject json = JObject.FromObject(_voterServicesFixture.VoterModel);
                stringBuilder.Append("***** No Exception Was Thrown ******").AppendLine();
                foreach (JProperty jProperty in json.Properties())
                {
                    stringBuilder.Append(jProperty.Name).Append(" --> ").Append(jProperty.Value).AppendLine();
                }

                _testOutputHelper.WriteLine(stringBuilder.ToString());
            }
        }


    }
}