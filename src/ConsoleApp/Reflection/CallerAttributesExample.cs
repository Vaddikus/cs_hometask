using System;
using System.IO;
using System.Runtime.CompilerServices;
using ConsoleApp.Base;

namespace ConsoleApp.Reflection
{
    public class CallerAttributesExample : IDo
    {
        public void Do()
        {
            MySuperLog("something happened");
        }

        private void MySuperLog(
            string text,
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLineNumber = 0,
            [CallerFilePath] string callerFilePath = "")
        {
            Console.WriteLine($"[{DateTime.Now}] [{Path.GetFileNameWithoutExtension(callerFilePath)}] [{callerMemberName}] {text}, line: {callerLineNumber}");
        }
    }
}
