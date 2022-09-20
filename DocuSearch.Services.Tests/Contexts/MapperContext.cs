using AutoMapper;
using Moq;
using DocuSearch.Entities;
using DocuSearch.ValueObjects;

namespace DocuSearch.Services.Tests.Contexts;

public class MapperContext
{
	private IMapper? _mapper;
	private Mock<IMapper>? _mapperMock;
	
	public IMapper Mapper
	{
		get => _mapper ??= _mapperMock?.Object ?? GetTestMapper();
		set => _mapper = value;
	}

	public Mock<IMapper> MapperMock
	{
		get => _mapperMock ??= new Mock<IMapper>();
		set => _mapperMock = value;
	}

	private IMapper GetTestMapper() {
		var configuration = new MapperConfiguration(cfg => 
		{
			cfg.CreateMap<DocumentVo, DocumentInformation>().ReverseMap();
			cfg.CreateMap<DocumentVo, ElasticDocument>()
				.ForMember(
					dest => dest.Tokens,
					opt => opt.Ignore()
				)
				.ReverseMap();
			cfg.CreateMap<DocumentVo, DocumentFile>().ReverseMap();
		});
		configuration.AssertConfigurationIsValid();
		return configuration.CreateMapper();
	}

}