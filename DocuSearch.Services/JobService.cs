using DocuSearch.Service.Interfaces;
using DocuSearch.Utility.Enumerators;
using DocuSearch.ValueObjects;

namespace DocuSearch.Services;

public class JobService : IJobService
{
	public JobStatus ProcessJob(JobVo jobVo)
	{
		return JobStatus.None;
	}
}