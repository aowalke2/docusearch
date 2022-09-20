using Moq;
using DocuSearch.Services.Tests.Contexts;
using DocuSearch.Utility.Enumerators;
using DocuSearch.ValueObjects;

namespace DocuSearch.Services.Tests.Steps.Mocks;

[Binding]
public class JobServiceMockStep
{
	private readonly ServicesContext _servicesContext;

	public JobServiceMockStep(ServicesContext servicesContext)
	{
		_servicesContext = servicesContext;
	}

	[Given(@"JobService\.ProcessJob is mocked to return ""(.*)""")]
	public void GivenJobServiceProcessJobIsMockedToReturn(JobStatus jobStatus)
	{
		_servicesContext.JobServiceMock.Setup(x => x.ProcessJob(It.IsAny<JobVo>())).Returns(jobStatus);
	}

	[Then(@"JobService\.ProcessJob is called once")]
	public void ThenJobServiceProcessJobIsCalledOnce()
	{
		_servicesContext.JobServiceMock.Verify(x => x.ProcessJob(It.IsAny<JobVo>()), Times.Once);
	}

	[Then(@"JobService\.ProcessJob is not called")]
	public void ThenJobServiceProcessJobIsNotCalled()
	{
		_servicesContext.JobServiceMock.Verify(x => x.ProcessJob(It.IsAny<JobVo>()), Times.Never);
	}
}