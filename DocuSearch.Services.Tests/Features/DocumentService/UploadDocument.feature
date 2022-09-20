Feature: UploadDocument
	Describes how a Document is uploaded

@L1
Scenario: Successfully Upload a document
	Given a new DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 43563E49-2500-4A4C-9385-D25A2E18C513 |
	| DocumentName | test.txt                             |
	| ContentType  | text/plain                           |
 	And ElasticSearchService.AddDocumentToIndex returns "true"
 	And FileStorageService.AddFileToStore returns "true"
 	And DocumentInformationDataAccess.StoreDocumentInformation returns "true"
 	When DocumentService.UploadDocument is passed DocumentVo labeled "test document A"
 	Then ElasticSearchService.AddDocumentToIndex is called once
 	And FileStorageService.AddFileToStore is called once
 	And DocumentInformationDataAccess.StoreDocumentInformation is called once
 	And DocumentService.UploadDocument returns "true"
	
@L1
Scenario: Unsuccessfully Upload a document with wrong content type
	Given a new DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 43563E49-2500-4A4C-9385-D25A2E18C513 |
	| DocumentName | test.pdf                             |
	| ContentType  | application/pdf                      |
	When DocumentService.UploadDocument is passed DocumentVo labeled "test document A"
	Then ElasticSearchService.AddDocumentToIndex is never called
	And FileStorageService.AddFileToStore is never called
	And DocumentInformationDataAccess.StoreDocumentInformation is never called
	And DocumentService.UploadDocument returns "false"
	
@L1
Scenario: Unsuccessfully Upload a document if it cannot be analyzed
	Given a new DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 43563E49-2500-4A4C-9385-D25A2E18C513 |
	| DocumentName | test.txt                             |
	| ContentType  | text/plain                           |
 	When ElasticSearchService.AddDocumentToIndex throws an DataAccessStoreFailureException
 	Then DocumentService.UploadDocument throws an DataAccessStoreFailureException from being passed "test document A"
 	And ElasticSearchService.AddDocumentToIndex is called once
	And FileStorageService.AddFileToStore is never called
	And DocumentInformationDataAccess.StoreDocumentInformation is never called

@L1
Scenario: Unsuccessfully Upload a document if it file cannot be stored
	Given a new DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 43563E49-2500-4A4C-9385-D25A2E18C513 |
	| DocumentName | test.txt                             |
	| ContentType  | text/plain                           |
 	When FileStorageService.AddFileToStore throws an FileStorageFailureException
 	Then DocumentService.UploadDocument throws an FileStorageFailureException from being passed "test document A"
 	And ElasticSearchService.AddDocumentToIndex is never called
	And FileStorageService.AddFileToStore is called once 
	And DocumentInformationDataAccess.StoreDocumentInformation is never called

@L1
Scenario: Unsuccessfully Upload a document if document information cannot be stored
	Given a new DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 43563E49-2500-4A4C-9385-D25A2E18C513 |
	| DocumentName | test.txt                             |
	| ContentType  | text/plain                           |
 	When DocumentInformationDataAccess.StoreDocumentInformation throws a DataAccessStoreFailureException
 	Then DocumentService.UploadDocument throws an DataAccessStoreFailureException from being passed "test document A"
 	And ElasticSearchService.AddDocumentToIndex is never called
	And FileStorageService.AddFileToStore is never called 
	And DocumentInformationDataAccess.StoreDocumentInformation is called once			 