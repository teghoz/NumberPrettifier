import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            prettyText: "",
            loading: true,
            number: 0,
            type: ""
        };
        this.handleNumberChange = this.handleNumberChange.bind(this);
        this.handleTypeChange = this.handleTypeChange.bind(this);
        this.handleClick = this.handleClick.bind(this);
    }

    handleNumberChange = (e) => {
        this.setState({ number: e.target.value });
    }

    handleTypeChange = (e) => {
        this.setState({ type: e.target.value });
    }

    handleClick = () => {
        this.getPrettyNumber(this.state.number, this.state.type);
    }

    render() {
        return (
            <div>
                <h1>Prettifier</h1>

                <div className="form-group">
                    <label htmlFor="txtNumber">Number</label>
                    <input type="number"
                        className="form-control"
                        id="txtNumber"
                        placeholder="Enter Number"
                        value={this.state.number}
                        onChange={this.handleNumberChange} />
                </div>

                <div className="form-group mt-2">
                    <label htmlFor="txtType">Type</label>
                    <select className="form-control" id="txtType" onChange={this.handleTypeChange} value={this.state.type}>
                        <option value="en">English</option>
                        <option value="fr">French</option>
                        <option value="abbrev">Abbreviated</option>
                    </select>
                </div>

                <br />

                <button className="btn btn-primary" onClick={this.handleClick}>Prettify</button>

                <br />
                <br />

                <p aria-live="polite">Prettified: <strong>{this.state.prettyText}</strong></p>
            </div>
        );
    }

    async getPrettyNumber(number, type) {
        const response = await fetch(`prettifier?number=${number}&type=${type}`);
        const data = await response.text();
        console.log("data: ", data);
        this.setState({ prettyText: data, loading: false });
    }
}
