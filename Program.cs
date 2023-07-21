// See https://aka.ms/new-console-template for more information

using System.Text;

string fileName = @"c:\temp\1.txt";

StringBuilder sb = new StringBuilder();
for(int i=0; i < 100; i++)
{
    sb.AppendLine("hello world. async");
}
// File.WriteAllText(fileName, "hello world!");
await File.WriteAllTextAsync(fileName, sb.ToString());

string str = await File.ReadAllTextAsync(fileName);
Console.WriteLine(str);