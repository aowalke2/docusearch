using AutoMapper;
using DocuSearch.Entities;
using DocuSearch.ValueObjects;

namespace DocuSearch.Services.VoToEntityMaps;

public class DocumentVoToEntityProfile : Profile
{
	public DocumentVoToEntityProfile()
	{
		CreateMap<DocumentVo, DocumentInformation>().ReverseMap();
		CreateMap<DocumentVo, ElasticDocument>()
			.ForMember(
				dest => dest.Tokens,
				opt => opt.Ignore()
			).ReverseMap();
		CreateMap<DocumentVo, DocumentFile>().ReverseMap();
	}
}