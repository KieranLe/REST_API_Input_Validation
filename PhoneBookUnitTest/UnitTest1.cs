using PhoneBook.Model;
using System.ComponentModel.DataAnnotations;


namespace PhoneBookUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //Format: X_Y_Z()
        // X : Input (inputs provided in the assignment) or My_Input (my own inputs).
        // Y : test's number.
        // Z : Pass or Fail, the expected result of the unit test.
        [TestMethod]
        public void Input_1_Pass()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Brunce Schneier",
                PhoneNumber = "12345",              
            };

            var lstErrors = ValidateModel(addName);

            Assert.IsTrue(lstErrors.Count == 0);
        }

        [TestMethod]
        public void Input_2_Pass()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Schneier, Bruce",
                PhoneNumber = "123-1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_3_Pass()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Schneier, Bruce Wayne",
                PhoneNumber = "+1(703)111-2121",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_4_Pass()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "O'Malley, John F.",
                PhoneNumber = "+1(703)123-1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_5_Pass()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "John O'Malley-Smith",
                PhoneNumber = "1(703)123-1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_6_Pass()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Cher",
                PhoneNumber = "011 701 111 1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }


        //fail
        [TestMethod]
        public void Input_7_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Ron O''Henry",
                PhoneNumber = "123",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_8_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Ron O'Henry-Smith-Barnes",
                PhoneNumber = "1/703/123/1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_9_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "L33t Hacker",
                PhoneNumber = "Nr 102-123-1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_10_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "<Script>alert(\"XSS\"</Script>",
                PhoneNumber = "<script>alert(“XSS”)</script>",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_11_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Brad Everett Samuel Smith",
                PhoneNumber = "7031111234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_12_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "\"select * from users;\\r\\n",
                PhoneNumber = "+1234 (201) 123-1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_13_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "select * from users;",
                PhoneNumber = "(001) 123-1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_14_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "select * from;",
                PhoneNumber = "+01 (703) 123-1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_15_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "select 1111 from;",
                PhoneNumber = "(703) 123-1234 ext 204_",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void Input_16_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Brad Everett",
                PhoneNumber = "7031111234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void My_Input_1_Pass()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "John Smith",
                PhoneNumber = "+45 23.14.56.77",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void My_Input_2_Pass()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Tobin Charlene Quentin",
                PhoneNumber = "1234.4321",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void My_Input_3_Pass()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Charles D'Artagnann",
                PhoneNumber = "1.682.123.4567",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void My_Input_4_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Maha Ruggero ALex John Melisa",
                PhoneNumber = "1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void My_Input_5_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "Peta 123 Britney",
                PhoneNumber = "John 222.3334",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        [TestMethod]
        public void My_Input_6_Fail()
        {
            PhoneBookEntry addName = new PhoneBookEntry
            {
                Name = "123-456",
                PhoneNumber = "001 324 (777) 111 1234",
            };

            var lstErrors = ValidateModel(addName);
            Assert.IsTrue(lstErrors.Count == 0);

        }

        //Unit Test DataAnnotation
        //http://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation
        // Return the number of errors. 
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}