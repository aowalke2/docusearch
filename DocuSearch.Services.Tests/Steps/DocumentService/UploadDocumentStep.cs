using DocuSearch.Services.Tests.Contexts;
using DocuSearch.Utility.DummyObjects;
using DocuSearch.Utility.Exceptions.DataAccessExceptions;
using DocuSearch.Utility.Exceptions.ServiceExceptions;
using DocuSearch.ValueObjects.Tests.Contexts;
using NUnit.Framework;

namespace DocuSearch.Services.Tests.Steps.DocumentService;

[Binding]
public class UploadDocumentStep
{
	private readonly DocumentVoContext _documentVoContext;
	private readonly ServicesContext _servicesContext;
	private readonly ScenarioContext _scenarioContext;

	public UploadDocumentStep(DocumentVoContext documentVoContext, ServicesContext servicesContext, ScenarioContext scenarioContext)
	{
		_documentVoContext = documentVoContext;
		_servicesContext = servicesContext;
		_scenarioContext = scenarioContext;
	}
	
	[When(@"DocumentService\.UploadDocument is passed DocumentVo labeled ""(.*)""")]
	public async Task WhenDocumentServiceUploadDocumentIsPassedDocumentVoLabeled(string testDocumentVoLabel)
	{
		var documentVo = _documentVoContext.GetDocumentVoByLabel(testDocumentVoLabel);
		var dummyFormFile = new DummyFormFile();
		documentVo.FormFile = dummyFormFile.GetDummyFormFile(documentVo.DocumentName!, documentVo.Text!);
		_scenarioContext["Result"] = await _servicesContext.DocumentService.UploadDocument(documentVo);
	}

	[Then(@"DocumentService\.UploadDocument returns ""(.*)""")]
	public void ThenDocumentServiceUploadDocumentReturns(bool isUploaded)
	{
		Assert.That(_scenarioContext["Result"], Is.EqualTo(isUploaded));
	}

	[Then(@"DocumentService\.UploadDocument throws an FileStorageFailureException from being passed ""(.*)""")]
	public void ThenDocumentServiceUploadDocumentThrowsAnFileStorageFailureExceptionFromBeingPassed(string testDocumentVoLabel)
	{
		var documentVo = _documentVoContext.GetDocumentVoByLabel(testDocumentVoLabel);
		var dummyFormFile = new DummyFormFile();
		documentVo.FormFile = dummyFormFile.GetDummyFormFile(documentVo.DocumentName!, documentVo.Text!);
		Assert.ThrowsAsync<FileStorageFailureException>(() => _servicesContext.DocumentService.UploadDocument(documentVo));
	}

	[Then(@"DocumentService\.UploadDocument throws an DataAccessStoreFailureException from being passed ""(.*)""")]
	public void ThenDocumentServiceUploadDocumentThrowsAnDataAccessStoreFailureExceptionFromBeingPassed(string testDocumentVoLabel)
	{
		var documentVo = _documentVoContext.GetDocumentVoByLabel(testDocumentVoLabel);
		var dummyFormFile = new DummyFormFile();
		documentVo.FormFile = dummyFormFile.GetDummyFormFile(documentVo.DocumentName!, documentVo.Text!);
		Assert.ThrowsAsync<DataAccessStoreFailureException>(() => _servicesContext.DocumentService.UploadDocument(documentVo));
	}
}