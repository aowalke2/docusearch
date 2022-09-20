using Microsoft.AspNetCore.Http;

namespace DocuSearch.ValueObjects;

public class DocumentVo
{
	public Guid DocumentId { get; set; }
	public string? DocumentName { get; set; }
	public string? ContentType { get; set; }
	public long Size { get; set; }
	public DateTime UploadDate { get; set; }
	public string? Text { get; set; }
	public IFormFile? FormFile { get; set; }
}