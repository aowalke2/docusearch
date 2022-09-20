using Moq;
using Nest;
using DocuSearch.DataAccess.InMemory;
using DocuSearch.DataAccess.Interfaces;
using DocuSearch.Entities;

namespace DocuSearch.DataAccess.Tests.Context;

public class DataAccessContext
{
	private IDocumentInformationDataAccess? _documentInformationDataAccess;
	private IElasticSearchDataAccess? _elasticSearchDataAccess;
	private IFileStorageDataAccess? _fileStorageDataAccess;
	private Mock<IDocumentInformationDataAccess>? _documentInformationDataAccessMock;
	private Mock<IElasticSearchDataAccess>? _elasticSearchDataAccessMock;
	private Mock<IFileStorageDataAccess>? _fileStorageDataAccessMock;

	public IDocumentInformationDataAccess DocumentInformationDataAccess
	{
		get => _documentInformationDataAccess ??= _documentInformationDataAccessMock?.Object ?? new InMemoryDocumentInformationDataAccess();
		set => _documentInformationDataAccess = value;
	}

	public Mock<IDocumentInformationDataAccess> DocumentInformationDataAccessMock
	{
		get => _documentInformationDataAccessMock ??= new Mock<IDocumentInformationDataAccess>();
		set => _documentInformationDataAccessMock = value;
	}
	
	// public IElasticSearchDataAccess ElasticSearchDataAccess
	// {
	// 	get => _elasticSearchDataAccess ??= _elasticSearchDataAccessMock?.Object ?? new ElasticSearchDataAccess(new ElasticClient(new Uri("http://localhost:9200")));
	// 	set => _elasticSearchDataAccess = value;
	// }

	public Mock<IElasticSearchDataAccess> ElasticSearchDataAccessMock
	{
		get => _elasticSearchDataAccessMock ??= new Mock<IElasticSearchDataAccess>();
		set => _elasticSearchDataAccessMock = value;
	}

	public IFileStorageDataAccess FileStorageDataAccess
	{
		get => _fileStorageDataAccess ??= _fileStorageDataAccessMock?.Object ?? new LocalFileStorageDataAccess();
		set => _fileStorageDataAccess = value;
	}

	public Mock<IFileStorageDataAccess> FileStorageDataAccessMock
	{
		get => _fileStorageDataAccessMock ??= new Mock<IFileStorageDataAccess>();
		set => _fileStorageDataAccessMock = value;
	}
}