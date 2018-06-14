using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp.Base;

namespace ConsoleApp.Delegates
{
    public class EventsExample : IDo
    {
        public void Do()
        {
            var source = new SomethingHappenedSource();
            source.SomethingHappened += (sender, args) => Console.WriteLine(args.Something);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Loop [{i}]");
                if(i == 50)
                   source.Trigger("Wow, something happened!");
            }
        }

        private class SomethingHappenedSource
        {
            public event EventHandler<SomethingHappenedEventArgs> SomethingHappened;

            public void Trigger(string something)
            {
                SomethingHappened?.Invoke(this, new SomethingHappenedEventArgs(something));
            }

        }

        private class SomethingHappenedEventArgs : EventArgs
        {
            public SomethingHappenedEventArgs(string something)
            {
                Something = something;
            }

            public string Something { get; }
        } 
    }
}
