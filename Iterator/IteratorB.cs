using System;
using System.Collections.Generic;
using System.Collections;

// 参考：https://qiita.com/Nuits/items/800f080d44b52e1cae18
// イテレータブロックを使用することで、コレクションクラスの実装（IEnumerableとIEnumerator）を簡単にする。

/// <summary>
/// イテレータパターン(イテレータブロック使用 => 推奨)
/// </summary>
namespace IteratorB
{
    /// <summary>
    /// ショッピングカートの中身
    /// </summary>
    public class ShoppingItem
    {
        public string ItemName { get; }
        public ShoppingItem(string itemname)
        {
            ItemName = itemname;
        }
    }

    /// <summary>
    /// ショッピングカート
    /// </summary>
    public class ShoppingCart
    {
        private readonly List<ShoppingItem> _items = new List<ShoppingItem>();
        
        public ShoppingCart()
        {
        }

        public void AppendItem(ShoppingItem item) => _items.Add(item);

        // イテレータブロック
        // IEnumerableを実装するクラスを自動生成してくれる
        public IEnumerable<ShoppingItem> GetEnumerable()
        {
            foreach (var item in _items)
            {
                // 逐次的に値を返す
                yield return item;
            }
        }
    }
}
