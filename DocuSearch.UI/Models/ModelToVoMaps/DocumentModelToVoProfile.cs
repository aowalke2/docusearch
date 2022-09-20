using AutoMapper;
using DocuSearch.ValueObjects;

namespace DocuSearch.UI.Models.ModelToVoMaps;

public class DocumentModelToVoProfile : Profile
{
	public DocumentModelToVoProfile()
	{
		CreateMap<DocumentModel, DocumentVo>().ReverseMap();
		// CreateMap<DocumentModel, DocumentVo>()
		// 	.ForMember(
		// 		dest => dest.DocumentName,
		// 		from => from.MapFrom(x => x.DocumentName)
		// 	);
	}
}