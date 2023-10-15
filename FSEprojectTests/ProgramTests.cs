using Microsoft.VisualStudio.TestTools.UnitTesting;
using FSEproject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSEproject.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetTextTime_Test_JustNow()
        {
            DateTime lastSeen = DateTime.Now;
            string expected = "just now";

            var textTime = Program.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }

        [TestMethod()]
        public void GetTextTime_Test_LessThanAMinuteAgo()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(0, 0, 0, 59));
            string expected = "less than a minute ago";

            var textTime = Program.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void GetTextTime_Test_ACoupleOfMinutesAgo()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(0, 0, 2, 0));
            string expected = "a couple of minutes ago";

            var textTime = Program.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void GetTextTime_Test_AnHourAgo()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(0, 1, 0, 0));
            string expected = "an hour ago";

            var textTime = Program.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }

        [TestMethod()]
        public void GetTextTime_Test_Today()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(0, 2, 0, 0));
            string expected = "today";

            var textTime = Program.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void GetTextTime_Test_Yesterday()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
            string expected = "yesterday";

            var textTime = Program.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void GetTextTime_Test_ThisWeek()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));
            string expected = "this week";

            var textTime = Program.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
        [TestMethod()]
        public void GetTextTime_Test_ALongTimeAgo()
        {
            DateTime lastSeen = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0));
            string expected = "a long time ago";

            var textTime = Program.GetTextTime(lastSeen);

            Assert.AreEqual(expected, textTime);
        }
    }
}