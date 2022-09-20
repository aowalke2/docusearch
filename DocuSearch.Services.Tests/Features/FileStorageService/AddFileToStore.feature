Feature: AddFileToStore
	Describes how a file is stored in the file store

@L1
Scenario: Successfully add document to file storage
	Given a new DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 66E40341-CA70-44B4-8D50-40A5D3AFCC96 |
	| DocumentName | test.txt                             |
	| ContentType  | text/plain                           |
	| Text         | I am some text for the elastic index |
	And FileStorageDataAccess.StoreDocumentFile returns "true"
	When FileStorageService.AddFileToStore is passed documentVo labeled "test document A"
	Then FileStorageDataAccess.StoreDocumentFile is called once
	And FileStorageService.AddFileToStore returns "true"
	
@L1
Scenario: Unsuccessfully add document to file storage
	Given a new DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 66E40341-CA70-44B4-8D50-40A5D3AFCC96 |
	| DocumentName | test.txt                             |
	| ContentType  | text/plain                           |
	| Text         | I am some text for the elastic index |
	And FileStorageDataAccess.StoreDocumentFile returns "false"
	When FileStorageService.AddFileToStore is passed documentVo labeled "test document A"
	Then FileStorageDataAccess.StoreDocumentFile is called once
	And FileStorageService.AddFileToStore returns "false"