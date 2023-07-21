// See https://aka.ms/new-console-template for more information

using System.Runtime;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await WriteFileAsync(@"C:\temp\1.txt", "hello async");
        int htmlLength = await DownloadHtmlAsync("https://github.com/Aziz-pang/", @"C:\temp\2.txt");
        Console.WriteLine("html 长度为: " + htmlLength);
    }

    private static async Task WriteFileAsync(string path, string contents)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 10 - 1; i >= 0; i--)
        {
            sb.AppendLine(contents);
        }
        await File.WriteAllTextAsync(path, sb.ToString());

        string str = await File.ReadAllTextAsync(path);
        Console.WriteLine(str);
    }

    private static async Task<int> DownloadHtmlAsync(string url, string fileName)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            string html = await httpClient.GetStringAsync(url);
            File.WriteAllTextAsync(fileName, html).Wait();
            Console.WriteLine("is OK!");
            return html.Length;
        }
    }
}