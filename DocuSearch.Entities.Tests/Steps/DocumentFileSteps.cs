using TechTalk.SpecFlow.Assist;
using DocuSearch.Entities.Tests.Context;

namespace DocuSearch.Entities.Tests.Steps;

[Binding]
public class FileSteps
{
	private readonly DocumentFileContext _documentFileContext;

	public FileSteps(DocumentFileContext documentFileContext)
	{
		_documentFileContext = documentFileContext;
	}

	[Given(@"a new DocumentFile labeled ""(.*)"" with the values:")]
	public void GivenANewFileLabeledWithTheValues(string testDocumentLabel, Table table)
	{
		var documentFile = table.CreateInstance<DocumentFile>();
		_documentFileContext.AddDocumentFile(testDocumentLabel, documentFile);
	}
}