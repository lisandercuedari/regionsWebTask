import axiosInstance from './client';

async function get(resourcePath, parameters){
    const response = await axiosInstance.get(resourcePath, {params: parameters})
    return response;
};

export default get;
