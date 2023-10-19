using Microsoft.VisualStudio.TestTools.UnitTesting;
using FSEproject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace FSEproject.Tests
{
    [TestClass()]
    public class Assignment2Tests
    {
        [TestMethod()]
        public void GetTextTime_Test_JustNow()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(0, 0, 0, 2));
            string expected = "just now";

            var textTime = Assignment2.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }

        [TestMethod()]
        public void GetTextTime_Test_LessThanAMinuteAgo()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(0, 0, 0, 59));
            string expected = "less than a minute ago";

            var textTime = Assignment2.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void GetTextTime_Test_ACoupleOfMinutesAgo()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(0, 0, 2, 0));
            string expected = "a couple of minutes ago";

            var textTime = Assignment2.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void GetTextTime_Test_AnHourAgo()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(0, 1, 0, 0));
            string expected = "an hour ago";

            var textTime = Assignment2.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }

        [TestMethod()]
        public void GetTextTime_Test_Today()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(0, 2, 0, 0));
            string expected = "today";

            var textTime = Assignment2.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void GetTextTime_Test_Yesterday()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
            string expected = "yesterday";

            var textTime = Assignment2.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void GetTextTime_Test_ThisWeek()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));
            string expected = "this week";

            var textTime = Assignment2.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void GetTextTime_Test_ALongTimeAgo()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0));
            string expected = "a long time ago";

            var textTime = Assignment2.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void CreateOutput_Test_Online()
        {
            var user = new UsersData();
            user.nickname = "Test";
            user.lastSeenDate = DateTime.Now;
            string expected = "Test online.";
            string Language = "eng";

            var output = Assignment2.CreateOutput(user, Language);

            Assert.AreEqual(expected, output);
        }
    }
}