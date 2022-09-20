using DocuSearch.DataAccess.Interfaces;
using DocuSearch.Entities;

namespace DocuSearch.DataAccess.InMemory;

public class LocalFileStorageDataAccess : IFileStorageDataAccess
{
	public async Task<bool> StoreDocumentFile(DocumentFile documentFile)
	{
		try
		{
			var homePath = Environment.GetEnvironmentVariable("HOMEPATH");
			string path = Path.Combine(homePath!, "Documents\\UploadedFiles", documentFile.DocumentName!);
			using (Stream stream = new FileStream(path, FileMode.Create))
			{
				await documentFile.FormFile!.CopyToAsync(stream);
			}
			return true;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return false;
		}

	}
}