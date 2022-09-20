using Microsoft.AspNetCore.Http;

namespace DocuSearch.Entities;

public class DocumentFile
{
	public string? DocumentName { get; set; }
	public IFormFile? FormFile { get; set; }
}