import {useHttp} from '../hooks/http.hook';

const useTodoListService = () => {
    const {request} = useHttp();

    const _api = 'https://localhost:7162/api/Affairs/';

    const getAllAffairs = async () => {
        return await request(_api);
    }

    const getAffair = async (id) => {
        return await request(_api + id);
    }

    const putAffair = async (title, annotation, endDate) => {
        return await request(_api, 'PUT', JSON.stringify({title, annotation, endDate}));
    }

    const postAffair = async (affair) => {
        return await request(_api, 'POST', JSON.stringify(affair));
    }

    const deleteAffair = async (id) => {
        return await request(_api + id, 'DELETE');
    }

    return {getAllAffairs, getAffair, putAffair, postAffair, deleteAffair}
}

export default useTodoListService;