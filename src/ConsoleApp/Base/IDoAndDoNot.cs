namespace ConsoleApp.Base
{
    public interface IDoAndDoNot : IDo
    {
        int? Iterations { get; }

        void DoNot();
    }
}
