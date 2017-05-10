using Samadhi.Application.Crawler;
using Samadhi.Application.Utility;
using Samadhi.Attack.Common;
using Samadhi.History.Controller.Controllers;
using Samadhi.History.Data;
using Samadhi.History.Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Samadhi.Application.Attacker
{
    public class CreateAttackURLs
    {
        private static Action<AttackHistory> _dataGridWrite;
        private static Action _attackCounter;
        private static List<string> _urlHistory = new List<string>();

        public static void Generate(object actDataGrid, object parentAttackHandler, object actCounter)
        {
            int count = 0;
            if (actDataGrid != null)
                _dataGridWrite = (Action<AttackHistory>)actDataGrid;
            ParentAttackHandler attackHandler = (ParentAttackHandler)parentAttackHandler;
            _attackCounter = (Action)actCounter;

            //  SQLiteConnection conn = new SQLiteConnection("data source=" + CrawlerContext.SessionFileName);
            URLHistoryController urlHistoryController = new URLHistoryController();
            URLHistoryFindResult urlHistoryFindResult = urlHistoryController.FindAllBeyondId(CrawlerContext.ScanId);
            if (urlHistoryFindResult.Error)
                throw new Exception(urlHistoryFindResult.Message);
            // string selectQuery = @"SELECT id, url FROM url_history WHERE id > " + CrawlerContext.ScanId + " ORDER BY id ASC";
            try
            {

                foreach (URLHistory urlHistory in urlHistoryFindResult.Items)
                {
                    List<AttackHistory> historyItems = AttackURLGenerator.CreateAttackURL(urlHistory.URL, attackHandler);
                    foreach (AttackHistory history in historyItems)
                    {
                        if (_urlHistory.Contains(history.URL))
                            continue;
                        _urlHistory.Add(history.URL);

                        AttackHistoryController attackHistoryController = new AttackHistoryController();
                        attackHistoryController.Insert(history);

                        if (actDataGrid != null)
                            _dataGridWrite.Invoke(history);

                        count++;
                        _attackCounter.Invoke();
                    }

                    CrawlerContext.ScanId = urlHistory.URLHistoryId;
                }

            }
            catch
            {
                throw;
            }
        }
    }
}