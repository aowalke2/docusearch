using AutoMapper;
using DocuSearch.DataAccess.Interfaces;
using DocuSearch.Entities;
using DocuSearch.Service.Interfaces;
using DocuSearch.ValueObjects;

namespace DocuSearch.Services;

public class ElasticSearchService : IElasticSearchService
{
	private readonly IElasticSearchDataAccess _elasticSearchDataAccess;
	private readonly IMapper _mapper;
	public ElasticSearchService(IElasticSearchDataAccess elasticSearchDataAccess, IMapper mapper)
	{
		_elasticSearchDataAccess = elasticSearchDataAccess;
		_mapper = mapper;
	}
	
	public async Task<bool> AddDocumentToIndex(DocumentVo documentVo)
	{
		await using (var stream = documentVo.FormFile!.OpenReadStream())
		{
			using (var streamReader = new StreamReader(stream))
			{
				documentVo.Text = await streamReader.ReadToEndAsync();
			}
		}

		var elasticDocument = _mapper.Map<ElasticDocument>(documentVo);
		return await _elasticSearchDataAccess.IndexElasticDocument(elasticDocument);
	}
}