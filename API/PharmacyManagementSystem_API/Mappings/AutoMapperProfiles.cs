using AutoMapper;
using PharmacyManagementSystem.API.Models.Domain;
using PharmacyManagementSystem.API.Models.DTO;

namespace PharmacyManagementSystem.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DrugDto, Drug>().ReverseMap();
            CreateMap<AddDrugRequestDto, Drug>().ReverseMap();
            CreateMap<UpdateDrugRequestDto, Drug>().ReverseMap();

            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<AddOrderRequestDto, Order>().ReverseMap();
            CreateMap<UpdateOrderRequestDto, Order>().ReverseMap();

            CreateMap<PaymentDto, Payment>().ReverseMap();
            CreateMap<AddPaymentRequestDto, Payment>().ReverseMap();
            //CreateMap<UpdatePaymentRequestDto, Payment>().ReverseMap();

            CreateMap<PickedUpOrderDto, PickedUpOrder>().ReverseMap();
            CreateMap<AddPickedUpOrderRequestDto, PickedUpOrder>().ReverseMap();
            //CreateMap<UpdatePickedUpOrderRequestDto, PickedUpOrder>().ReverseMap();

            CreateMap<SupplierDto, Supplier>().ReverseMap();
            CreateMap<AddSupplierRequestDto, Supplier>().ReverseMap();
            CreateMap<UpdateSupplierRequestDto, Supplier>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();    
        }
    }
}
