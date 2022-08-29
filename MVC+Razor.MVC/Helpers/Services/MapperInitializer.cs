namespace MVC_Razor.MVC.Helpers.Services;

public class MapperInitializer : Profile
{
	public MapperInitializer()
	{
		CreateMap<Customer, CustomerDto>().ReverseMap();
	}
}
