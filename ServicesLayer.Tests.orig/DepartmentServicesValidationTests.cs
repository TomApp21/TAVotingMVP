using DomainLayer.Models.Department;
using Newtonsoft.Json.Linq;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests
{
    public class DepartmentModelFixture
    {
        public IDepartmentServices _departmentServices;
        public IDepartmentModel _departmentModel;

        public DepartmentModelFixture()
        {
            _departmentModel = new DepartmentModel();
            _departmentServices = new DepartmentServices(null, new ModelDataAnnotationCheck());
        }
    }

    [Trait("Category", "Model Validations")]
    public class DepartmentServicesValidationTests : IClassFixture<DepartmentModelFixture>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private DepartmentModelFixture _dmFixture;
        public DepartmentServicesValidationTests(DepartmentModelFixture departmentModelFixture, ITestOutputHelper testOutputHelper)
        {
            this._dmFixture = departmentModelFixture;
            _testOutputHelper = testOutputHelper;

            SetValidSampleValues();

        }

        private void SetValidSampleValues()
        {
            _dmFixture._departmentModel.DepartmentId = 1;
            _dmFixture._departmentModel.CityLocation = "Los Angeles";
            _dmFixture._departmentModel.DepartmentName = "Accounting";
            _dmFixture._departmentModel.Email = "jake.stone@mytest.org";
            _dmFixture._departmentModel.PhoneNumber = "321-444-3333";
            _dmFixture._departmentModel.StateLocation = "California";
            _dmFixture._departmentModel.DepartmentUrl = "http://www.someplace.com/accounting";
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
                JObject json = JObject.FromObject(_dmFixture._departmentModel);
                stringBuilder.Append("***** No Error Detected ******").AppendLine();
                foreach (JProperty jProperty in json.Properties())
                {
                    stringBuilder.Append(jProperty.Name).Append(" --> ").Append(jProperty.Value).AppendLine();
                }

                _testOutputHelper.WriteLine(stringBuilder.ToString());
            }
        }

        [Fact]
        public void ShouldNotThrowExceptionForDefaultTestValues()
        {
            var exception =
                Record.Exception(() => _dmFixture._departmentServices.ValidateModelDataAnnotations(_dmFixture._departmentModel));

            Assert.Null(exception);

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionIfAnyDataAnnotationCheckFails()
        {
            _dmFixture._departmentModel.PhoneNumber = "321-444-333q";
            _dmFixture._departmentModel.Email = "janet4trail.com";

            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _dmFixture._departmentServices.ValidateModelDataAnnotations(_dmFixture._departmentModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForCityLocationEmpty()
        {
            _dmFixture._departmentModel.CityLocation = "";

            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _dmFixture._departmentServices.ValidateModelDataAnnotations(_dmFixture._departmentModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForCityLocationTooShort()
        {
            _dmFixture._departmentModel.CityLocation = "A";

            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _dmFixture._departmentServices.ValidateModelDataAnnotations(_dmFixture._departmentModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForDepartmentUrlWrongHostSuffix()
        {
            _dmFixture._departmentModel.DepartmentUrl = "http://www.mycompany.org";

            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _dmFixture._departmentServices.ValidateDepartmentUrl(_dmFixture._departmentModel));

            WriteExceptionTestResult(exception);
        }

        [Fact]
        public void ShouldThrowExceptionForDepartmentUrlWrongProtocol()
        {
            _dmFixture._departmentModel.DepartmentUrl = "https://www.mycompany.com";

            Exception exception =
                Assert.Throws<ArgumentException>(testCode: () => _dmFixture._departmentServices.ValidateDepartmentUrl(_dmFixture._departmentModel));

            WriteExceptionTestResult(exception);
        }


    }
}
