import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: `https://localhost:44380/api/`,
});

axiosInstance.defaults.headers.post['Content-Type'] = 'application/json';

export default axiosInstance;