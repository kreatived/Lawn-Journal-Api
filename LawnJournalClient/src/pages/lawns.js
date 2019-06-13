import React, { useState, useEffect } from 'react';
import axios from 'axios';

export const Lawns = () => {
    const [lawns, setLawns] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const result = await axios('http://localhost:5000/api/lawns');

            setLawns(result.data);
        };

        fetchData();
    }, []);

    return (
        <div>
            <h1>Manage Your Lawns</h1>

            <h2>Lawn Count: {lawns.length}</h2>
        </div>
    )
}