import React, {useState, useEffect} from 'react';
import axios from 'axios';
import './lawnDetail.css';
import { AddSection } from '../components/AddSection/AddSection';

export const LawnDetail = ({match}) => {
    const [lawn, setLawn] = useState({sections: []});

    useEffect(() => {
        const fetchData = async () => {
            const result = await axios(process.env.API_URL + '/lawns/' + match.params.lawnId);

            setLawn(result.data);
        };

        fetchData();
    }, {});

    const addNewSection = (section) => {
        var updatedLawn = {...lawn};
        updatedLawn.sections.push(section);
        setLawn(updatedLawn);
        $('#addSectionModal').modal('toggle');
    };

    const deleteSection = async (e) => {
        const id = e.target.id;
        await axios.delete(process.env.API_URL + '/lawns/' + match.params.lawnId + '/sections/' + id);
        var updatedLawn = {...lawn};
        updatedLawn.sections = lawn.sections.filter((value, index, arr) => {
            return value.id !== id;
        });

        setLawn(updatedLawn);
    };

    return (
        <div>
            <div className="jumbotron">
                <h1 className="display-4">Lawn Detail for {lawn.name}</h1>
                <p className="lead">{lawn.description}</p>
            </div>

            <div className="container lawndetail">
                <div>
                    <div className="row">
                        <div className="col-md-6">
                            <h2>Sections</h2>
                        </div>
                        <div className="col-md-6">
                        <button type="button" className="btn btn-primary float-right" data-toggle="modal" data-target="#addSectionModal">Add Section</button>
                        </div>
                    </div>
                    <div className="row">
                        <table className="table">
                            <thead>
                                <tr>
                                    <th scope="col">Name</th>
                                    <th scope="col">Description</th>
                                    <th scope="col">Square Feet</th>
                                    <th scope="col">Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                {lawn.sections.map(section => (
                                    <tr key={section.id}>
                                        <td>{section.name}</td>
                                        <td>{section.description}</td>
                                        <td>{section.squareFeet}</td>
                                        <td><button type="button" className="btn btn-danger" id={section.id} onClick={deleteSection}>Delete</button></td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                    
                </div>
                <div className="row">
                    <div className="col-lg-4">
                    <img className="rounded-circle" src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" alt="Generic placeholder image" width="140" height="140" />
                        <h2>Product Applications</h2>
                        <p>Here you can track all the product applications you put in your lawn. These applications can range from fertilizer, to weed killers, and everything inbetween.</p>
                    </div>
                    <div className="col-lg-4">
                    <img className="rounded-circle" src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" alt="Generic placeholder image" width="140" height="140" />
                        <h2>Activities</h2>
                        <p>It's always import to perform regular maintenance on your lawn. These activities can include mowing the lawn, pulling weeds, planting flowers, or just walking around.</p>
                    </div>
                    <div className="col-lg-4">
                    <img className="rounded-circle" src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" alt="Generic placeholder image" width="140" height="140" />
                        <h2>Irrigation</h2>
                        <p>Probably one of the most important aspects of lawn maintenance is water. Without proper irrigation, no matter how many products you put in your lawn, it will never reach its full potential.</p>
                    </div>
                </div>
            </div>

            <div className="modal fade" id="addSectionModal" tabIndex="-1" role="dialog">
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title">Add Section</h5>
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div className="modal-body">
                            <AddSection lawnId={match.params.lawnId} addNewSectionHandler={addNewSection.bind(this)}/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}