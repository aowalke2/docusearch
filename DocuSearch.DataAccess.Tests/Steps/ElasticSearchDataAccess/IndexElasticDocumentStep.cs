using Moq;
using NUnit.Framework;
using DocuSearch.DataAccess.Tests.Context;
using DocuSearch.Entities;
using DocuSearch.Entities.Tests.Context;

namespace DocuSearch.DataAccess.Tests.Steps.ElasticSearchDataAccess;

[Binding]
public class IndexElasticDocumentStep
{
	private readonly ElasticDocumentContext _elasticDocumentContext;
	private readonly DataAccessContext _dataAccessContext;
	private readonly ScenarioContext _scenarioContext;

	public IndexElasticDocumentStep(ElasticDocumentContext elasticDocumentContext, DataAccessContext dataAccessContext, ScenarioContext scenarioContext)
	{
		_elasticDocumentContext = elasticDocumentContext;
		_dataAccessContext = dataAccessContext;
		_scenarioContext = scenarioContext;
	}
	
	//This will new to made an integration test at some point
	[When(@"ElasticSearchDataAccess\.IndexElasticDocument is passed ElasticDocument labeled ""(.*)""")]
	public async Task WhenElasticSearchDataAccessIndexElasticDocumentIsPassedElasticDocumentLabeled(string testDocumentLabel)
	{
		await Task.Yield();
		// var elasticDocument = _elasticDocumentContext.GetElasticDocumentByLabel(testDocumentLabel);
		// _scenarioContext["Result"] = await _dataAccessContext.ElasticSearchDataAccess.IndexElasticDocument(elasticDocument);
	}

	[Then(@"ElasticSearchDataAccess\.IndexElasticDocument returns ""(.*)""")]
	public void ThenElasticSearchDataAccessIndexElasticDocumentReturns(bool isIndexed)
	{
		//Assert.That(_scenarioContext["Result"], Is.EqualTo(isIndexed));
	}
}