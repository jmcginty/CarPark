import React, { Component } from 'react';

import { DateSelector } from './DateSelector';

export class Home extends Component {
    displayName = Home.name

    render() {
        return (
            <div>
                <h1>Welcome to the Car Park</h1>               
                <DateSelector/>
                
            </div>
        );
    }
}
