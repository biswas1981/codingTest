using PromotionEngine.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            PromotionEngineLogic logic = new BL.PromotionEngineLogic();
            var items = new List<string>();
            bool flag = true;
            while (flag)
            {
                Console.Write("Enter SKU Id : ");
                string id = Console.ReadLine();
                items.Add(id);
                Console.WriteLine("================================");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    flag = false;
                }
            }
            int result = logic.DoCalculation(items.GroupBy(g => g).Select(s => new CartItem { SkuId=s.Key, Quentity=s.Count() }).ToList());
            Console.WriteLine("Total : " + result);
            Console.ReadKey();
        }
    }


}
