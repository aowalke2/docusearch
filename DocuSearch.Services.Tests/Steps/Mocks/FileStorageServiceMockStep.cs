using Moq;
using DocuSearch.Services.Tests.Contexts;
using DocuSearch.Utility.Exceptions.ServiceExceptions;
using DocuSearch.ValueObjects;

namespace DocuSearch.Services.Tests.Steps.Mocks;

[Binding]
public class FileStorageServiceMockStep
{
	private readonly ServicesContext _servicesContext;

	public FileStorageServiceMockStep(ServicesContext servicesContext)
	{
		_servicesContext = servicesContext;
	}

	[Given(@"FileStorageService\.AddFileToStore returns ""(.*)""")]
	public void GivenFileStorageServiceAddFileToStoreReturns(bool isFileStored)
	{
		_servicesContext.FileStorageServiceMock.Setup(x => x.AddFileToStore(It.IsAny<DocumentVo>())).ReturnsAsync(isFileStored);
	}

	[When(@"FileStorageService\.AddFileToStore throws an FileStorageFailureException")]
	public void WhenFileStorageServiceAddFileToStoreThrowsAnFileStorageFailureException()
	{
		_servicesContext.FileStorageServiceMock.Setup(x => x.AddFileToStore(It.IsAny<DocumentVo>())).Throws<FileStorageFailureException>();
	}

	[Then(@"FileStorageService\.AddFileToStore is called once")]
	public void ThenFileStorageServiceAddFileToStoreIsCalledOnce()
	{
		_servicesContext.FileStorageServiceMock.Verify(x => x.AddFileToStore(It.IsAny<DocumentVo>()), Times.Once);
	}

	[Then(@"FileStorageService\.AddFileToStore is never called")]
	public void ThenFileStorageServiceAddFileToStoreIsNeverCalled()
	{
		_servicesContext.FileStorageServiceMock.Verify(x => x.AddFileToStore(It.IsAny<DocumentVo>()), Times.Never);
	}
}