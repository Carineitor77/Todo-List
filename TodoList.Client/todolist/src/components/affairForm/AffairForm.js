import useTodoListService from '../../services/TodoListService';

const AffairForm = () => {
    const {putAffair} = useTodoListService();
    
    const onSave = () => {
        const title = document.getElementById('title').value;
        const annotation = document.getElementById('annotation').value;
        const endDate = document.getElementById('endDate').value;

        if (title, annotation, endDate.match(/^\d{2}([./-])\d{2}\1\d{4}$/)) {
            putAffair(title, annotation, endDate);
            onResetForm();
        }
    }

    const onResetForm = () => {
        document.getElementById('title').value = null;
        document.getElementById('annotation').value = null;
        document.getElementById('endDate').value = null;
    }

    return (
        <div>
            <div className="mb-3">
                <label className="form-label" htmlFor="title">Title:</label>
                <input className="form-control" id="title" />
            </div>
            <div className="mb-3">
                <label className="form-label" htmlFor="annotation">Annotation:</label>
                <input className="form-control" id="annotation" />
            </div>
            <div className="mb-3">
                <label className="form-label" htmlFor="endDate">Expiration date:</label>
                <input className="form-control" id="endDate" />
            </div>
            <div className="mb-3">
                <button className="btn btn-success" onClick={onSave}>Save</button>
                <button className="btn btn-secondary" onClick={onResetForm}>Reset</button>
                <button className="btn btn-warning" onClick={() => document.location.reload()}>Update data</button>
            </div>
        </div>
    )
}

export default AffairForm;