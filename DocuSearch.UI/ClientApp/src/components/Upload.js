import React, { Component } from 'react';
import { Button, Form, Input } from 'reactstrap';

export class Upload extends Component {
	static displayName = Upload.name;

	constructor(props) {
		super(props);
		this.state = { 
			formFile: null,
			documentName: "",
			contentType: "",
			size: 0,
			isSelected: false,
			message: "Upload a file"
		};
	}
	
	InputChange = (event) => {
		const file = event.target.files[0];
		this.setState({ 
			formFile: file,
			documentName: file.name,
			contentType: file.type,
			size: file.size,
			isSelected: true
		});
	}
	
	UploadFile = async() => {
		if(this.state.isSelected) {
			const formData = new FormData();
			formData.append('formFile', this.state.formFile);
			formData.append('documentName', this.state.documentName);
			formData.append('contentType', this.state.contentType);
			formData.append('size', this.state.size);
			
			const response = await fetch('api/v1/document', {
				method: 'POST',
				body: formData,
			});
			
			if(response.status === 201){
				const document = await response.json();
				this.setState( {message: `File ${document.documentName} successfully uploaded!`})
			}
			else{
				const message = await response.text();
				this.setState( {message: `File was not uploaded. ${message}`})	
			}
		}
		else{
			this.setState( {message: "You need to upload a file"});
		}
	}
	
	render() {
		return (
			<div className="upload">
				<h1>File Upload</h1>
				<Form>
					<Input id="exampleFile" name="file" type="file" onChange={this.InputChange}/><br/>
					<Button onClick={this.UploadFile}>Upload!</Button>
				</Form><br/>
				<p>{this.state.message}</p>
			</div>
		);
	}
}
