namespace DocuSearch.Entities;

public class DocumentInformation
{
	public Guid? DocumentId { get; set; }
	public string DocumentName { get; set; }
	public string ContentType { get; set; }
	public string Size { get; set; }
	public DateTime UploadDate { get; set; }
}