using System;
using System.Linq;
using ConsoleApp.Base;
using ConsoleApp.ClassStruct;
using ConsoleApp.Collections;
using ConsoleApp.Delegates;
using ConsoleApp.Enums;
using ConsoleApp.Generics;
using ConsoleApp.Linq;
using ConsoleApp.Reflection;
using ConsoleApp.SerializationDeserialization;

namespace ConsoleApp
{
    public static class Program
    {
        private static readonly MetricCollector MetricCollector = new MetricCollector();

        public static void Main(string[] args)
        {
            RunPart1();
            RunPart2();
            RunPart3();

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static void RunPart1()
        {
            // Class / Struct
            //new ClassStructExample().Do();

            // Boxing / Unboxing
            //new BoxingUnboxing().Do();

            // Strings
            //MetricCollector.PrintMetrics(new StringDoAndDoNot());

            // ConstructorDestructorDisposable
            //new ConstructorDestructorDisposable().Do();

            // Collections
            //new CollectionsExample().Do();

            // Generics
            //new GenericsExample().Do();

            // Delegates
            //new DelegatesExample().Do();

            // Predicates
            //new ActionsExample().Do();

            // Functions
            //new FunctionsExample().Do();

            // Predicates
            //new PredicateExample().Do();
        }

        private static void RunPart2()
        {
            // Lambda
            //new LambdaExample().Do();

            // Generics
            //new GenericsExample().Do();

            // Extension methods
            //new ExtensionMethodsExample().Do();

            // Linq
            //new LinqExamples().Do();
        }

        private static void RunPart3()
        {
            // Enums
            //new EnumsExample().Do();

            // Serialization / Deserialization
            //new SerializationDeserializationExample().Do();

            // Attributes
            //new AttributesExample().Do();

            // Caller attributes
            //new CallerAttributesExample().Do();

            // Reflection
            //new ReflectionExamples().Do();

            // Reflection performance test
            //new ReflectionPerformanceTest().Do();
        }

        public static void NextParts()
        {
            // Events
            //new EventsExample().Do();
        }
    }
}
