using Nest;
using DocuSearch.DataAccess.Interfaces;
using DocuSearch.Entities;

namespace DocuSearch.DataAccess;

public class ElasticSearchDataAccess : IElasticSearchDataAccess
{
	private readonly IElasticClient _elasticClient;

	public ElasticSearchDataAccess(IElasticClient elasticClient)
	{
		_elasticClient = elasticClient;
	}
	public async Task<bool> IndexElasticDocument(ElasticDocument elasticDocument)
	{
		var analyzeResponse = await _elasticClient.Indices.AnalyzeAsync(a => a
				.Tokenizer("standard")
				.Filter("lowercase", "unique", "stop")
				.Text(elasticDocument.Text)
		);
		if (!analyzeResponse.IsValid) return false;

		IList<string> tokens = new List<string>();
		foreach (var token in analyzeResponse.Tokens)
		{
			tokens.Add(token.Token);
		}
		elasticDocument.Tokens = tokens;
		
		var indexResponse = await _elasticClient.IndexAsync(elasticDocument, d => d.Index("document-index"));
		return indexResponse.IsValid;
	}
}