namespace DocuSearch.Utility.Exceptions.ServiceExceptions;

public class FileStorageFailureException : Exception
{
	public FileStorageFailureException()
	{
	}

	public FileStorageFailureException(string message) : base(message)
	{
	}

	public FileStorageFailureException(string message, Exception inner) : base(message, inner)
	{
	}
}