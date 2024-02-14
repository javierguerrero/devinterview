using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DevInterview.AdminPanel.Application.Mapper
{
    public class AdminPanelProfile : Profile
    {
        public AdminPanelProfile()
        {
            CreateMap<Role, RoleResponse>().ReverseMap();
        }
    }
}
