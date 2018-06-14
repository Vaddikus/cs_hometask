using System.Text;
using ConsoleApp.Base;

namespace ConsoleApp.ClassStruct
{
    public class StringDoAndDoNot : IDoAndDoNot
    {
        public int? Iterations { get; } = 100000;

        public void Do()
        {
            var resultBuilder = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                resultBuilder.Append($"My long string {i}");
            }

            var result = resultBuilder.ToString();
        }

        public void DoNot()
        {
            var resultBuilder = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                resultBuilder.Append(string.Format("My long string {0}", i));
            }
        }
    }
}
