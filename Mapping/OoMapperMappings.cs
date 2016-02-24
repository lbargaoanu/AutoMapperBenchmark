﻿using Benchmarks.Enums;
using Benchmarks.Models;
using Benchmarks.ViewModels;
using OoMapper;

namespace Benchmarks.Mapping
{
    public class OoMapperMappings
    {
        public static void Init()
        {
            Mapper.Reset();
            Mapper.CreateMap<ProductVariant, ProductVariantViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.DefaultSharedOption, src => src.MapFrom(m => m.DefaultOption));
            Mapper.CreateMap<Test, TestViewModel>()
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight * 2))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Type, src => src.MapFrom(m => (Types)m.Type))
                .ForMember(dest => dest.Name, src => src.MapFrom(m => string.Format("{0} - {1} - {2}", m.Name, m.Weight, m.Age)))
                .ForMember(dest => dest.SpareTheProduct, opt => opt.MapFrom(src => src.SpareProduct))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => string.Format("{0} - {1}", src.Name, src.Id)))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            Mapper.CreateMap<News, NewsViewModel>();

            Mapper.CreateMap<Role, RoleViewModel>();
            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.BelongTo, src => src.MapFrom(m => m.Role));

            Mapper.CreateMap<Article, ArticleViewModel>();
            Mapper.CreateMap<Author, AuthorViewModel>()
                .ForMember(dest => dest.OwnedArticles, src => src.MapFrom(m => m.Articles));

            Mapper.CreateMap<Item, ItemViewModel>();
        }

        public static void InitAdvanced()
        {
            Mapper.Reset();
            Mapper.CreateMap<ProductVariant, ProductVariantViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.DefaultSharedOption, src => src.MapFrom(m => m.DefaultOption));
            Mapper.CreateMap<Test, TestViewModel>()
                .ForMember(dest => dest.Type, src => src.MapFrom(m => (Types)m.Type))
                .ForMember(dest => dest.Age, src => src.MapFrom(m => m.Age))
                .ForMember(dest => dest.Weight, src => src.MapFrom(m => m.Weight * 2))
                .ForMember(dest => dest.Name,
                    src => src.MapFrom(m => string.Format("{0} - {1} - {2}", m.Name, m.Weight, m.Age)))
                .ForMember(dest => dest.SpareTheProduct, src => src.MapFrom(m => m.SpareProduct))
                .ForMember(dest => dest.Description, src => src.MapFrom(m => string.Format("{0} - {1}", m.Name, m.Id)));

            Mapper.CreateMap<News, NewsViewModel>();

            Mapper.CreateMap<Role, RoleViewModel>();
            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.BelongTo, src => src.MapFrom(m => m.Role));

            Mapper.CreateMap<Article, ArticleViewModel>();
            Mapper.CreateMap<Author, AuthorViewModel>()
                .ForMember(dest => dest.OwnedArticles, src => src.MapFrom(m => m.Articles));

            Mapper.CreateMap<Item, ItemViewModel>();
        }
    }
}
