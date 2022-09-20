using AutoMapper;
using DocuSearch.DataAccess.Interfaces;
using DocuSearch.Entities;
using DocuSearch.Service.Interfaces;
using DocuSearch.ValueObjects;

namespace DocuSearch.Services;

public class DocumentService : IDocumentService
{
	private readonly IDocumentInformationDataAccess _documentInformationDataAccess;
	private readonly IJobService _jobService;
	private readonly IElasticSearchService _elasticSearchService;
	private readonly IFileStorageService _fileStorageService;
	private readonly IMapper _mapper;

	public DocumentService(
		IDocumentInformationDataAccess documentInformationDataAccess, 
		IJobService jobService, 
		IElasticSearchService elasticSearchService,
		IFileStorageService fileStorageService,
		IMapper mapper)
	{
		_documentInformationDataAccess = documentInformationDataAccess;
		_jobService = jobService;
		_mapper = mapper;
		_fileStorageService = fileStorageService;
		_elasticSearchService = elasticSearchService;
	}

	public async Task<bool> UploadDocument(DocumentVo documentVo)
	{
		bool isUploaded = false;
		try
		{
			if (!documentVo.ContentType!.Equals("text/plain")) //will need to change this for more file types
			{
				return await Task.FromResult(isUploaded);
			}

			var isIndexed = await _elasticSearchService.AddDocumentToIndex(documentVo);
			var isStored = await _fileStorageService.AddFileToStore(documentVo);
			
			var documentInformation = _mapper.Map<DocumentInformation>(documentVo);
			isUploaded = await _documentInformationDataAccess.StoreDocumentInformation(documentInformation);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			//TODO log this error
			throw;
		}

		return await Task.FromResult(isUploaded);
	}

	public async Task<DocumentVo?> RetrieveDocumentById(Guid documentId)
	{
		DocumentInformation? documentInformation = await _documentInformationDataAccess.FetchDocumentInformationById(documentId);
		if (documentInformation == null)
		{
			return await Task.FromResult<DocumentVo?>(null);
		}
		return await Task.FromResult(_mapper.Map<DocumentVo>(documentInformation));
	}

	public async Task<DocumentVo?> RetrieveDocumentByName(string documentName)
	{
		DocumentInformation? documentInformation = await _documentInformationDataAccess.FetchDocumentInformationByName(documentName);
		if (documentInformation == null)
		{
			return await Task.FromResult<DocumentVo?>(null);
		}
		return await Task.FromResult(_mapper.Map<DocumentVo>(documentInformation));
	}
}