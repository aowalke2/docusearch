using AutoMapper;
using DocuSearch.UI.Models;
using Microsoft.AspNetCore.Mvc;
using DocuSearch.Service.Interfaces;
using DocuSearch.ValueObjects;

namespace DocuSearch.UI.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class DocumentController : ControllerBase
{
	private readonly IDocumentService _documentService;
	private readonly IMapper _mapper;
	private readonly LinkGenerator _linkGenerator;

	public DocumentController(IDocumentService documentService, IMapper mapper, LinkGenerator linkGenerator)
	{
		_documentService = documentService;
		_mapper = mapper;
		_linkGenerator = linkGenerator;
	}
	
	[HttpGet("{documentId:guid}")]
	public async Task<ActionResult<DocumentVo>> RetrieveById(Guid documentId)
	{
		try
		{
			var documentVo = await _documentService.RetrieveDocumentById(documentId);
			if (documentVo == null) return NotFound();
			return documentVo;
		}
		catch
		{
			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}
	
	[HttpGet("{documentName}")]
	public async Task<ActionResult<DocumentVo>> RetrieveByName(string documentName)
	{
		try
		{
			var documentVo = await _documentService.RetrieveDocumentByName(documentName);
			if (documentVo == null) return NotFound();
			return documentVo;
		}
		catch
		{
			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}

	[HttpPost]
	public async Task<ActionResult<DocumentModel>> Upload([FromForm] DocumentModel documentModel)
	{
		var documentVo = _mapper.Map<DocumentVo>(documentModel);
		try
		{
			var existingDocument = await _documentService.RetrieveDocumentByName(documentVo.DocumentName!);
			if (existingDocument != null)
			{
				return BadRequest("DocumentInformation with name exists");
			}
			
			var location = _linkGenerator.GetPathByAction("RetrieveByName", "Document", new {documentId = documentVo.DocumentId});
			if (string.IsNullOrWhiteSpace(location))
			{
				return BadRequest("Could not use current DocumentId");
			}

			bool isUploaded = await _documentService.UploadDocument(documentVo);
			if (isUploaded)
			{
				return Created(location, documentVo);
			}

			return BadRequest("DocumentInformation does not have supported type");
		}
		catch
		{
			return StatusCode(StatusCodes.Status500InternalServerError);
		}
	}
}