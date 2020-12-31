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
            Console.WriteLine("■イテレータパターン(イテレータブロック未使用)");
            var shoppingCartA = new IteratorA.ShoppingCart();
            foreach (var item in arr)
                shoppingCartA.AppendItem(new IteratorA.ShoppingItem(item));

            foreach (var item in shoppingCartA)
                Console.WriteLine(item.ItemName);

            // イテレータパターン(イテレータブロック使用)
            Console.WriteLine("■イテレータパターン(イテレータブロック使用)");
            var shoppingCartB = new IteratorB.ShoppingCart();
            foreach (var item in arr)
                shoppingCartB.AppendItem(new IteratorB.ShoppingItem(item));

            foreach (var item in shoppingCartB.GetEnumerable())
                Console.WriteLine(item.ItemName);

            // テンプレートメソッドパターン
            Console.WriteLine("■テンプレートメソッドパターン");
            List<string> list = arr.ToList();
            var templateMethodA = new TemplateMethod.ConcreteJoinStringWithComma();
            templateMethodA.Display(arr);
            var templateMethodB = new TemplateMethod.ConcreteJoinStringWithSpace();
            templateMethodB.Display(list);

            // ファクトリーパターン
            Console.WriteLine("■ファクトリーパターン");
            FactoryFramework.Factory factory = new Idcard.IDCardFactory();
            FactoryFramework.Product card1 = factory.Create("test1");
            FactoryFramework.Product card2 = factory.Create("test2");
            FactoryFramework.Product card3 = factory.Create("test3");

            card1.Use();
            card2.Use();
            card3.Use();

            // 状態パターン
            Console.WriteLine("■状態パターン");
            HogeScreen.HogeScreen screen = new HogeScreen.HogeScreen("hoge画面");
            screen.Register();
            screen.ChangeTranType(State.IStateWithTranType.TranType.Update); // 状態の変更
            screen.Register();
            screen.ChangeTranType(State.IStateWithTranType.TranType.Delete); // 状態の変更
            screen.Register();

            // ストラテジーパターン
            Console.WriteLine("■ストラテジーパターン");
            var create = new Strategy.Create();
            var update = new Strategy.Update();
            var delete = new Strategy.Delete();

            var operation = new Strategy.UserOperation(create);
            operation.Regist();
            operation.SetRegistPattern(update);
            operation.Regist();
            operation.SetRegistPattern(delete);
            operation.Regist();

            Console.ReadLine();
        }
    }
}
