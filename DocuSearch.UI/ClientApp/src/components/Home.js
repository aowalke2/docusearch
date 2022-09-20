import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>DocuSearch</h1>
        <p>Welcome to DocuSearch, a document reviewer</p>
      </div>
    );
  }
}
