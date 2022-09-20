namespace DocuSearch.Entities.Tests.Context;

public class DocumentFileContext
{
	private readonly IDictionary<string, DocumentFile> _testFile = new Dictionary<string, DocumentFile>();

	public void AddDocumentFile(string testDocumentLabel, DocumentFile documentFile)
	{
		_testFile[testDocumentLabel] = documentFile;
	}
	
	public DocumentFile GetDocumentFileByLabel(string testDocumentLabel)
	{
		return _testFile[testDocumentLabel];
	}
}