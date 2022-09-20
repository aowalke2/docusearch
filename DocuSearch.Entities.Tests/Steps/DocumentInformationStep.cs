using TechTalk.SpecFlow.Assist;
using DocuSearch.Entities.Tests.Context;

namespace DocuSearch.Entities.Tests.Steps;

[Binding]
public class DocumentInformationStep
{
	private readonly DocumentInformationContext _documentInformationContext;

	public DocumentInformationStep(DocumentInformationContext documentInformationContext)
	{
		_documentInformationContext = documentInformationContext;
	}

	[Given(@"a new DocumentInformation labeled ""(.*)"" with the values:")]
	public void GivenANewDocumentLabeledWithTheValues(string testDocumentLabel, Table table)
	{
		var documentInformation = table.CreateInstance<DocumentInformation>();
		_documentInformationContext.AddDocumentInformation(testDocumentLabel, documentInformation);
	}

	[Given(@"an existing DocumentInformation labeled ""(.*)"" with the values:")]
	public void GivenAnExistingDocumentLabeledWithTheValues(string testDocumentLabel, Table table)
	{
		var documentInformation = table.CreateInstance<DocumentInformation>();
		_documentInformationContext.AddDocumentInformation(testDocumentLabel, documentInformation);
	}
}