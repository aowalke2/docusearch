using DocuSearch.Entities;

namespace DocuSearch.DataAccess.Interfaces;

public interface IFileStorageDataAccess
{
	Task<bool> StoreDocumentFile(DocumentFile documentFile);
}