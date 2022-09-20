using Moq;
using DocuSearch.DataAccess.Tests.Context;
using DocuSearch.Service.Interfaces;

namespace DocuSearch.Services.Tests.Contexts;

public class ServicesContext
{
	private readonly DataAccessContext _dataAccessContext;
	private readonly MapperContext _mapperContext;
	private IJobService? _jobService;
	private IElasticSearchService? _analyzeService;
	private IFileStorageService? _fileStorageService;
	private IDocumentService? _documentService;
	private Mock<IJobService>? _jobServiceMock;
	private Mock<IElasticSearchService>? _analyzeServiceMock;
	private Mock<IDocumentService>? _documentServiceMock;
	private Mock<IFileStorageService>? _fileStorageServiceMock;

	public ServicesContext(DataAccessContext dataAccessContext, MapperContext mapperContext)
	{
		_dataAccessContext = dataAccessContext;
		_mapperContext = mapperContext;
	}

	public IJobService JobService
	{
		get => _jobService ??= _jobServiceMock?.Object ?? new JobService();
		set => _jobService = value;
	}

	public Mock<IJobService> JobServiceMock
	{
		get => _jobServiceMock ??= new Mock<IJobService>();
		set => _jobServiceMock = value;
	}

	public IElasticSearchService ElasticSearchService
	{
		get => _analyzeService ??= _analyzeServiceMock?.Object ?? new ElasticSearchService(_dataAccessContext.ElasticSearchDataAccessMock.Object, _mapperContext.Mapper);
		set => _analyzeService = value;
	}

	public Mock<IElasticSearchService> ElasticSearchServiceMock
	{
		get => _analyzeServiceMock ??= new Mock<IElasticSearchService>(); 
		set => _analyzeServiceMock = value;
	}
	
	public IFileStorageService FileStorageService
	{
		get => _fileStorageService ??= _fileStorageServiceMock?.Object ?? new FileStorageService(_dataAccessContext.FileStorageDataAccess, _mapperContext.Mapper); 
		set => _fileStorageService = value;
	}

	public Mock<IFileStorageService> FileStorageServiceMock
	{
		get => _fileStorageServiceMock ??= new Mock<IFileStorageService>(); 
		set => _fileStorageServiceMock = value;
	}

	public IDocumentService DocumentService
	{
		get => _documentService ??= _documentServiceMock?.Object ?? new DocumentService(
			_dataAccessContext.DocumentInformationDataAccess, JobService, ElasticSearchService, FileStorageService, _mapperContext.Mapper);
		set => _documentService = value;
	}

	public Mock<IDocumentService> DocumentServiceMock
	{
		get => _documentServiceMock ??= new Mock<IDocumentService>();
		set => _documentServiceMock = value;
	}
}