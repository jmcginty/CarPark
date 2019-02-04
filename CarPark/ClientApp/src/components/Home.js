import React, { Component } from 'react';

import { DateSelector } from './DateSelector';

export class Home extends Component {
    displayName = Home.name

    render() {
        return (
            <div>
                <h1>Welcome to the Car Park</h1>
                <br/>
                <h4>Please enter your start and finish date and times to calculate your charges.</h4>
                <DateSelector/>
                
            </div>
        );
    }
}
