using DocuSearch.ValueObjects;

namespace DocuSearch.Service.Interfaces;

public interface IFileStorageService
{
	Task<bool> AddFileToStore(DocumentVo documentVo);
}