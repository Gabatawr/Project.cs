using System.IO;

namespace ThreadExamTaskOne
{
    partial class Program
    {
        static class AppPath
        {
            public static string App { get; }
            public static string Search { get; }
            public static string FileStat { get; }
            public static string FileWords { get; }
            public static string FileExtensions { get; }
            static AppPath()
            {
                App = Directory.GetCurrentDirectory();
                Search = @"E:\Code";
                FileStat = App + '\\' + "stat.txt";
                FileWords = App + '\\' + "words.txt";
                FileExtensions = App + '\\' + "extensions.txt";
            }
        }
    }
}
