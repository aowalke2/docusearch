using AutoMapper;
using DocuSearch.DataAccess.Interfaces;
using DocuSearch.Entities;
using DocuSearch.Service.Interfaces;
using DocuSearch.ValueObjects;

namespace DocuSearch.Services;

public class FileStorageService : IFileStorageService
{
	private readonly IFileStorageDataAccess _fileStorageDataAccess;
	private readonly IMapper _mapper;

	public FileStorageService(IFileStorageDataAccess fileStorageDataAccess, IMapper mapper)
	{
		_fileStorageDataAccess = fileStorageDataAccess;
		_mapper = mapper;
	}

	public async Task<bool> AddFileToStore(DocumentVo documentVo)
	{
		var documentFile = _mapper.Map<DocumentFile>(documentVo);
		return await _fileStorageDataAccess.StoreDocumentFile(documentFile);
	}
}