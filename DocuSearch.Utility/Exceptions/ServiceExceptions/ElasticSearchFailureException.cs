namespace DocuSearch.Utility.Exceptions.ServiceExceptions;

public class ElasticSearchFailureException : Exception
{
	public ElasticSearchFailureException()
	{
	}

	public ElasticSearchFailureException(string message) : base(message)
	{
	}

	public ElasticSearchFailureException(string message, Exception inner) : base(message, inner)
	{
	}
}