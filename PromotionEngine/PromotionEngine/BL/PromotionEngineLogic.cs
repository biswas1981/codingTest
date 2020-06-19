using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.BL
{

    public interface IPromotion
    {
        int GetPromotionValue();
    }
    public abstract class SKU
    {
        public int GetSKUItemRate(string itemId)
        {
            try
            {
                string json = ReadJsonFile("\\App_Data\\SkuItemRate.json");
                var skus = JsonConvert.DeserializeObject<List<SkuItem>>(json);
                var result = skus.Where(a => string.Equals(a.ItemId, itemId, StringComparison.OrdinalIgnoreCase) == true).FirstOrDefault() ?? null;
                if (result != null)
                {
                    return result.Rate;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string ReadJsonFile(string filePath)
        {
            return System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + filePath);
        }
    }

    public class ActivePromoRuleForA : SKU, IPromotion
    {
        public CartItem ItemA { get; set; }
        public int GetPromotionValue()
        {
            int groupValue = ItemA.Quentity / 3;
            int oddValue = ItemA.Quentity % 3;
            return (groupValue * 130) + (oddValue * GetSKUItemRate("A"));
        }
    }
    public class ActivePromoRuleForB : SKU, IPromotion
    {
        public CartItem ItemB { get; set; }
        public int GetPromotionValue()
        {
            int groupValue = ItemB.Quentity / 2;
            int oddValue = ItemB.Quentity % 2;
            return (groupValue * 45) + (oddValue * GetSKUItemRate("B"));
        }
    }
    public class ActivePromoRuleForCAndD : SKU, IPromotion
    {
        public CartItem ItemC { get; set; }
        public CartItem ItemD { get; set; }

        public int GetPromotionValue()
        {
            int result = 0;
            if (ItemC == null) {
                ItemC = new BL.CartItem { SkuId = "C", Quentity = 0 };
            }
            if (ItemD == null)
            {
                ItemD = new BL.CartItem { SkuId = "D", Quentity = 0 };
            }
            if (ItemC.Quentity > 0 && ItemD.Quentity > 0 && ItemC.Quentity > ItemD.Quentity)
            {
                result += 30;
                result += (ItemC.Quentity - ItemD.Quentity) * GetSKUItemRate("C");
            }
            else if (ItemC.Quentity > 0 && ItemD.Quentity > 0 && ItemC.Quentity < ItemD.Quentity)
            {
                result += 30;
                result += (ItemD.Quentity - ItemC.Quentity) * GetSKUItemRate("D");
            }
            else if (ItemC.Quentity > 0 && ItemD.Quentity > 0 && ItemC.Quentity == ItemD.Quentity)
            {
                result += (ItemC.Quentity * 30);              
            }
            else if (ItemC.Quentity > 0 && ItemD.Quentity == 0)
            {

                result += ItemC.Quentity * GetSKUItemRate("C");
            }
            else if (ItemC.Quentity == 0 && ItemD.Quentity > 0)
            {
                result += ItemD.Quentity * GetSKUItemRate("D");
            }
            return result;
        }
    }
    public class PromotionEngineLogic
    {
        public int DoCalculation(List<CartItem> cart)
        {
            int result = 0;

            cart.ForEach(x =>
            {
                if (x.SkuId == "A")
                {
                    IPromotion promo = new ActivePromoRuleForA() { ItemA = x };
                    result += promo.GetPromotionValue();
                }
                else if (x.SkuId == "B")
                {
                    IPromotion promo = new ActivePromoRuleForB() { ItemB = x };
                    result += promo.GetPromotionValue();
                }
            });
            var cAndD = cart.Where(a => a.SkuId == "C" || a.SkuId == "D").ToList();
            if (cAndD != null && cAndD.Count > 0)
            {
                IPromotion promo = new ActivePromoRuleForCAndD()
                {
                    ItemC = cAndD.Where(x => x.SkuId == "C").FirstOrDefault(),
                    ItemD = cAndD.Where(x => x.SkuId == "D").FirstOrDefault()
                };
                result += promo.GetPromotionValue();
            }
            return result;
        }

    }
}
