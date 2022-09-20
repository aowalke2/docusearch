using Nest;

namespace DocuSearch.Entities;

public class ElasticDocument
{
	public string? DocumentName { get; set; }
	
	[Text(Ignore = true)]
	public string? Text { get; set; }
	
	public IEnumerable<string>? Tokens { get; set; }
}