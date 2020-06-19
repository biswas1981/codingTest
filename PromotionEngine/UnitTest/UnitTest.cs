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
            var items = new System.Collections.Generic.List<CartItem>();
            items.Add(new CartItem { SkuId = "A", Quentity = 1 });
            items.Add(new CartItem { SkuId = "B", Quentity = 1 });
            items.Add(new CartItem { SkuId = "C", Quentity = 1 });
           int r= new PromotionEngine.BL.PromotionEngineLogic().DoCalculation(items);

        }

        [TestMethod]
        public void TestMethod2()
        {
            //Second Test  
            var items = new System.Collections.Generic.List<CartItem>();
            items.Add(new CartItem { SkuId = "A", Quentity = 5 });
            items.Add(new CartItem { SkuId = "B", Quentity = 5 });
            items.Add(new CartItem { SkuId = "C", Quentity = 1 });
          int r =  new PromotionEngine.BL.PromotionEngineLogic().DoCalculation(items);

        }

        [TestMethod]
        public void TestMethod3()
        {
            //Thisrd Test  
            var items = new System.Collections.Generic.List<CartItem>();
            items.Add(new CartItem { SkuId = "A", Quentity = 3 });
            items.Add(new CartItem { SkuId = "B", Quentity = 5 });
            items.Add(new CartItem { SkuId = "C", Quentity = 1 });
            items.Add(new CartItem { SkuId = "D", Quentity = 1 });
           int r= new PromotionEngine.BL.PromotionEngineLogic().DoCalculation(items);

        }
    }
}
