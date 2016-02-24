using System;
using System.Threading;
using Benchmarks.Tests;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleStructTest = new SimpleStructTest();
            simpleStructTest.RunTest(100000);
            simpleStructTest.PrintResults();

            //simpleStructTest.RunTest(500000);
            //simpleStructTest.PrintResults();

            //simpleStructTest.RunTest(1000000);
            //simpleStructTest.PrintResults();

            var simpleTest = new SimpleTest();
            simpleTest.RunTest(100000);
            simpleTest.PrintResults();

            //simpleTest.RunTest(1000000);
            //simpleTest.PrintResults();


            //simpleTest.RunTest(3000000);
            //simpleTest.PrintResults();

            var simpleAssociationTest = new SimpleWithAssociationTest();
            simpleAssociationTest.RunTest(100000);
            simpleAssociationTest.PrintResults();

            //simpleAssociationTest.RunTest(500000);
            //simpleAssociationTest.PrintResults();

            //simpleAssociationTest.RunTest(1000000);
            //simpleAssociationTest.PrintResults();

            var simpleCollectionTest = new SimpleWithCollectionTest();
            simpleCollectionTest.RunTest(10000);
            simpleCollectionTest.PrintResults();

            //simpleCollectionTest.RunTest(50000);
            //simpleCollectionTest.PrintResults();

            //simpleCollectionTest.RunTest(100000);
            //simpleCollectionTest.PrintResults();

            var advancedTest = new AdvancedTest();
            advancedTest.RunTest(10000);
            advancedTest.PrintResults();

            //advancedTest.RunTest(100000);
            //advancedTest.PrintResults();

            //advancedTest.RunTest(200000);
            //advancedTest.PrintResults();

            var complexTest = new ComplexTest();
            complexTest.RunTest(10000);
            complexTest.PrintResults();

            //complexTest.RunTest(100000);
            //complexTest.PrintResults();

            //complexTest.RunTest(200000);
            //complexTest.PrintResults();

            BaseTestResult.FormatResults();

            //Console.ReadLine();
        }
    }
}