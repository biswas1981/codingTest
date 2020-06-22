using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.BL;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //First  
            var items = new System.Collections.Generic.List<string>() { "A", "B", "C" };
            int r = new PromotionEngine.BL.PromotionEngineLogic().DoCalculation(items);

        }

        [TestMethod]
        public void TestMethod2()
        {
            //Second Test  
            var items = new System.Collections.Generic.List<string>() { "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C" };
            int r = new PromotionEngine.BL.PromotionEngineLogic().DoCalculation(items);

        }

        [TestMethod]
        public void TestMethod3()
        {
            //Thisrd Test  
            var items = new System.Collections.Generic.List<string>() { "A", "A", "A", "B", "B", "B", "B", "B", "C", "D" };
            int r = new PromotionEngine.BL.PromotionEngineLogic().DoCalculation(items);

        }
    }
}
