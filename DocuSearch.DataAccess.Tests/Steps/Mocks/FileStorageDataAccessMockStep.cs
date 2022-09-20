using Moq;
using DocuSearch.DataAccess.Tests.Context;
using DocuSearch.Entities;

namespace DocuSearch.DataAccess.Tests.Steps.Mocks;

[Binding]
public class FileStorageDataAccessMockStep
{
	private readonly DataAccessContext _dataAccessContext;

	public FileStorageDataAccessMockStep(DataAccessContext dataAccessContext)
	{
		_dataAccessContext = dataAccessContext;
	}

	[Given(@"FileStorageDataAccess\.StoreDocumentFile returns ""(.*)""")]
	public void GivenFileStorageDataAccessStoreDocumentFileReturns(bool isStored)
	{
		_dataAccessContext.FileStorageDataAccessMock.Setup(x => x.StoreDocumentFile(It.IsAny<DocumentFile>())).ReturnsAsync(isStored);
	}

	[Then(@"FileStorageDataAccess\.StoreDocumentFile is called once")]
	public void ThenFileStorageDataAccessStoreDocumentFileIsCalledOnce()
	{
		_dataAccessContext.FileStorageDataAccessMock.Verify(x => x.StoreDocumentFile(It.IsAny<DocumentFile>()), Times.Once);
	}
}