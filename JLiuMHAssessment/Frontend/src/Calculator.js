import React, { Component } from "react";
import { variables } from "./Variables.js";

export class Calculator extends Component {
  constructor(props) {
    super(props);

    this.state = {
      PropertyValue: "",
      LoanAmountValue: "",
      LVR: "",
    };
  }

  refreshResult() {}

  componentDidMount() {
    this.refreshResult();
  }

  changePropertyValue = (e) => {
    this.setState({ PropertyValue: e.target.value });
  };
  changeLoanAmountValue = (e) => {
    this.setState({ LoanAmountValue: e.target.value });
  };

  createClick() {
    fetch(variables.API_URL + "Calculator/AddCalculation", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        LoanAmount: this.state.LoanAmountValue,
        PropertyValue: this.state.PropertyValue,
      }),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          this.setState({ LVR: result });
          this.refreshResult();
        },
        (error) => {
          alert("Failed");
        }
      );
  }

  render() {
    const { PropertyValue, LoanAmountValue, LVR } = this.state;

    return (
      <div>
        <div>
          <div className="d-flex flex-row bd-highlight mb-3">
            <div className="p-2 w-50 bd-highlight">
              <label style={{ float: "left", fontSize: "2em" }}>
                Fill in the details
              </label>
              <br />
              <br />
              <br />
              <label style={{ float: "left" }}>
                What is the value of the property?
              </label>
              <div className="input-group mb-3">
                <span className="input-group-text">$</span>
                <input
                  type="text"
                  className="form-control"
                  value={PropertyValue}
                  onChange={this.changePropertyValue}
                />
              </div>
              <label style={{ float: "left" }}>
                How much are you planning to borrow?
              </label>
              <div className="input-group mb-3">
                <span className="input-group-text">$</span>
                <input
                  type="text"
                  className="form-control"
                  value={LoanAmountValue}
                  onChange={this.changeLoanAmountValue}
                />
              </div>
            </div>
            <div className="p-2 w-50 bd-highlight">
              <br />
              <br />
              <br />
              <label>Result</label>
              <div class="table" style={{ border: "1px solid" }}>
                <div class="cell">Property Value {PropertyValue}</div>
                <hr />
                <div class="cell">Loan Amount {LoanAmountValue}</div>
                <hr />
                <div class="cell" style={{ color: "green" }}>
                  LVR {(LVR * 100).toFixed(2)} %
                </div>
              </div>
            </div>
          </div>
          <button
            type="button"
            className="btn btn-primary float-start"
            style={{ backgroundColor: "green" }}
            onClick={() => this.createClick()}
          >
            Calculate
          </button>
        </div>
      </div>
    );
  }
}
