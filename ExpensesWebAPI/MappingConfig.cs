using ExpensesWebAPI.Model;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using AutoMapper;
using ExpensesWebAPI.Model.DTOs;

namespace ExpensesWebAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Expense, ExpensesDto>().ReverseMap();
            CreateMap<Expense, CreateExpensesDto>().ReverseMap();
        }

    }
}
