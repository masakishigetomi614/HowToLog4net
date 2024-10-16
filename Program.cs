using log4net;

public class Program
{
    // ロガーの設定
    private static readonly ILog log = LogManager.GetLogger(typeof(Program));

    public static void Main(string[] args)
    {
        // ログの初期化
        log.Info("アプリケーションが開始されました。");

        try
        {
            // 例としてエラーログを出力
            throw new Exception("例外が発生しました！");
        }
        catch (Exception ex)
        {
            log.Error("エラーが発生しました: ", ex);
        }

        log.Info("アプリケーションが終了します。");
    }
}
