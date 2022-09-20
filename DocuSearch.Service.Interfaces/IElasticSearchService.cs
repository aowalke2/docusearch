using DocuSearch.ValueObjects;

namespace DocuSearch.Service.Interfaces;

public interface IElasticSearchService
{
	Task<bool> AddDocumentToIndex(DocumentVo documentVo);
}