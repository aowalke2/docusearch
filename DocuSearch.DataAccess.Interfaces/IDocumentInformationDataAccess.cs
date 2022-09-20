using DocuSearch.Entities;

namespace DocuSearch.DataAccess.Interfaces;

public interface IDocumentInformationDataAccess
{
	Task<bool> StoreDocumentInformation(DocumentInformation documentInformation);
	Task<DocumentInformation?> FetchDocumentInformationById(Guid documentId);
	Task<DocumentInformation?> FetchDocumentInformationByName(string documentName);
}