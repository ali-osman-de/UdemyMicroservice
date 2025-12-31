using UdemyMicroservice.Catalog.Api.Features.Categories.Update;

namespace UdemyMicroservice.Catalog.Api.Features.Categories
{
    public class Mapper : Profile
    {
        public Mapper() {
        
            CreateMap<Category, CategoryDto>()
                .ReverseMap();

            CreateMap<UpdateCategoryCommand, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore());


        }
    }
}
