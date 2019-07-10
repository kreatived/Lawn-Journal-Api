import React, { useState, useEffect } from 'react';
import axios from 'axios';
import {LawnList} from '../components/LawnList/LawnList';

export const Lawns = () => {
    const [lawns, setLawns] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const result = await axios(process.env.API_URL + '/lawns');

            setLawns(result.data);
        };

        fetchData();
    }, []);

    return (
        <div>
            <div className="jumbotron">
                <h1 className="display-4">Manage Your Lawns</h1>
                <p className="lead">This is where you can keep track of all your lawns along with some high-level information about them.</p>
                <hr className="my-4"/>
                <p>You are currently managing {lawns.length} lawns with a total of {lawns.reduce((prev, cur) => {return prev + cur.squareFeet}, 0)} sq ft.</p>
                <a className="btn btn-primary btn-lg" href="#" role="button">Add A Lawn</a>
            </div>

            <div className="container">
                <LawnList lawns={lawns} />
            </div>
        </div>
    )
}