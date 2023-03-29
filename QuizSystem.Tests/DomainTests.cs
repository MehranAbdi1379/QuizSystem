using System.Text.RegularExpressions;

namespace QuizSystem.Tests
{
    public class DomainTests
    {
        [Fact]
        public void ValidateStartTimeIsInTheFutureTest()
        {
            DateTime startTime, endTime;
            startTime = DateTime.Now;
            endTime = new DateTime(2023,3,31);

            int days = (int)endTime.Subtract(startTime).TotalDays;

            Assert.Equal(2 , days);

            startTime = DateTime.Now;
            endTime = new DateTime(2023, 4, 5);
            days = (int)endTime.Subtract(startTime).TotalDays;

            Assert.Equal(7, days);

            startTime = DateTime.Now;
            endTime = new DateTime(2023, 3, 27);
            days = (int)endTime.Subtract(startTime).TotalDays;

            Assert.Equal(-2, days);
        }
    }
}