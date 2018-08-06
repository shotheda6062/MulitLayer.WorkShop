using AutoMapper;
using ML.WorkShop.DAL.EntityModel;
using ML.WorkShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.WorkShop.BLL
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            this.CreateMap<MemberViewModel, Member>();
            this.CreateMap<MemberViewModel, MemberLog>();
            this.CreateMap<MemberViewModel, Identity>();
        }
    }
}
