using AutoMapper;
using Feedbacks.Repository;
using Shop.Infrastructure.DTO;

namespace Feedbacks.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Feedback, FeedbackDTO>();
            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
        }
    }
}
