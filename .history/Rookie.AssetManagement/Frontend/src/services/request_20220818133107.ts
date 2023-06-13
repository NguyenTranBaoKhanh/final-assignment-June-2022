import axios, { AxiosInstance, AxiosRequestConfig } from "axios";

const config: AxiosRequestConfig = {
    //'https://localhost:44318/'
    //'https://localhost:5001/'
    // 'https://asset-management-team3-group1.azurewebsites.net/'
    baseURL: 'https://asset-management-team3-group1.azurewebsites.net/'
}

class RequestService {
    public axios: AxiosInstance;

    constructor() {
        this.axios = axios.create(config);
    }

    public setAuthentication(accessToken: string) {
        this.axios.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`;
    }
}

export default new RequestService();
