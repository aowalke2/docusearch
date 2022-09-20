using NUnit.Framework;
using DocuSearch.Services.Tests.Contexts;
using DocuSearch.Utility.DummyObjects;
using DocuSearch.ValueObjects.Tests.Contexts;

namespace DocuSearch.Services.Tests.Steps.FileStorageService;

[Binding]
public class AddFileToStoreStep
{
	private readonly DocumentVoContext _documentVoContext;
	private readonly ServicesContext _servicesContext;
	private readonly ScenarioContext _scenarioContext;

	public AddFileToStoreStep(DocumentVoContext documentVoContext, ServicesContext servicesContext, ScenarioContext scenarioContext)
	{
		_documentVoContext = documentVoContext;
		_servicesContext = servicesContext;
		_scenarioContext = scenarioContext;
	}

	[When(@"FileStorageService\.AddFileToStore is passed documentVo labeled ""(.*)""")]
	public async Task WhenFileStorageServiceAddFileToStoreIsPassedDocumentVoLabeled(string testDocumentLabel)
	{
		var documentVo = _documentVoContext.GetDocumentVoByLabel(testDocumentLabel);
		var dummyFormFile = new DummyFormFile();
		documentVo.FormFile = dummyFormFile.GetDummyFormFile(documentVo.DocumentName!, documentVo.Text!);
		_scenarioContext["Result"] = await _servicesContext.FileStorageService.AddFileToStore(documentVo);
	}

	[Then(@"FileStorageService\.AddFileToStore returns ""(.*)""")]
	public void ThenFileStorageServiceAddFileToStoreReturns(bool isStored)
	{
		Assert.That(_scenarioContext["Result"], Is.EqualTo(isStored));
	}
}