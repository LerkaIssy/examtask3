namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sum_AreEqual()
        {
            int x = 5;
            int y = 6;
            int except = 11;


            double actual = Solution.Class1.Sum(x, y);
            Assert.AreEqual(except, actual);
        }
    }
}