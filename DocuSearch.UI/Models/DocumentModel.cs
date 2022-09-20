using DocuSearch.Utility.BuiltInTypeExtensions;

namespace DocuSearch.UI.Models;

public class DocumentModel
{
	private Guid? _documentId;
	
	public Guid? DocumentId
	{
		get
		{
			if(_documentId.IsNullOrEmpty()) _documentId = Guid.NewGuid();
			return _documentId;
		}
		set => _documentId = value;
	} 
	public string? DocumentName { get; set; }
	public string? ContentType { get; set; }
	public long Size { get; set; }
	public DateTime UploadDate => DateTime.Now;
	public IFormFile? FormFile { get; set; }
}