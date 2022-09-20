using DocuSearch.DataAccess.Interfaces;
using DocuSearch.Entities;
using DocuSearch.Utility.BuiltInTypeExtensions;

namespace DocuSearch.DataAccess.InMemory;

public class InMemoryDocumentInformationDataAccess : IDocumentInformationDataAccess
{
	private readonly IDictionary<Guid, DocumentInformation?> _documents = new Dictionary<Guid, DocumentInformation?>();
	private readonly IDictionary<string, Guid> _documentIndex = new Dictionary<string, Guid>(); 
	public async Task<bool> StoreDocumentInformation(DocumentInformation documentInformation)
	{
		if (documentInformation.DocumentId.IsNullOrEmpty() || string.IsNullOrEmpty(documentInformation.DocumentName))
		{
			return await Task.FromResult(false);
		}
		
		if (_documents.ContainsKey(documentInformation.DocumentId!.Value) || _documentIndex.ContainsKey(documentInformation.DocumentName))
		{
			return await Task.FromResult(false);
		}
		
		_documents[documentInformation.DocumentId!.Value] = documentInformation;
		_documentIndex[documentInformation.DocumentName] = documentInformation.DocumentId!.Value;
		return await Task.FromResult(true);
	}

	public async Task<DocumentInformation?> FetchDocumentInformationById(Guid documentId)
	{
		if (!_documents.ContainsKey(documentId))
		{
			return await Task.FromResult<DocumentInformation?>(null);
		}
		return await Task.FromResult(_documents[documentId]);
	}

	public async Task<DocumentInformation?> FetchDocumentInformationByName(string documentName)
	{
		if (!_documentIndex.ContainsKey(documentName))
		{
			return await Task.FromResult<DocumentInformation?>(null);
		}
		return await Task.FromResult(_documents[_documentIndex[documentName]]);
	}
}