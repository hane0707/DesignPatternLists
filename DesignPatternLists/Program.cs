using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternLists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[] { "鶏むね肉", "カレールー", "じゃがいも", "にんじん", "たまねぎ" };

            // イテレータパターン(イテレータブロック未使用)
            var shoppingCartA = new IteratorA.ShoppingCart();
            foreach (var item in arr)
                shoppingCartA.AppendItem(new IteratorA.ShoppingItem(item));

            foreach (var item in shoppingCartA)
                Console.WriteLine(item.ItemName);

            // イテレータパターン(イテレータブロック使用)
            var shoppingCartB = new IteratorB.ShoppingCart();
            foreach (var item in arr)
                shoppingCartB.AppendItem(new IteratorB.ShoppingItem(item));

            foreach (var item in shoppingCartB.GetEnumerable())
                Console.WriteLine(item.ItemName);

            // テンプレートメソッドパターン
            List<string> list = arr.ToList();
            var templateMethodA = new TemplateMethod.ConcreteJoinStringWithComma();
            templateMethodA.Display(arr);
            var templateMethodB = new TemplateMethod.ConcreteJoinStringWithSpace();
            templateMethodB.Display(list);

            Console.ReadLine();
        }
    }
}
