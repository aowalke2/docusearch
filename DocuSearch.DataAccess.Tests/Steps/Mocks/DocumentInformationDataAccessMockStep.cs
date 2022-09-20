using Moq;
using DocuSearch.DataAccess.Tests.Context;
using DocuSearch.Entities;
using DocuSearch.Utility.Exceptions.DataAccessExceptions;

namespace DocuSearch.DataAccess.Tests.Steps.Mocks;

[Binding]
public class DocumentInformationDataAccessMockStep
{
	private readonly DataAccessContext _dataAccessContext;
	
	public DocumentInformationDataAccessMockStep(DataAccessContext dataAccessContext)
	{
		_dataAccessContext = dataAccessContext;
	}

	[Given(@"DocumentInformationDataAccess\.StoreDocumentInformation returns ""(.*)""")]
	public void GivenDocumentInformationDataAccessStoreDocumentInformationReturns(bool isStored)
	{
		_dataAccessContext.DocumentInformationDataAccessMock.Setup(x => x.StoreDocumentInformation(It.IsAny<DocumentInformation>())).ReturnsAsync(isStored);
	}

	[Then(@"DocumentInformationDataAccess\.StoreDocumentInformation is called once")]
	public void ThenDocumentDataAccessStoreDocumentInformationIsCalledOnce()
	{
		_dataAccessContext.DocumentInformationDataAccessMock.Verify(x => x.StoreDocumentInformation(It.IsAny<DocumentInformation>()), Times.Once);
	}

	[Then(@"DocumentInformationDataAccess\.StoreDocumentInformation is never called")]
	public void ThenDocumentInformationDataAccessStoreDocumentInformationIsNeverCalled()
	{
		_dataAccessContext.DocumentInformationDataAccessMock.Verify(x => x.StoreDocumentInformation(It.IsAny<DocumentInformation>()), Times.Never);
	}

	[When(@"DocumentInformationDataAccess\.StoreDocumentInformation throws a DataAccessStoreFailureException")]
	public void WhenDocumentInformationDataAccessStoreDocumentInformationThrowsADataAccessStoreFailureException()
	{
		_dataAccessContext.DocumentInformationDataAccessMock.Setup(x => x.StoreDocumentInformation(It.IsAny<DocumentInformation>())).Throws<DataAccessStoreFailureException>();
	}
}