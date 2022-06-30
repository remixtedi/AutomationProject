namespace AutomationProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var factory = new DriverFactory();
            var driver = factory.CreateBrowser("firefox");
            driver.Quit();
        }
    }
}