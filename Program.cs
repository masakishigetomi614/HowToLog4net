using System;
using BipsV2.Models.Sample;
using BipsV2Classlib.Service;
using BipsV2Classlib.Service.BAT;
using BipsV2Classlib.Service.DA;

namespace SampleBat
{
    public class Program
    {
        /// <summary>
        /// リクエストヘッダーのキー名：ログインユーザ名
        /// </summary>
        private const string BAT_NAME = "SampleBat";

        /// <summary>
        /// ロガー
        /// </summary>
        private static readonly LogOutputService LogOutputService = new LogOutputService("Sample");

        /// <summary>
        /// サンプルのDAサービス
        /// </summary>
        private static SampleDAService sampleDAService;

        public static void Main(string[] args)
        {
            Hoge();
        }

        private static void Hoge()
        {
            using var databaseConnectService = new DatabaseConnectService();
            using var transaction = databaseConnectService.BeginTransaction();
            try
            {
                sampleDAService = new SampleDAService(databaseConnectService, BAT_NAME, transaction);
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");

                var entryData = new sampleModel()
                {
                    column1 = $"column1-{now}",
                    column2 = $"column2-{now}",
                    column3 = $"column3-{now}",
                };

                sampleDAService.Insert(entryData);
                LogOutputService.Info("処理成功です！");
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                LogOutputService.Error(ex.ToString());
            }
        }
    }
}
