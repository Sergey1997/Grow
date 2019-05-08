using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.SkillModels;
using Web.Models.ViewModels;

namespace Web.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Skill, SkillViewModel>();
            CreateMap<CategoryOfSkill, CategoryViewModel>();
            CreateMap<Material, MaterialViewModel>();
            CreateMap<Task, CreateTaskViewModel>();
        }
    }
}