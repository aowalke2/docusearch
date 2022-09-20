using Moq;
using DocuSearch.Services.Tests.Contexts;
using DocuSearch.Utility.Exceptions.DataAccessExceptions;
using DocuSearch.ValueObjects;
using DocuSearch.ValueObjects.Tests.Contexts;

namespace DocuSearch.Services.Tests.Steps.Mocks;

[Binding]
public class ElasticSearchServiceMockStep
{
	private readonly ServicesContext _servicesContext;
	private readonly DocumentVoContext _documentVoContext;

	public ElasticSearchServiceMockStep(ServicesContext servicesContext, DocumentVoContext documentVoContext)
	{
		_servicesContext = servicesContext;
		_documentVoContext = documentVoContext;
	}

	[Given(@"ElasticSearchService\.AddDocumentToIndex returns ""(.*)""")]
	public void GivenElasticSearchServiceAddDocumentToIndexReturns(bool isIndexed)
	{
		_servicesContext.ElasticSearchServiceMock.Setup(x => x.AddDocumentToIndex(It.IsAny<DocumentVo>())).ReturnsAsync(isIndexed);
	}

	[Then(@"ElasticSearchService\.AddDocumentToIndex is called once")]
	public void ThenElasticSearchServiceAddDocumentToIndexIsCalledOnce()
	{
		_servicesContext.ElasticSearchServiceMock.Verify(x => x.AddDocumentToIndex(It.IsAny<DocumentVo>()), Times.Once);
	}

	[Then(@"ElasticSearchService\.AddDocumentToIndex is never called")]
	public void ThenElasticSearchServiceAddDocumentToIndexIsNeverCalled()
	{
		_servicesContext.ElasticSearchServiceMock.Verify(x => x.AddDocumentToIndex(It.IsAny<DocumentVo>()), Times.Never);
	}

	[When(@"ElasticSearchService\.AddDocumentToIndex throws an DataAccessStoreFailureException")]
	public void WhenElasticSearchServiceAddDocumentToIndexThrowsAnDataAccessStoreFailureException()
	{
		_servicesContext.ElasticSearchServiceMock.Setup(x => x.AddDocumentToIndex(It.IsAny<DocumentVo>())).Throws<DataAccessStoreFailureException>();
	}
}