Feature: IndexElasticDocument
	Describes how a document is added to the elastic index.

@L2
Scenario: Adds document to index
	Given a new ElasticDocument labeled "test document A" with the values:
	| Field        | Value                                 |
	| DocumentName | test.txt                              |
	| Text         | I am some text for the elastic thingy |
 	When ElasticSearchDataAccess.IndexElasticDocument is passed ElasticDocument labeled "test document A"
 	Then ElasticSearchDataAccess.IndexElasticDocument returns "true"
 	
#Add step to check for duplicates