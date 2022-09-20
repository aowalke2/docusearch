namespace DocuSearch.ValueObjects.Tests.Contexts;

public class DocumentVoContext
{
	private readonly IDictionary<string, DocumentVo> _testDocumentVos = new Dictionary<string, DocumentVo>();

	public void AddDocumentVo(string testDocumentVoLabel, DocumentVo document)
	{
		_testDocumentVos[testDocumentVoLabel] = document;
	}

	public DocumentVo GetDocumentVoByLabel(string testDocumentVoLabel)
	{
		return _testDocumentVos[testDocumentVoLabel];
	}
}