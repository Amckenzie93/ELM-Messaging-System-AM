using Microsoft.VisualStudio.TestTools.UnitTesting;
using ELM__AM;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class TwitterUnitTests
    {

        // Test the import auto creation of a new SMS message with details - should create a sucsessful SMS object.
        [TestMethod]
        public void ImportSmsTestWithDetails()
        {
            DataCollection testDB = DataCollection.Instance();
            var id = "S000000001";
            var message = "Hello world test";
            var phoneNumber = "0795650650";

                Sms smsTest = new Sms(id, phoneNumber, message, testDB);

            if (smsTest.ID == "S000000001" && smsTest.Textmessage == "Hello world test" && smsTest.PhoneNumber == "0795650650")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }






        // Test the manual creation of a new SMS message with details - should create a sucsessful SMS object.
        [TestMethod]
        public void ManualSmsTestWithDetails()
        {
            DataCollection testDB = DataCollection.Instance();
            var id = "S999999999";
            var message = "Hello world test";
            var phoneNumber = "0795650650";
            var messageBody = message + "," + phoneNumber;

            Sms smsTest = new Sms(id, messageBody, testDB);

            if (smsTest.ID == "S999999999" && smsTest.Textmessage == "Hello world test" && smsTest.PhoneNumber == "0795650650")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }





        // Test the word abbreviation handling of SMS messages.
        [TestMethod]
        public void SmsWordAbreviations()
        {
            DataCollection testDB = DataCollection.Instance();
            var id = "S000000001";
            var message = "Hello world LOL this is a test of WWJD word abreviations";
            var phoneNumber = "0795650650";
            var messageBody = message + "," + phoneNumber;

            Sms smsTest = new Sms(id, messageBody, testDB);

            if (smsTest.Textmessage.Contains("<What would Jesus do?>") && smsTest.Textmessage.Contains("Laughing out loud>"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }






        // Failure Test - should fail and throw an exception error
        // Test the import auto creation of a new SMS message without any details - should throw an exception with an error message.
        [TestMethod]
        public void ImportSmsTestEmpty()
        {
            DataCollection testDB = DataCollection.Instance();
            var id = "";
            var message = "";
            var phoneNumber = "";
            try
            {
                Sms smsTest = new Sms(id, phoneNumber, message, testDB);
            }
            catch (Exception errorMessage)
            {
                if (errorMessage.Message.Length > 0)
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
            }
        }





        // Failure Test - should fail and throw an exception error
        // Test the manual entry of a new SMS message i.e. Header and a Body (containing the message and the phone number) - should throw an exception with an error message.
        [TestMethod]
        public void ManualSmsTestEmpty()
        {
            DataCollection testDB = DataCollection.Instance();
            var id = "";
            var message = "";
            var phoneNumber = "";
            var messageBody = message + "," + phoneNumber;
            try
            {
                Sms smsTest = new Sms(id, messageBody, testDB);
            }
            catch (Exception errorMessage)
            {
                if (errorMessage.Message.Length > 0)
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
}
