﻿using System;
using System.Diagnostics;

namespace Benchmarks.Tests
{
    public abstract class BaseTest<T, TN> : BaseTestResult, ITest
    {
        private Stopwatch AutoMapperStopwatch { get; set; }
        private Stopwatch ExpressMapperStopwatch { get; set; }
        private Stopwatch NativeMapperStopwatch { get; set; }
        private Stopwatch OoMapperStopwatch { get; set; }
        private Stopwatch ValueInjectorStopwatch { get; set; }
        private Stopwatch MapsterStopwatch { get; set; }
        private Stopwatch TinyStopwatch { get; set; }

        public void RunTest(int count)
        {
            AutoMapperStopwatch = new Stopwatch();
            ExpressMapperStopwatch = new Stopwatch();
            NativeMapperStopwatch = new Stopwatch();
            OoMapperStopwatch = new Stopwatch();
            ValueInjectorStopwatch = new Stopwatch();
            MapsterStopwatch = new Stopwatch();
            TinyStopwatch = new Stopwatch();

            Count = count;
            
            InitAutoMapper();
            Console.WriteLine("Mapping initialization finished");

            var src = GetData();

            AutoMapperStopwatch = Stopwatch.StartNew();
            AutoMapperMap(src);
            AutoMapperStopwatch.Stop();
            Console.WriteLine("Automapper mapping has been finished");
        }

        protected abstract T GetData();
        protected abstract void InitAutoMapper();
        protected abstract void InitExpressMapper();
        protected abstract void InitOoMapper();
        protected abstract void InitValueInjectorMapper();
        protected abstract void InitMapsterMapper();
        protected abstract void InitTinyMapper();
        protected abstract void InitNativeMapper();

        protected abstract TN AutoMapperMap(T src);
        protected TN ExpressMapperMap(T src) { return default(TN); }
        protected abstract TN OoMapperMap(T src);
        protected abstract TN ValueInjectorMap(T src);
        protected abstract TN MapsterMap(T src);
        protected abstract TN TinyMapperMap(T src);
        protected abstract TN NativeMapperMap(T src);
        //protected abstract string TestName { get; }
        //protected abstract string Size { get; }

        public void RunTestManualForEach(int count)
        {
            throw new NotImplementedException();
        }

        public void PrintResults()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test results for {0} for collection size of {1}", TestName, Count);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Automapper took {0} ms.", AutoMapperStopwatch.ElapsedMilliseconds);
            AddResults("auto", Count, (int)AutoMapperStopwatch.ElapsedMilliseconds);
            Console.WriteLine("Expressmapper took {0} ms.", ExpressMapperStopwatch.ElapsedMilliseconds);
            AddResults("express", Count, (int)ExpressMapperStopwatch.ElapsedMilliseconds);
            if (OoMapperStopwatch.ElapsedMilliseconds == 0)
            {
                Console.WriteLine("Oomapper - not supported mapping");
                AddResults("oomapper", Count, -1);
            }
            else
            {
                Console.WriteLine("Oomapper took {0} ms.", OoMapperStopwatch.ElapsedMilliseconds);
                AddResults("oomapper", Count, (int)OoMapperStopwatch.ElapsedMilliseconds);
            }
            
            if (ValueInjectorStopwatch.ElapsedMilliseconds == 0)
            {
                Console.WriteLine("ValueInjector - not supported mapping");
                AddResults("valueinjecter", Count, -1);
            }
            else
            {
                Console.WriteLine("ValueInjector took {0} ms.", ValueInjectorStopwatch.ElapsedMilliseconds);
                AddResults("valueinjecter", Count, (int)ValueInjectorStopwatch.ElapsedMilliseconds);
            }


            if (MapsterStopwatch.ElapsedMilliseconds == 0)
            {
                Console.WriteLine("Mapster - not supported mapping");
                AddResults("mapster", Count, -1);
            }
            else
            {
                Console.WriteLine("Mapster took {0} ms.", MapsterStopwatch.ElapsedMilliseconds);
                AddResults("mapster", Count, (int)MapsterStopwatch.ElapsedMilliseconds);
            }

            if (TinyStopwatch.ElapsedMilliseconds == 0)
            {
                Console.WriteLine("Tinymapper - not supported mapping");
                AddResults("tiny", Count, -1);
            }
            else
            {
                Console.WriteLine("Tinymapper took {0} ms.", TinyStopwatch.ElapsedMilliseconds);
                AddResults("tiny", Count, (int)TinyStopwatch.ElapsedMilliseconds);
            }

            Console.WriteLine("Native code mapping took {0} ms.", NativeMapperStopwatch.ElapsedMilliseconds);
            AddResults("native", Count, (int)NativeMapperStopwatch.ElapsedMilliseconds);
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
