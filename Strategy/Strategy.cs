using System;

// 参考：https://www.mum-meblog.com/entry/study/design-pattern
// DB登録時、呼出側は登録する方法（＝戦略）を必用なものに切り替えるだけで
// DB登録のために呼び出す関数は同一のままにできる。
// DB登録の具体的なロジックはインターフェースを実装したクラスに記述する。

/// <summary>
/// ストラテジーパターン
/// </summary>
namespace Strategy
{
    /// <summary>
    /// DB登録をするためのインターフェース
    /// </summary>
    public interface IRegistData
    {
        void RegistData();
    }

    #region インターフェースを実装した処理区分クラス群
    public class Create : IRegistData
    {
        public void RegistData()
        {
            Console.WriteLine("データを新規登録します。");
        }
    }
    public class Update : IRegistData
    {
        public void RegistData()
        {
            Console.WriteLine("データを更新します。");
        }
    }
    public class Delete : IRegistData
    {
        public void RegistData()
        {
            Console.WriteLine("データを削除します。");
        }
    }
    #endregion

    /// <summary>
    /// ユーザーの操作を表すクラス（登録操作のみ実装）
    /// </summary>
    public class UserOperation
    {
        private IRegistData _registData;

        public UserOperation(IRegistData registData)
        {
            _registData = registData;
        }

        public void Regist()
        {
            // インターフェースが実装された各クラスのDB登録処理が呼ばれる
            _registData.RegistData();
        }

        public void SetRegistPattern(IRegistData registData)
        {
            var oldRegistData = _registData;
            _registData = registData;
            Console.WriteLine("登録方法が変更されました。" + oldRegistData + "⇒" + _registData);
        }
    }
}
