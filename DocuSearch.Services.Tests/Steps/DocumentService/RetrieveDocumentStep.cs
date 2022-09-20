using DocuSearch.Services.Tests.Contexts;
using DocuSearch.Utility.DummyObjects;
using DocuSearch.ValueObjects.Tests.Contexts;
using NUnit.Framework;

namespace DocuSearch.Services.Tests.Steps.DocumentService;

[Binding]
public class RetrieveDocumentStep
{
	private readonly DocumentVoContext _documentVoContext;
	private readonly ServicesContext _servicesContext;
	private readonly ScenarioContext _scenarioContext;

	public RetrieveDocumentStep(DocumentVoContext documentVoContext, ServicesContext servicesContext, ScenarioContext scenarioContext)
	{
		_documentVoContext = documentVoContext;
		_servicesContext = servicesContext;
		_scenarioContext = scenarioContext;
	}
	
	[When(@"DocumentService\.RetrieveDocumentById is passed DocumentId of ""(.*)"" to retrieve ""(.*)""")]
	public async Task WhenDocumentServiceRetrieveDocumentByIdIsPassedDocumentIdOfToRetrieve(Guid documentId, string testDocumentVoLabel)
	{
		var testDocumentVo = _documentVoContext.GetDocumentVoByLabel(testDocumentVoLabel);
		var dummyFormFile = new DummyFormFile();
		testDocumentVo.FormFile = dummyFormFile.GetDummyFormFile(testDocumentVo.DocumentName!, testDocumentVo.Text!);
		await _servicesContext.DocumentService.UploadDocument(testDocumentVo);
		var resultDocumentVo = await _servicesContext.DocumentService.RetrieveDocumentById(documentId);
		_scenarioContext["Result"] = resultDocumentVo!.DocumentId;
	}

	[Then(@"DocumentService\.RetrieveDocumentById returns a DocumentVo with id ""(.*)""")]
	public void ThenDocumentServiceRetrieveDocumentByIdReturnsADocumentVoWithId(Guid documentId)
	{
		Assert.That(_scenarioContext["Result"], Is.EqualTo(documentId));
	}

	[When(@"DocumentService\.RetrieveDocumentById is passed DocumentId ""(.*)""")]
	public async Task WhenDocumentServiceRetrieveDocumentByIdIsPassedDocumentId(Guid documentId)
	{
		_scenarioContext["Result"] = await _servicesContext.DocumentService.RetrieveDocumentById(documentId);
	}

	[Then(@"DocumentService\.RetrieveDocumentById returns is null")]
	public void ThenDocumentServiceRetrieveDocumentByIdReturnsIsNull()
	{
		Assert.That(_scenarioContext["Result"], Is.Null);
	}

	[When(@"DocumentService\.RetrieveDocumentByName is passed DocumentName of ""(.*)"" to retrieve ""(.*)""")]
	public async Task WhenDocumentServiceRetrieveDocumentByNameIsPassedDocumentNameOfToRetrieve(string documentName, string testDocumentVoLabel)
	{
		var testDocumentVo = _documentVoContext.GetDocumentVoByLabel(testDocumentVoLabel);
		var dummyFormFile = new DummyFormFile();
		testDocumentVo.FormFile = dummyFormFile.GetDummyFormFile(testDocumentVo.DocumentName!, testDocumentVo.Text!);
		await _servicesContext.DocumentService.UploadDocument(testDocumentVo);
		var resultDocumentVo = await _servicesContext.DocumentService.RetrieveDocumentByName(documentName);
		_scenarioContext["Result"] = resultDocumentVo!.DocumentName;
	}
	
	[Then(@"DocumentService\.RetrieveDocumentByName returns a DocumentVo with name ""(.*)""")]
	public void ThenDocumentServiceRetrieveDocumentByNameReturnsADocumentVoWithName(string documentName)
	{
		Assert.That(_scenarioContext["Result"], Is.EqualTo(documentName));
	}

	[When(@"DocumentService\.RetrieveDocumentByName is passed DocumentName ""(.*)""")]
	public async Task WhenDocumentServiceRetrieveDocumentByNameIsPassedDocumentName(string documentName)
	{
		_scenarioContext["Result"] = await _servicesContext.DocumentService.RetrieveDocumentByName(documentName);
	}
	
	[Then(@"DocumentService\.RetrieveDocumentByName returns is null")]
	public void ThenDocumentServiceRetrieveDocumentByNameReturnsIsNull()
	{
		Assert.That(_scenarioContext["Result"], Is.Null);
	}
}