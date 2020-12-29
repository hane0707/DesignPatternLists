using State;
using System;

// 参考：https://qiita.com/a1146234/items/bba88081b0f84d70da1f#brave%E3%82%AF%E3%83%A9%E3%82%B9
// 複数の画面に「新規、更新、削除」のような処理区分を選択できるコントロールがある場合を想定
// 各画面共通のインターフェースとしてIStateWithTranTypeを定義
// HogeScreenは個別の画面を想定して実装

/// <summary>
/// Stateパターン
/// </summary>
namespace State
{
    /// <summary>
    /// 処理区分ごとの抽象メソッドを保持するインターフェース
    /// </summary>
    public interface IStateWithTranType
    {
        void CheckData();
        void RegisterData();

        /// <summary>
        /// 新規登録：Create、更新：Update、削除：Delete
        /// </summary>
        enum TranType
        {
            Create, Update, Delete
        }
    }

}

namespace HogeScreen
{
    #region インターフェースを実装した処理区分クラス群
    public class CreateState : IStateWithTranType
    {
        private static CreateState normal = new CreateState();

        public static IStateWithTranType GetInstance()
        {
            return normal;
        }

        public void CheckData()
        {
            Console.WriteLine("新規登録チェックをします。");
            // なんらかのチェック処理
        }

        public void RegisterData()
        {
            Console.WriteLine("出荷データを新規登録します。");
            // なんらかのDB処理
        }
    }

    public class UpdateState : IStateWithTranType
    {
        private static UpdateState update = new UpdateState();

        public static IStateWithTranType GetInstance()
        {
            return update;
        }

        public void CheckData()
        {
            Console.WriteLine("更新チェックをします。");
            // なんらかのチェック処理
        }

        public void RegisterData()
        {
            Console.WriteLine("出荷データを更新します。");
            // なんらかのDB処理
        }
    }

    public class DeleteState : IStateWithTranType
    {
        private static DeleteState delete = new DeleteState();

        public static IStateWithTranType GetInstance()
        {
            return delete;
        }

        public void CheckData()
        {
            Console.WriteLine("削除チェックをします。");
            // なんらかのチェック処理
        }

        public void RegisterData()
        {
            Console.WriteLine("出荷データを削除します。");
            // なんらかのDB処理
        }
    }
    #endregion

    /// <summary>
    /// 特定の画面を表すクラス
    /// </summary>
    public class HogeScreen
    {
        public string Name { get; }
        public IStateWithTranType State { get; set; }

        public HogeScreen(string name)
        {
            Name = name;
            State = CreateState.GetInstance();
        }

        /// <summary>
        /// 処理区分（＝状態）の変更
        /// </summary>
        /// <param name="type"></param>
        public void ChangeTranType(IStateWithTranType.TranType type)
        {
            IStateWithTranType oldState = State;
            switch (type)
            {
                case IStateWithTranType.TranType.Create:
                    State = CreateState.GetInstance();
                    break;
                case IStateWithTranType.TranType.Update:
                    State = UpdateState.GetInstance();
                    break;
                case IStateWithTranType.TranType.Delete:
                    State = DeleteState.GetInstance();
                    break;
                default:
                    break;
            }

            Console.WriteLine("状態が変更されました。" + oldState + "⇒" + State);
        }

        /// <summary>
        /// 登録処理（状態に応じてCheckData()とRegisterData()の処理内容が変わる）
        /// </summary>
        public void Register()
        {
            State.CheckData();
            State.RegisterData();
        }

        // その他画面固有のメソッドなど
    }
}
