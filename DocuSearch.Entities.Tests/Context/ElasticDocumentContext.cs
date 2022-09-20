namespace DocuSearch.Entities.Tests.Context;

public class ElasticDocumentContext
{
	private readonly IDictionary<string, ElasticDocument> _testDocuments = new Dictionary<string, ElasticDocument>();

	public void AddElasticDocument(string testDocumentLabel, ElasticDocument elasticDocument)
	{
		_testDocuments[testDocumentLabel] = elasticDocument;
	}

	public ElasticDocument GetElasticDocumentByLabel(string testDocumentLabel)
	{
		return _testDocuments[testDocumentLabel];
	}
}