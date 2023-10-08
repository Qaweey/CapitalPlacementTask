

using AutoMapper;
using CapitalPlacementTask.Dtos;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<AddAQuestion, AddAQuestionDto>().ReverseMap();
            CreateMap<MultipleChoiceQuestions, MultipleChoiceQuestionsDto>().ReverseMap();
            CreateMap<DropDown, DropDownDto>().ReverseMap();
            CreateMap<Profiles, ProfileDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<WorkExperience, WorkExperienceDto>().ReverseMap();
            CreateMap<AdditionalQuestions, AdditionalQuestionsDto>().ReverseMap();
            CreateMap<ProgramDetails, ProgramDetailsDto>().ReverseMap();
            CreateMap<AdditionalProgramInfo, AdditionalProgramInfoDto>().ReverseMap();
            CreateMap<WorkFlow, WorkFlowDto>().ReverseMap();
            CreateMap<WorkFlow, WorkFlowDto>().ReverseMap();



            // Add other mappings as needed
        }
    }
}
