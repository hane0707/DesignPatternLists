using System;
using System.Collections.Generic;
using System.Collections;

// 参考：https://qiita.com/Nuits/items/800f080d44b52e1cae18

/// <summary>
/// イテレータパターン(イテレータブロック未使用)
/// </summary>
namespace IteratorA
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
    public class ShoppingCart : IEnumerable<ShoppingItem>
    {
        private readonly List<ShoppingItem> _items = new List<ShoppingItem>();
        public int Length => _items.Count;
        
        public ShoppingCart()
        {
        }

        public void AppendItem(ShoppingItem item) => _items.Add(item);

        public ShoppingItem GetItemAt(int index)
        {
            return _items[index];
        }

        public IEnumerator<ShoppingItem> GetEnumerator()
        {
            return new ShoppingCartEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ShoppingCartEnumerator : IEnumerator<ShoppingItem>
    {
        private readonly ShoppingCart _shoppingCart;
        private int index = -1;
        public ShoppingItem Current => _shoppingCart.GetItemAt(index);
        object IEnumerator.Current => Current;

        public ShoppingCartEnumerator(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public bool MoveNext()
        {
            index++;
            return index < _shoppingCart.Length;
        }

        public void Reset()
        {
            index = 0;
        }

        public void Dispose()
        {

        }
    }
}
