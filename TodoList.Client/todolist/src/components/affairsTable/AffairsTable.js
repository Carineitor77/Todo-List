import { useState, useEffect } from 'react';

import useTodoListService from '../../services/TodoListService';

const AffairsTable = () => {
    const {getAllAffairs, postAffair, deleteAffair} = useTodoListService();

    const [affairs, setAffairs] = useState(null);

    useEffect(() => {
        updateAffairs();
    }, []);

    const updateAffairs = () => {
        getAllAffairs()
            .then(onAffairsLoaded);
    }

    const onAffairsLoaded = (affairs) => {
        setAffairs(affairs);
    }

    const onChangeAffair = (affair, i) => {
        const title = document.getElementsByClassName('title')[i].value;
        const annotation = document.getElementsByClassName('annotation')[i].value;
        const startDate = document.getElementsByClassName('startDate')[i].value;
        const endDate = document.getElementsByClassName('endDate')[i].value;

        if (title, annotation, 
            startDate.match(/^\d{2}([./-])\d{2}\1\d{4}$/), 
            endDate.match(/^\d{2}([./-])\d{2}\1\d{4}$/),
            startDate < endDate) {

                affair.title = title;
                affair.annotation = annotation;
                affair.startDate = startDate;
                affair.endDate = endDate;
                
                postAffair(affair);
        }
    }
    
    const onDeleteAffair = (id) => {
        deleteAffair(id);
    }

    function renderItems(affairs) {
        const items = affairs.map((item, i) => {
            return (
                <tr key={item.id}>
                    <td>
                        <input 
                            type='text' 
                            defaultValue={item.title} 
                            className='form-control title'>
                        </input>
                    </td>
                    <td>
                        <input 
                            type='text' 
                            defaultValue={item.annotation} 
                            className='form-control annotation'>
                        </input>
                    </td>
                    <td>
                        <input 
                            type='text' 
                            defaultValue={item.startDate.substr(0, 10)} 
                            className='form-control startDate'>
                        </input>
                    </td>
                    <td>
                        <input 
                            type='text' 
                            defaultValue={item.endDate.substr(0, 10)} 
                            className='form-control endDate'>
                        </input>
                    </td>
                    <td>
                        <button 
                            className='btn btn-info' 
                            onClick={() => onChangeAffair(item, i)}>
                                Change
                        </button>
                    </td>
                    <td>
                        <button 
                            className='btn btn-danger' 
                            onClick={() => onDeleteAffair(item.id)}>
                                Delete
                        </button>
                    </td>
                </tr>
            )
        });

        return (
            <tbody>
                {items}
            </tbody>
        )
    }

    const items = affairs != null
        ? renderItems(affairs)
        : null;

    return (
        <table className="table table-condensed table-striped table-bordered">
            <thead>
                <tr>
                    <th>Title:</th>
                    <th>Annotation</th>
                    <th>Start date</th>
                    <th>End date</th>
                </tr>
            </thead>
            {items}
        </table>
    )
}

export default AffairsTable;