using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace DocuSearch.Utility.DummyObjects;

public class DummyFormFile
{
	public IFormFile GetDummyFormFile(string documentName, string content = "I am a dummy form file")
	{
		var stream = new MemoryStream();
		var writer = new StreamWriter(stream);
		writer.WriteAsync(content);
		writer.FlushAsync();
		stream.Position = 0;
		return new FormFile(stream, 0, stream.Length, "id_from_form", documentName);
	}
}