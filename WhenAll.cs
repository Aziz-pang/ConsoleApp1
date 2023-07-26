namespace BaseApp
{
    internal class WhenAll
    {
        public static async void MainRun()
        {
            Console.WriteLine("Strat WhenAll \n");
            string[] files = Directory.GetFiles(@"c:/temp");
            Task<int>[] countTasks = new Task<int>[files.Length];

            for(int i = files.Length - 1;i >= 0;i--)
            {
                Task<int> t = ReadCharsCount(files[i]);
                countTasks[i] = t;
            }
            int[] counts = await Task.WhenAll(countTasks);
            int c = counts.Sum(); // 计算数组的和
            Console.WriteLine($"共有 {files.Length} 个文件，总字符数为: {c} 个");
        }

        static async Task<int> ReadCharsCount(string fileName)
        {
            string str = await File.ReadAllTextAsync(fileName);
            return str.Length;
        }
    }
}
