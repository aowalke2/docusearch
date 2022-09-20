Feature: StoreDocumentFile
	Describes how a file is stored in the file store

@L2
Scenario: Add document to file store
	Given a new DocumentFile labeled "test document A" with the values:
	| Field        | Value    |
	| DocumentName | test.txt |
	When FileStorageDataAccess.StoreDocumentFile is passed File labeled "test document A"
	Then FileStorageDataAccess.StoreDocumentFile returns "true"
	
#Add step to check for duplicates