using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Business.ViewModels;
using TechWizard.Business.ViewModels.DTOs;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.ShoppingCartEntities;

namespace TechWizard.Business.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewDTO>()
                .ForMember(x => x.Brand, opt => opt.MapFrom(x => x.Brand.Name))
                .ForMember(x => x.ProductType, opt => opt.MapFrom(x => x.Type.Name))
                .ForMember(x => x.Attributes, opt => opt.MapFrom(GetAttributesAndValues));

            CreateMap<List<Product>, PublicHardwareViewModel>()
                .ForMember(x => x.FilterDTO, opt => opt.MapFrom(GetFilterInfo))
                .ForMember(x => x.MaxPrice, opt => opt.Ignore());

            CreateMap<HardwareCreationDTO, Product>()
                .ForMember(x => x.Picture, opt => opt.Ignore());

            CreateMap<ShoppingViewModel, OrderDetails>()
                .ForMember(x => x.NumOfDifferntProducts, opt => opt.MapFrom(x => x.Order.AmountOfDiffernetItems))
                .ForMember(x => x.TotalNumOfProducts, opt => opt.MapFrom(x => x.Order.AmountOfAllItems))
                .ForMember(x => x.TotalCharge, opt => opt.MapFrom(x => x.Order.TotalCharge))
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(x => x.Customer.Id))
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.Customer.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.Customer.LastName))
                .ForMember(x => x.StreetAddress, opt => opt.MapFrom(x => x.Customer.StreetAddress))
                .ForMember(x => x.City, opt => opt.MapFrom(x => x.Customer.City))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.Customer.PhoneNumber))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Customer.Email));
        }

        private List<(string, string)> GetAttributesAndValues(Product entity, ProductViewDTO view)
        {
            var attributeList = new List<(string, string)>();

            foreach(var attribute in entity.Attributes)
            {
                attributeList.Add((attribute.AttributeType.Name, attribute.Value));
            }
            return attributeList;
        }

        private FilterDTO GetFilterInfo(List<Product> entityList, PublicHardwareViewModel view)
        {
            var idName = new List<(int, string)>();
            var idValue = new List<(int, string)>();

            foreach(var product in entityList)
            {
                foreach(var att in product.Attributes)
                {
                    if(!idName.Any(x => x.Item2 == att.AttributeType.Name))
                    {
                        idName.Add((att.AttributeTypeId, att.AttributeType.Name));
                    }
                    if (!idValue.Any(x => x.Item2 == att.Value))
                    {
                        idValue.Add((att.AttributeTypeId, att.Value));
                    }
                    
                }
            }
            var filterDTO = new FilterDTO() { AttIdAttName = idName, AttIdValue = idValue };
            return filterDTO;
        }
    }
}
