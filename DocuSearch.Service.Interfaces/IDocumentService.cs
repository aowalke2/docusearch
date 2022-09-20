using DocuSearch.ValueObjects;

namespace DocuSearch.Service.Interfaces;

public interface IDocumentService
{
	Task<bool> UploadDocument(DocumentVo documentVo);
	Task<DocumentVo?> RetrieveDocumentById(Guid documentId);
	Task<DocumentVo?> RetrieveDocumentByName(string documentName);
}