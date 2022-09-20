using NUnit.Framework;
using DocuSearch.DataAccess.Tests.Context;
using DocuSearch.Entities.Tests.Context;
using DocuSearch.Utility.DummyObjects;

namespace DocuSearch.DataAccess.Tests.Steps.FileStorageDataAccess;

[Binding]
public class StoreDocumentFileStep
{
	private readonly DocumentFileContext _documentFileContext;
	private readonly DataAccessContext _dataAccessContext;
	private readonly ScenarioContext _scenarioContext;

	public StoreDocumentFileStep(DocumentFileContext documentFileContext, DataAccessContext dataAccessContext, ScenarioContext scenarioContext)
	{
		_documentFileContext = documentFileContext;
		_dataAccessContext = dataAccessContext;
		_scenarioContext = scenarioContext;
	}

	[When(@"FileStorageDataAccess\.StoreDocumentFile is passed File labeled ""(.*)""")]
	public async Task WhenFileStorageDataAccessStoreDocumentFileIsPassedFileLabeled(string testDocumentLabel)
	{
		var documentFile = _documentFileContext.GetDocumentFileByLabel(testDocumentLabel);
		var dummyFormFile = new DummyFormFile();
		documentFile.FormFile = dummyFormFile.GetDummyFormFile(documentFile.DocumentName!);
		_scenarioContext["Result"] = await _dataAccessContext.FileStorageDataAccess.StoreDocumentFile(documentFile);
	}

	[Then(@"FileStorageDataAccess\.StoreDocumentFile returns ""(.*)""")]
	public void ThenFileStorageDataAccessStoreDocumentFileReturns(bool isStored)
	{
		Assert.That(_scenarioContext["Result"], Is.EqualTo(isStored));
	}
}