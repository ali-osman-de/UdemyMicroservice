using UdemyMicroservice.Catalog.Api.Features.Courses.Create;

namespace UdemyMicroservice.Catalog.Api.Features.Courses;

public class Mapper : Profile
{
    public Mapper() {

        CreateMap<CreateCourseCommand, Course>().ReverseMap();

    }
}
