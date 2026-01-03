using UdemyMicroservice.Catalog.Api.Features.Courses.Create;
using UdemyMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace UdemyMicroservice.Catalog.Api.Features.Courses;

public class Mapper : Profile
{
    public Mapper() {

        CreateMap<CreateCourseCommand, Course>().ReverseMap();
        CreateMap<CourseDto, Course>().ReverseMap();
        CreateMap<FeatureDto, Feature>().ReverseMap();
    }
}
