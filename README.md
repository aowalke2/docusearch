# DocuSearch v1.0

## User Workflow

1. A user uploads a document (synchronous upload)
   1. Upon successful upload, the user is notified that the document is being processed 
   2. If the upload fails, the user is warned with a pop-up 
2. The user goes to a web page where they can see the history of file uploads and the status of the document / job 
3. The user searches for keywords in all of the documents’ text and a list of documents containing that text is returned in a list 
4. The user clicks on the link to the file and can view the document text on a page 
5. The user is able click a drop down to select the document’s status (relevant, non-relevant, needs further review) and click ‘save’ to persist the new value for the document 
   1. User is notified if the save is successful or not 
6. User actions are audited

### Pages available to the user

- File upload page 
  - Button to upload a file 
  - List of all file upload jobs 
- Document list w/ keyword search 
- Document view page 
- Audit page 

## Requirements 
### In Scope 
1. As a Docusearch user, I can upload a txt document 
2. As a Docusearch user, I can see the list of document upload jobs and their statuses 
3. As a Docusearch user, I can search for keywords and get a list of documents that match that word (case insensitive)
4. As a Docusearch user, I can view a document’s text 
5. As a Docusearch user, I can assign a document’s status to either relevant, non-relevant, or needs further review 
6. As a Docusearch user, I can see audits for the following user actions 
   1. File upload 
   2. Page views 
   3. Document views 
   4. Document field edits

### Out of Scope
- Permissioning
- Any document type outside of txt
- File deduping
- Audit searching

### Assumptions
- Users can be created by hand in the database (no need to create the full user crud ui)
- The text search does not require any kind of ‘fuzziness’ searching
- No need to spend too much time on the UI – feel free to keep the pages simple and any frameworks to assist you are welcome

## Other Ideas
1. Implement this as a cloud solution 
   1. Can include automated deployments – CI/CD 

 