﻿using PromotionEngine.BL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
           var logic = new BL.PromotionEngineLogic();
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
            //Call logic
            int result = logic.DoCalculation(items);
            //Show result
            Console.WriteLine("Total : " + result);

            Console.ReadKey();
        }
    }


}
