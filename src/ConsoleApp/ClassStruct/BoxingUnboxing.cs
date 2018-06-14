using ConsoleApp.Base;

namespace ConsoleApp.ClassStruct
{
    public class BoxingUnboxing : IDo
    {
        public void Do()
        {
            double doubleValue = 1.23;

            int intValue = (int)doubleValue;
            var boxed = (object)doubleValue;

            // Ok
            var unboxedDouble  = (double)boxed;

            // Error
            var unboxedInt = (int)boxed;
        }

        public class A
        {
            public int Value = 1;

            public void DoWork()
            {
                int result = Value + 1;
            }
        }
    }
}
