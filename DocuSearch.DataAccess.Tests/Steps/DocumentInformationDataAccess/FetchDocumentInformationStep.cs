using NUnit.Framework;
using DocuSearch.DataAccess.Tests.Context;
using DocuSearch.Entities.Tests.Context;

namespace DocuSearch.DataAccess.Tests.Steps;

[Binding]
public class FetchDocumentInformationStep
{
	private readonly DocumentInformationContext _documentInformationContext;
	private readonly DataAccessContext _dataAccessContext;
	private readonly ScenarioContext _scenarioContext;

	public FetchDocumentInformationStep(DocumentInformationContext documentInformationContext, DataAccessContext dataAccessContext, ScenarioContext scenarioContext)
	{
		_documentInformationContext = documentInformationContext;
		_dataAccessContext = dataAccessContext;
		_scenarioContext = scenarioContext;
	}
	
	[When(@"DocumentInformationDataAccess\.FetchDocumentInformationById is passed a DocumentId of ""(.*)""")]
	public async Task WhenDocumentDataAccessFetchDocumentByIdIsPassedADocumentIdOf(Guid documentId)
	{
		_scenarioContext["Result"] = await _dataAccessContext.DocumentInformationDataAccess.FetchDocumentInformationById(documentId);
	}

	[Then(@"DocumentInformationDataAccess.FetchDocumentInformationById returns a DocumentInformation that is null")]
	public void ThenDocumentInformationDataAccessFetchDocumentInformationByIdReturnsADocumentInformationThatIsNull()
	{
		Assert.That(_scenarioContext["Result"], Is.Null);
	}

	[When(@"DocumentInformationDataAccess\.FetchDocumentInformationById is passed a DocumentId ""(.*)"" to fetch ""(.*)""")]
	public async Task WhenDocumentInformationDataAccessFetchDocumentInformationByIdIsPassedADocumentIdToFetch(Guid documentId, string testDocumentLabel)
	{
		var testDocument = _documentInformationContext.GetDocumentInformationByLabel(testDocumentLabel);
		await _dataAccessContext.DocumentInformationDataAccess.StoreDocumentInformation(testDocument);
		var returnDocument = await _dataAccessContext.DocumentInformationDataAccess.FetchDocumentInformationById(documentId);
		_scenarioContext["Result"] = returnDocument!.DocumentId;
	}

	[Then(@"DocumentInformationDataAccess.FetchDocumentInformationById returns a DocumentInformation with id ""(.*)""")]
	public void ThenDocumentInformationDataAccessFetchDocumentInformationByIdReturnsADocumentInformationWithId(Guid documentId)
	{
		Assert.That(_scenarioContext["Result"], Is.EqualTo(documentId));
	}

	[When(@"DocumentInformationDataAccess\.FetchDocumentInformationByName is passed a Name of ""(.*)""")]
	public async Task WhenDocumentInformationDataAccessFetchDocumentInformationByNameIsPassedANameOf(string documentName)
	{
		_scenarioContext["Result"] = await _dataAccessContext.DocumentInformationDataAccess.FetchDocumentInformationByName(documentName);
	}

	[Then(@"DocumentInformationDataAccess.FetchDocumentInformationByName returns a DocumentInformation that is null")]
	public void ThenDocumentInformationDataAccessFetchDocumentInformationByNameReturnsADocumentInformationThatIsNull()
	{
		Assert.That(_scenarioContext["Result"], Is.Null);
	}

	[When(@"DocumentInformationDataAccess\.FetchDocumentInformationByName is passed a Name ""(.*)"" to fetch ""(.*)""")]
	public async Task WhenDocumentInformationDataAccessFetchDocumentInformationByNameIsPassedANameToFetch(string documentName, string testDocumentLabel)
	{
		var testDocument = _documentInformationContext.GetDocumentInformationByLabel(testDocumentLabel);
		await _dataAccessContext.DocumentInformationDataAccess.StoreDocumentInformation(testDocument);
		var returnDocument = await _dataAccessContext.DocumentInformationDataAccess.FetchDocumentInformationByName(documentName);
		_scenarioContext["Result"] = returnDocument!.DocumentName;
	}

	[Then(@"DocumentInformationDataAccess.FetchDocumentInformationByName returns a DocumentInformation with name ""(.*)""")]
	public void ThenDocumentInformationDataAccessFetchDocumentInformationByNameReturnsADocumentInformationWithName(string documentName)
	{
		Assert.That(_scenarioContext["Result"], Is.EqualTo(documentName));
	}
}