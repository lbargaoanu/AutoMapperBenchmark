using System;
using System.Collections.Generic;
using Benchmarks.Generators;
using Benchmarks.Mapping;
using Benchmarks.Models;
using Benchmarks.ViewModels;
using Mapster;

namespace Benchmarks.Tests
{
    public class ComplexTest : BaseTest<List<Test>, List<TestViewModel>>
    {
        protected override List<Test> GetData()
        {
            return DataGenerator.GetTests(Count);
        }

        protected override void InitAutoMapper()
        {
            MyAuto.Init();
        }

        protected override void InitExpressMapper()
        {
            
        }

        protected override void InitOoMapper()
        {
            
        }

        protected override void InitValueInjectorMapper()
        {
            ValueInjectorMappings.Init();
        }

        protected override void InitMapsterMapper()
        {
            MapsterMapperMappings.Init();
        }

        protected override void InitTinyMapper()
        {
            TinyMapperMappings.Init();
        }

        protected override void InitNativeMapper()
        {
        }

        protected override List<TestViewModel> AutoMapperMap(List<Test> src)
        {
            return AutoMapper.Mapper.Map<List<Test>, List<TestViewModel>>(src);
        }

        protected override List<TestViewModel> OoMapperMap(List<Test> src)
        {
            // Custom constructor, beforeMap, AfterMap is not supported

            throw new NotImplementedException();
            //return OoMapper.Mapper.Map<List<Test>, List<TestViewModel>>(src);
        }

        protected override List<TestViewModel> ValueInjectorMap(List<Test> src)
        {
            var list = new List<TestViewModel>();
            foreach (var item in src)
            {
                list.Add(Omu.ValueInjecter.Mapper.Map<Test, TestViewModel>(item));
            }
            return list;
        }

        protected override List<TestViewModel> MapsterMap(List<Test> src)
        {
            return TypeAdapter.Adapt<List<Test>, List<TestViewModel>>(src);
        }

        protected override List<TestViewModel> TinyMapperMap(List<Test> src)
        {
            throw new NotImplementedException();
        }

        protected override List<TestViewModel> NativeMapperMap(List<Test> src)
        {
            var list = new List<TestViewModel>();
            foreach (var test in src)
            {
                list.Add(NativeMapping.Map(test));
            }
            return list;
        }

        protected override string TestName
        {
            get { return "ComplexTest"; }
        }

        protected override string Size
        {
            get { return "XXL"; }
        }
    }
}
