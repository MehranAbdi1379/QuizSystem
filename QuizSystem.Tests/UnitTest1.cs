namespace QuizSystem.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            DateTime start = new DateTime(2023 , 1 , 3);
            DateTime end = new DateTime(2023, 1, 6);

            

            Assert.Equal( "3" , (end.Subtract(start).Days).ToString());
        }
    }
}