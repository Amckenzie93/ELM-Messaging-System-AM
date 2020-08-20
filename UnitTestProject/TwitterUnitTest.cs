using Microsoft.VisualStudio.TestTools.UnitTesting;
using ELM__AM;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace UnitTestProject
{
    [TestClass]
    public class TwitterUnitTest
    {

        // Test the import auto creation of a new Email message with details - should create a sucsessful Email object.
        [TestMethod]
        public void ImportTwitterTestWithDetails()
        {
            DataCollection testDB = DataCollection.Instance();
            var id = "T000000001";
            var author = "@Adam";
            var message = "this is a test twitter message #test @test";
            var input = author + "," + message;

            //different constructor to manual input
            Twitter twitterTest = new Twitter(id, input, testDB);

            if (twitterTest.ID == "T000000001" && twitterTest.TwitterID == "@Adam" && twitterTest.TwitterMessage == "this is a test twitter message #test @test")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }






        // Test the manual creation of a new Twitter message with details - should create a sucsessful Twitter object.
        [TestMethod]
        public void ManualTwitterTestWithDetails()
        {
            DataCollection testDB = DataCollection.Instance();
            var id = "T000000002";
            var author = "@Adam";
            var message = "this is a test twitter message #test @test";

            //different constructor to manual input
            Twitter twitterTest = new Twitter(id, author, message, testDB);

            if (twitterTest.ID == "T000000002" && twitterTest.TwitterID == "@Adam" && twitterTest.TwitterMessage == "this is a test twitter message #test @test")
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
