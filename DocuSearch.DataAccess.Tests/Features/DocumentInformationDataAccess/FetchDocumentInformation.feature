Feature: FetchDocumentInformation
	Describes fetching a document's information by its ID or document name

@L2
Scenario: Fetch document information with Id that does not exist
	When DocumentInformationDataAccess.FetchDocumentInformationById is passed a DocumentId of "C5487DCE-4371-499D-B198-1174314E1E85"
	Then DocumentInformationDataAccess.FetchDocumentInformationById returns a DocumentInformation that is null
	
@L2
Scenario: Fetch document informatiion with existing document Id
	Given an existing DocumentInformation labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 4096C9FE-1901-4585-9E44-5421DB0D0BD3 |
	| DocumentName | jay.electronica.txt                  |
	When DocumentInformationDataAccess.FetchDocumentInformationById is passed a DocumentId "4096C9FE-1901-4585-9E44-5421DB0D0BD3" to fetch "test document A"
	Then DocumentInformationDataAccess.FetchDocumentInformationById returns a DocumentInformation with id "4096C9FE-1901-4585-9E44-5421DB0D0BD3"
	
@L2
Scenario: Fetch document information with name that does not exist
	When DocumentInformationDataAccess.FetchDocumentInformationByName is passed a Name of "jay.electronica.txt"
	Then DocumentInformationDataAccess.FetchDocumentInformationByName returns a DocumentInformation that is null
	
@L2
Scenario: Fetch document information with existing document name
	Given an existing DocumentInformation labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 4096C9FE-1901-4585-9E44-5421DB0D0BD3 |
	| DocumentName | jay.electronica.txt                  |
	When DocumentInformationDataAccess.FetchDocumentInformationByName is passed a Name "jay.electronica.txt" to fetch "test document A"
	Then DocumentInformationDataAccess.FetchDocumentInformationByName returns a DocumentInformation with name "jay.electronica.txt"