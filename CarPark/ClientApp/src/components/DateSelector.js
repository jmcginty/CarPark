import React, { Component } from 'react';
import Datetime from 'react-datetime';

export class DateSelector extends Component {
  displayName = DateSelector.name

  constructor(props) {
    super(props);
      this.state = { startDate: new Date(), endDate: new Date(), totalPrice: null, rate: '', rateType: '' };
      this.startChanged = this.startChanged.bind(this);
      this.endChanged = this.endChanged.bind(this);
      this.getRate = this.getRate.bind(this);
  }

    getRate(startDate, endDate) {
        // todo template 
        var path = window.location.protocol + '//' + window.location.host + '/api/Rate?startDate=' + startDate.toJSON() + '&endDate=' + endDate.toJSON();
        fetch(path)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        ...this.state, 
                        totalPrice: result.totalPrice,
                        rate: result.name,
                        rateType: result.type
                    });
                },
                // Note: it's important to handle errors here
                // instead of a catch() block so that we don't swallow
                // exceptions from actual bugs in components.
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
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
        return (
            <div>
                <div>
                    Entry Time
                    <Datetime dateFormat="DD/MM/YYYY"
                        onChange={this.startChanged}
                    />
                </div>
                <div>
                    Exit Time
                    <Datetime dateFormat="DD/MM/YYYY"
                        onChange={this.endChanged}
                    />
                </div>

                <div>
                    Rate {this.state.rate}
                </div>
                <div>
                    Type {this.state.rateType}
                </div>
                <div>
                    Total Amount ${this.state.totalPrice}
                </div>
            </div>
        );
    }
}
