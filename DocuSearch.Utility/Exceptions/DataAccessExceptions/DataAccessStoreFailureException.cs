namespace DocuSearch.Utility.Exceptions.DataAccessExceptions;

public class DataAccessStoreFailureException : Exception
{
	public DataAccessStoreFailureException()
	{
	}

	public DataAccessStoreFailureException(string message) : base(message)
	{
	}

	public DataAccessStoreFailureException(string message, Exception inner) : base(message, inner)
	{
	}
}