Feature: AddDocumentToIndex
	Describes how a document gets added to the elastic search index

@L1
Scenario: Successfully add document to index
	Given a new DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 10D2DCBF-6733-4670-BA37-5A3EBB45BC30 |
	| DocumentName | test.txt                             |
	| ContentType  | text/plain                           |
	| Text         | I am some text for the elastic index |
	And ElasticSearchDataAccess.IndexElasticDocument returns "true"
	When ElasticSearchService.AddDocumentToIndex is passed documentVo labeled "test document A"
	Then ElasticSearchDataAccess.IndexElasticDocument is called once
	And ElasticSearchService.AddDocumentToIndex returns "true"
	
@L1
Scenario: Unsuccessfully add document to index
	Given a new DocumentVo labeled "test document A" with the values:
	| Field        | Value                                |
	| DocumentId   | 10D2DCBF-6733-4670-BA37-5A3EBB45BC30 |
	| DocumentName | test.txt                             |
	| ContentType  | text/plain                           |
	| Text         | I am some text for the elastic index |
	And ElasticSearchDataAccess.IndexElasticDocument returns "false"
	When ElasticSearchService.AddDocumentToIndex is passed documentVo labeled "test document A"
	Then ElasticSearchDataAccess.IndexElasticDocument is called once
	And ElasticSearchService.AddDocumentToIndex returns "false"