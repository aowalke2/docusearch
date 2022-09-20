using DocuSearch.Entities;

namespace DocuSearch.DataAccess.Interfaces;

public interface IElasticSearchDataAccess
{
	Task<bool> IndexElasticDocument(ElasticDocument elasticDocument);
}