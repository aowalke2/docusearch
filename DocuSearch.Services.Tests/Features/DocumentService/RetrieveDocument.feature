Feature: RetrieveDocument
	Describes how a Document is retrieved

@L1
Scenario: Successfully Retrieve a document by Id
	Given a existing DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 99BEC73D-5337-47CA-B64C-73B292CC38A9 |
	| DocumentName | test.txt                             |
	| ContentType  | text/plain                           |
 	When DocumentService.RetrieveDocumentById is passed DocumentId of "99BEC73D-5337-47CA-B64C-73B292CC38A9" to retrieve "test document A"
 	Then DocumentService.RetrieveDocumentById returns a DocumentVo with id "99BEC73D-5337-47CA-B64C-73B292CC38A9"

@L1
Scenario: Unsuccessfully Retrieve a document by Id
 	When DocumentService.RetrieveDocumentById is passed DocumentId "89BEC73D-5337-47CA-B64C-73B292CC38A9"
 	Then DocumentService.RetrieveDocumentById returns is null
 	
@L1
Scenario: Successfully Retrieve a document by Name
	Given a existing DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 99BEC73D-5337-47CA-B64C-73B292CC38A9 |
	| DocumentName | test.txt                             |
	| ContentType  | text/plain                           |
 	When DocumentService.RetrieveDocumentByName is passed DocumentName of "test.txt" to retrieve "test document A"
 	Then DocumentService.RetrieveDocumentByName returns a DocumentVo with name "test.txt"

@L1
Scenario: Unsuccessfully Retrieve a document by Name
 	When DocumentService.RetrieveDocumentByName is passed DocumentName "yoyo.txt"
 	Then DocumentService.RetrieveDocumentByName returns is null