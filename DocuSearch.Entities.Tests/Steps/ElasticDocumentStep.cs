using TechTalk.SpecFlow.Assist;
using DocuSearch.Entities.Tests.Context;

namespace DocuSearch.Entities.Tests.Steps;

[Binding]
public class ElasticDocumentStep
{
	private readonly ElasticDocumentContext _elasticDocumentContext;

	public ElasticDocumentStep(ElasticDocumentContext elasticDocumentContext)
	{
		_elasticDocumentContext = elasticDocumentContext;
	}
	
	[Given(@"a new ElasticDocument labeled ""(.*)"" with the values:")]
	public void GivenANewElasticDocumentLabeledWithTheValues(string testDocumentLabel, Table table)
	{
		var elasticDocument = table.CreateInstance<ElasticDocument>();
		_elasticDocumentContext.AddElasticDocument(testDocumentLabel, elasticDocument);
	}
}