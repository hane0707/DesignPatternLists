using System;
using System.Collections.Generic;

// 参考：https://qiita.com/_kyam/items/9b5722e6a9635af6e18b#_reference-67658aa746587e3a56f0
// 参考：https://thinkit.co.jp/article/13182
// 抽象クラスで共通ロジックとそれに必用な空の関数だけ用意。
// 各サブクラスで具体的なロジックをオーバーライドして実装。
// サブクラス側で共通的な処理の流れを実装しなくてよい。
// 処理の流れは同じで、処理の内容は違うプログラムを組む場合、
// このパターンを使うことで処理の流れを各機能で考えず、処理の内容だけを考えればよくなる。

/// <summary>
/// テンプレートメソッドパターン
/// </summary>
namespace TemplateMethod
{
    public abstract class AbstractJoinString
    {
        public abstract string JoinString(IEnumerable<string> list);
        public abstract void StartLogic();

        public void Display(IEnumerable<string> list)
        {
            StartLogic();

            string baseValue = string.Empty;
            foreach (var item in list)
            {
                baseValue = JoinString(list);
            }

            Console.WriteLine(baseValue);
        }
    }

    public class ConcreteJoinStringWithComma : AbstractJoinString
    {
        public override void StartLogic()
        {
            Console.WriteLine("カンマで結合");
        }

        public override string JoinString(IEnumerable<string> list)
        {
            return string.Join(",", list);
        }
    }

    public class ConcreteJoinStringWithSpace : AbstractJoinString
    {
        public override void StartLogic()
        {
            Console.WriteLine("スペースで結合");
        }

        public override string JoinString(IEnumerable<string> list)
        {
            return string.Join(" ", list);
        }
    }

}
