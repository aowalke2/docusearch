Feature: StoreDocumentInformation
	Describes storing a document's information

@L2
Scenario: Save a document information without id
	Given a new DocumentInformation labeled "test document A" with the values:
	| Field        | Value                                  |
	| DocumentName | test.txt                               |
	When DocumentInformationDataAccess.StoreDocumentInformation is passed DocumentInformation labeled "test document A"
	Then DocumentInformationDataAccess.StoreDocumentInformation returns "false"
	
@L2
Scenario: Save document information without name
	Given a new DocumentInformation labeled "test document A" with the values:
	| Field      | Value                                  |
	| DocumentId | 92DA2385-2CE9-434D-9A97-2D589D61ABA3   |
	When DocumentInformationDataAccess.StoreDocumentInformation is passed DocumentInformation labeled "test document A"
	Then DocumentInformationDataAccess.StoreDocumentInformation returns "false"

@L2
Scenario: Save document information with duplicate id
	Given a new DocumentInformation labeled "test document A" with the values:
	| Field        | Value                                  |
	| DocumentId   | 92DA2385-2CE9-434D-9A97-2D589D61ABA3   |
	| DocumentName | testA.txt                              |
	And a new DocumentInformation labeled "test document B" with the values:
	| Field        | Value                                  |
	| DocumentId   | 92DA2385-2CE9-434D-9A97-2D589D61ABA3   |
	| DocumentName | testB.txt                              |
	When DocumentInformationDataAccess.StoreDocumentInformation is passed two DocumentInformation labeled "test document A", "test document B"
	Then DocumentInformationDataAccess.StoreDocumentInformation returns "false"
	
	
@L2
Scenario: Save document information with duplicate name
	Given a new DocumentInformation labeled "test document A" with the values:
	| Field        | Value                                  |
	| DocumentId   | 92DA2385-2CE9-434D-9A97-2D589D61ABA3   |
	| DocumentName | test.txt                               |
	And a new DocumentInformation labeled "test document B" with the values:
	| Field        | Value                                  |
	| DocumentId   | 82DA2385-2CE9-434D-9A97-2D589D61ABA3   |
	| DocumentName | test.txt                               |
	When DocumentInformationDataAccess.StoreDocumentInformation is passed two DocumentInformation labeled "test document A", "test document B"
	Then DocumentInformationDataAccess.StoreDocumentInformation returns "false"

@L2
Scenario: Save a document information
	Given a new DocumentInformation labeled "test document A" with the values:
	| Field        | Value                                  |
	| DocumentId   | 92DA2385-2CE9-434D-9A97-2D589D61ABA3   |
	| DocumentName | test.txt                               |
	When DocumentInformationDataAccess.StoreDocumentInformation is passed DocumentInformation labeled "test document A"
	Then DocumentInformationDataAccess.StoreDocumentInformation returns "true"