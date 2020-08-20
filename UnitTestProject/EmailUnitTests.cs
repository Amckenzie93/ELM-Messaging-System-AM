using Microsoft.VisualStudio.TestTools.UnitTesting;
using ELM__AM;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class EmailUnitTests
    {

        // Test the import auto creation of a new Email message with details - should create a sucsessful Email object.
        [TestMethod]
        public void ImportEmailTestWithDetails()
        {
            DataCollection testDB = DataCollection.Instance();
            var id = "E000000001";
            var subject = "Hello world";
            var address = "adam@test.com";
            var message = "this is a test email";

            var input = subject + "," + address + "," + message;

            //different constructor to manual
            Email emailTest = new Email(id, input, testDB);

            if (emailTest.ID == "E000000001" && emailTest.EmailAddress == "adam@test.com" && emailTest.Subject == "Hello world" && emailTest.EmailMessage == "this is a test email")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }






        // Test the manual creation of a new Email message with details - should create a sucsessful Email object.
        [TestMethod]
        public void ManualSmsTestWithDetails()
        {
            DataCollection testDB = DataCollection.Instance();
            var id = "E000000001";
            var subject = "Hello world";
            var address = "adam@test.com";
            var message = "this is a test email";

            //different constructor to import
            Email emailTest = new Email(id, subject, address, message, testDB);

            if (emailTest.ID == "E000000001" && emailTest.EmailAddress == "adam@test.com" && emailTest.Subject == "Hello world" && emailTest.EmailMessage == "this is a test email")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

    }
}
