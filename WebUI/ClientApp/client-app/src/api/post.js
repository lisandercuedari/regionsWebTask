import axiosInstance from './client';

async function post(resourcePath, body){
    const response = await axiosInstance.post(resourcePath, body)
    return response;
};

export default post;
