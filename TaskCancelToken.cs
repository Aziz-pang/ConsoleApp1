namespace BaseApp
{
    internal class TaskCancelToken
    {
        public static async Task MainRun()
        {
            Console.WriteLine("start");
            string url = "https://github.com/aziz-pang/";
            int overtime = 5000;
            // await DownloadAsync(url, 10);
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(overtime);
            CancellationToken token = cts.Token;
            try
            {
                // CancelAction(cts);
                await DownloadForCancelTokenThrowError(url, overtime, token);
            }
            catch (Exception)
            {
                Console.WriteLine("请求已超时：" + overtime);
            }
        }

        static async Task DownloadAsync(string url, int num)
        {
            using (HttpClient client = new HttpClient())
            {
                for (int i = num - 1; i >= 0; i--)
                {
                    string html = await client.GetStringAsync(url);
                    Console.WriteLine(html);
                }
            }
        }

        static async Task DownloadForCancelToken(string url, int num, CancellationToken token)
        {
            using (HttpClient client = new HttpClient())
            {
                for (int i = num - 1; i >= 0; i--)
                {
                    string html = await client.GetStringAsync(url);
                    Console.WriteLine(html);
                    /** 通过 IsCancellationRequestd 退出 */
                    /* 
                    if( token.IsCancellationRequested )
                    {
                        Console.WriteLine("cancel");
                        break;
                    }
                    */
                    token.ThrowIfCancellationRequested();
                }
            }
        }

        static async Task DownloadForCancelTokenThrowError(string url, int num, CancellationToken token)
        {
            using (HttpClient client = new HttpClient())
            {
                for (int i = num - 1; i >= 0; i--)
                {
                    var resp = await client.GetAsync(url, token);
                    string html = await resp.Content.ReadAsStringAsync();
                    Console.WriteLine(html[..50]);
                }
            }
        }

        static void CancelAction(CancellationTokenSource cts)
        {
            if (Console.ReadLine() == "q")
            {
                Console.WriteLine("手动取消");
                cts.Cancel();
            }
        }
    }
}
