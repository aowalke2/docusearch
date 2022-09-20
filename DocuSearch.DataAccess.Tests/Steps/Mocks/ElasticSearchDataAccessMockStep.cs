using Moq;
using DocuSearch.DataAccess.Tests.Context;
using DocuSearch.Entities;

namespace DocuSearch.DataAccess.Tests.Steps.Mocks;

[Binding]
public class ElasticSearchDataAccessMockStep
{
	private readonly DataAccessContext _dataAccessContext;

	public ElasticSearchDataAccessMockStep(DataAccessContext dataAccessContext)
	{
		_dataAccessContext = dataAccessContext;
	}

	[Given(@"ElasticSearchDataAccess\.IndexElasticDocument returns ""(.*)""")]
	public void GivenElasticSearchDataAccessIndexElasticDocumentReturns(bool isIndexed)
	{
		_dataAccessContext.ElasticSearchDataAccessMock.Setup(x => x.IndexElasticDocument(It.IsAny<ElasticDocument>())).ReturnsAsync(isIndexed);
	}

	[Then(@"ElasticSearchDataAccess\.IndexElasticDocument is called once")]
	public void ThenElasticSearchDataAccessIndexElasticDocumentIsCalledOnce()
	{
		_dataAccessContext.ElasticSearchDataAccessMock.Verify(x => x.IndexElasticDocument(It.IsAny<ElasticDocument>()), Times.Once);
	}
}