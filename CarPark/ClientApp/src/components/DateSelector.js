import React, { Component } from 'react';
import Datetime from 'react-datetime';

export class DateSelector extends Component {
  displayName = DateSelector.name

  constructor(props) {
    super(props);
      this.state = { startDate: null, endDate: null, totalPrice: null, rate: '', rateType: '', error: '' };
      this.startChanged = this.startChanged.bind(this);
      this.endChanged = this.endChanged.bind(this);
      this.getRate = this.getRate.bind(this);
  }

    getRate(startDate, endDate) {
        if (startDate === null || endDate === null) {
            return;
        }
        var path = window.location.protocol + '//' + window.location.host + '/api/Rate?startDate=' + startDate.toJSON() + '&endDate=' + endDate.toJSON();
        fetch(path)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        ...this.state, 
                        totalPrice: result.totalPrice,
                        rate: result.name,
                        rateType: result.type,
                        error: result.error
                    });
                }
            );
    }

    startChanged(start) {
        if (start.isValid()) {
            this.setState({
                ...this.state, startDate: start.toDate()
            });
            this.getRate(start.toDate(), this.state.endDate);
        }
    }

    endChanged(end) {
        if (end.isValid()) {
            this.setState({
                ...this.state, endDate: end.toDate()
            });
            this.getRate(this.state.startDate, end.toDate());
        }
    }

    render() {
        let errorText = null;
        let resultText = null;

        if (this.state.error !== null) {
            errorText =
                <div>
                    {this.state.error}
                </div>;
        }
        else {
            resultText =
            <div>
                <div>
                    Rate {this.state.rate}
                </div>
                <div>
                    Type {this.state.rateType}
                </div>
                <div>
                    Total Amount ${this.state.totalPrice}
                </div>
            </div>;
        }

        return (
            <div>
                <div className="row">
                    <div className="col-sm-3">
                        Entry Time
                    </div>
                    <div className="col-sm-9">
                        <Datetime dateFormat="ddd DD/MM/YYYY"
                            onChange={this.startChanged}
                            
                            closeOnSelect
                        />
                    </div>
                    <br />
                    <br />
                    <div >
                        <div className="col-sm-3">
                            Exit Time
                        </div>
                        <div className="col-sm-9">
                            <Datetime dateFormat="ddd DD/MM/YYYY"
                                onChange={this.endChanged}
                                closeOnSelect
                            />
                        </div>
                    </div>
                </div>
                <br />
                {errorText}
                <br />
                <br />
                {resultText}
            </div>
        );
    }
}
