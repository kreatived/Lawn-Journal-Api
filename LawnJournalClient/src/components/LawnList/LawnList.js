import React from 'react';
import { Lawn } from '../Lawn/Lawn';

export const LawnList = (props) => {

    return (
        <div className="card-deck">
            {props.lawns.map(lawn => (
                <Lawn key={lawn.id} lawn={lawn} />
            ))}
        </div>
    )
}