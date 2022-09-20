using TechTalk.SpecFlow.Assist;
using DocuSearch.ValueObjects.Tests.Contexts;

namespace DocuSearch.ValueObjects.Tests.Steps;

[Binding]
public class DocumentVoStep
{
	private readonly DocumentVoContext _documentVoContext;

	public DocumentVoStep(DocumentVoContext documentVoContext)
	{
		_documentVoContext = documentVoContext;
	}

	[Given(@"a new DocumentVo labeled ""(.*)"" with the values:")]
	public void GivenANewDocumentVoLabeledWithTheValues(string testDocumentVoLabel, Table table)
	{
		var fileVo = table.CreateInstance<DocumentVo>();
		_documentVoContext.AddDocumentVo(testDocumentVoLabel, fileVo);
	}

	[Given(@"a existing DocumentVo labeled ""(.*)"" with the values:")]
	public void GivenAExistingDocumentVoLabeledWithTheValues(string testDocumentVoLabel, Table table)
	{
		var fileVo = table.CreateInstance<DocumentVo>();
		_documentVoContext.AddDocumentVo(testDocumentVoLabel, fileVo);
	}
}