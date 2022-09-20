namespace DocuSearch.Utility.BuiltInTypeExtensions;

public static class GuidTypeExtension
{
	public static bool IsNullOrEmpty(this Guid? guid)
	{
		return guid == null || guid == Guid.Empty;
	}
}