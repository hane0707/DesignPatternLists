using FactoryFramework;
using System;
using System.Collections.Generic;

// 参考：https://qiita.com/ayayo/items/3eece04bbc4b7504179a
// 実装側は例えばCreate関数さえ呼べば、そのインスタンスに応じたCreateProductが呼び出され、生成される。
// ＝別の工場を作成する場合でも、抽象クラス（Framework）側の修正が不要。

/// <summary>
/// ファクトリーパターンのフレームワーク部分
/// </summary>
namespace FactoryFramework
{
    /// <summary>
    /// 工場で作られた製品の抽象クラス
    /// </summary>
    public abstract class Product
    {
        public abstract void Use();
    }

    /// <summary>
    /// 製品を作る工場の抽象クラス
    /// </summary>
    public abstract class Factory
    {
        public Product Create(string name)
        {
            Owner owner = new Owner(name);
            Product product = CreateProduct(owner);
            RegisterProduct(product);
            return product;
        }
        protected abstract Product CreateProduct(Owner owner);
        protected abstract void RegisterProduct(Product product);
    }

    public class Owner
    {
        public string Name { get; }

        public Owner(string name)
        {
            Name = name;
        }
    }
}

/// <summary>
/// ファクトリーパターンを実装したIDカード
/// </summary>
namespace Idcard
{
    /// <summary>
    /// 工場で作られたIDカードの具象クラス
    /// </summary>
    public class IDCard : Product
    {
        public Owner IDCardOwner { get; }

        public IDCard(Owner owner)
        {
            IDCardOwner = owner;
            Console.WriteLine(IDCardOwner.Name + "のカードを作ります。");
        }

        public override void Use()
        {
            Console.WriteLine(IDCardOwner.Name + "のカードを使います。");
        }
    }

    /// <summary>
    /// IDカードを作る工場の具象クラス
    /// </summary>
    public class IDCardFactory : Factory
    {
        public List<Owner> owners { get; }

        public IDCardFactory()
        {
            owners = new List<Owner>();
        }

        protected override Product CreateProduct(Owner owner)
        {
            return new IDCard(owner);
        }

        protected override void RegisterProduct(Product product)
        {
            owners.Add(((IDCard)product).IDCardOwner);
        }
    }
}
