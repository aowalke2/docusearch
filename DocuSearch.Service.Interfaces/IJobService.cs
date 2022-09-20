using DocuSearch.Utility.Enumerators;
using DocuSearch.ValueObjects;

namespace DocuSearch.Service.Interfaces;

public interface IJobService
{
	JobStatus ProcessJob(JobVo jobVo);
}