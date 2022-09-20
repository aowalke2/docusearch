namespace DocuSearch.Entities.Tests.Context;

public class DocumentInformationContext
{
	private readonly IDictionary<string, DocumentInformation> _testDocuments = new Dictionary<string, DocumentInformation>();

	public void AddDocumentInformation(string testDocumentLabel, DocumentInformation documentInformation)
	{
		_testDocuments[testDocumentLabel] = documentInformation;
	}

	public DocumentInformation GetDocumentInformationByLabel(string testDocumentLabel)
	{
		return _testDocuments[testDocumentLabel];
	}
}