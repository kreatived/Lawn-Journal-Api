import React, {useState, useRef, useEffect} from 'react';
import axios from 'axios';

export const AddSection = (props) => {
    const [newSection, setNewSection] = useState({name: '', description: '', squareFeet: ''});
    const nameInput = useRef(null);

    useEffect(() => {
        nameInput.current.focus();
    }, []);

    const handleSubmit = async (event) => {
        event.preventDefault();

        const result = await axios.post(process.env.API_URL + '/lawns/' + props.lawnId + '/sections', newSection);

        props.addNewSectionHandler(result.data);
    }

    const handleInputChange = (event) => {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        newSection[name] = value;

        setNewSection(newSection);
    }

    return (
        <form onSubmit={handleSubmit}>
            <div className="form-group">
                <label htmlFor="name">Name</label>
                <input 
                    type="text" 
                    className="form-control" 
                    id="name" 
                    name="name"
                    aria-describedby="name" 
                    placeholder="Enter Section Name" 
                    defaultValue={newSection.name}
                    onChange={handleInputChange}
                    ref={nameInput}/>
            </div>
            <div className="form-group">
                <label htmlFor="description">Description</label>
                <input 
                    type="text" 
                    className="form-control" 
                    id="description" 
                    name="description"
                    aria-describedby="description" 
                    placeholder="Enter Section Description" 
                    defaultValue={newSection.description}
                    onChange={handleInputChange}/>
            </div>
            <div className="form-group">
                <label htmlFor="sqft">Square Feet</label>
                <input 
                    type="text" 
                    className="form-control" 
                    id="sqft" 
                    name="squareFeet"
                    aria-describedby="sqft" 
                    placeholder="Enter Section Sq Ft" 
                    defaultValue={newSection.squareFeet}
                    onChange={handleInputChange}/>
            </div>
            <button type="submit" className="btn btn-primary">Submit</button>
        </form>
    )
}