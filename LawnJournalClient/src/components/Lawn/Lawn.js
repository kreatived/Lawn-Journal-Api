import React from 'react';
import {Link} from 'react-router-dom';

export const Lawn = (props) => {

    return (
        <div className="card">
            <img src="http://placeimg.com/180/180/nature" alt="" className="card-img-top"/>
            <div className="card-body">
                <h5 className="card-title">{props.lawn.name}</h5>
                <p className="card-text">{props.lawn.description}</p>
                <Link to={"/lawns/" + props.lawn.id} className="btn btn-primary">View Lawn</Link>
            </div>
            <div className="card-footer">
                <small className="text-muted float-left">{props.lawn.sections.length} sections</small>
                <small className="text-muted float-right">{props.lawn.squareFeet} sq ft</small>
            </div>
        </div>
    )
}