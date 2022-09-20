using NUnit.Framework;
using DocuSearch.Services.Tests.Contexts;
using DocuSearch.Utility.DummyObjects;
using DocuSearch.ValueObjects.Tests.Contexts;

namespace DocuSearch.Services.Tests.Steps.ElasticSearchService;

[Binding]
public class AddDocumentToIndexStep
{
	private readonly DocumentVoContext _documentVoContext;
	private readonly ServicesContext _servicesContext;
	private readonly ScenarioContext _scenarioContext;

	public AddDocumentToIndexStep(DocumentVoContext documentVoContext, ServicesContext servicesContext, ScenarioContext scenarioContext)
	{
		_documentVoContext = documentVoContext;
		_servicesContext = servicesContext;
		_scenarioContext = scenarioContext;
	}

	[When(@"ElasticSearchService\.AddDocumentToIndex is passed documentVo labeled ""(.*)""")]
	public async Task WhenElasticSearchServiceAddDocumentToIndexIsPassedDocumentVoLabeled(string testDocumentLabel)
	{
		var documentVo = _documentVoContext.GetDocumentVoByLabel(testDocumentLabel);
		var dummyFormFile = new DummyFormFile();
		documentVo.FormFile = dummyFormFile.GetDummyFormFile(documentVo.DocumentName!, documentVo.Text!);
		_scenarioContext["Result"] = await _servicesContext.ElasticSearchService.AddDocumentToIndex(documentVo);
	}

	[Then(@"ElasticSearchService\.AddDocumentToIndex returns ""(.*)""")]
	public void ThenElasticSearchServiceAddDocumentToIndexReturns(bool isIndex)
	{
		Assert.That(_scenarioContext["Result"], Is.EqualTo(isIndex));
	}
}