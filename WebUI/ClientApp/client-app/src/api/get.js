import axiosInstance from './client';

async function get(resourcePath){
    const response = await axiosInstance.get(resourcePath)
    return response.data;
};

export default get;
