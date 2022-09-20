using NUnit.Framework;
using DocuSearch.DataAccess.Tests.Context;
using DocuSearch.Entities.Tests.Context;

namespace DocuSearch.DataAccess.Tests.Steps.DocumentInformationDataAccess;

[Binding]
public class StoreDocumentInformationStep
{
	private readonly DocumentInformationContext _documentInformationContext;
	private readonly DataAccessContext _dataAccessContext;
	private readonly ScenarioContext _scenarioContext;

	public StoreDocumentInformationStep(DocumentInformationContext documentInformationContext, DataAccessContext dataAccessContext, ScenarioContext scenarioContext)
	{
		_documentInformationContext = documentInformationContext;
		_dataAccessContext = dataAccessContext;
		_scenarioContext = scenarioContext;
	}

	[When(@"DocumentInformationDataAccess\.StoreDocumentInformation is passed DocumentInformation labeled ""(.*)""")]
	public async Task WhenDocumentInformationDataAccessStoreDocumentInformationIsPassedDocumentInformationLabeled(string testDocumentLabel)
	{
		var document = _documentInformationContext.GetDocumentInformationByLabel(testDocumentLabel);
		_scenarioContext["Result"] = await _dataAccessContext.DocumentInformationDataAccess.StoreDocumentInformation(document);
	}


	[When(@"DocumentInformationDataAccess\.StoreDocumentInformation is passed two DocumentInformation labeled ""(.*)"", ""(.*)""")]
	public async Task WhenDocumentInformationDataAccessStoreDocumentInformationIsPassedTwoDocumentInformationLabeled(string testDocumentALabel, string testDocumentBLabel)
	{
		var documentA = _documentInformationContext.GetDocumentInformationByLabel(testDocumentALabel);
		await _dataAccessContext.DocumentInformationDataAccess.StoreDocumentInformation(documentA);
		var documentB = _documentInformationContext.GetDocumentInformationByLabel(testDocumentBLabel);
		_scenarioContext["Result"] = await _dataAccessContext.DocumentInformationDataAccess.StoreDocumentInformation(documentB);
	}

	[Then(@"DocumentInformationDataAccess\.StoreDocumentInformation returns ""(.*)""")]
	public void ThenDocumentInformationDataAccessStoreDocumentInformationReturns(bool isStored)
	{
		Assert.That(_scenarioContext["Result"], Is.EqualTo(isStored));
	}
}