import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from 'src/services/request';
import EndPoints from 'src/constants/endpoints';
import IUserForm from "src/interfaces/User/IUserForm";
import IUser from "src/interfaces/User/IUser";
import IQueryUserModel from "src/interfaces/User/IQueryUserModel";


export function createUserRequest(userForm: IUserForm): Promise<AxiosResponse<IUser>> {
    return RequestService.axios.post(EndPoints.user, userForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}

export function updateUserRequest(userForm: IUserForm): Promise<AxiosResponse<IUser>> {
    return RequestService.axios.put(EndPoints.userId(userForm.userId ?? -1), userForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}

export function getUsersRequest(query: IQueryUserModel): Promise<AxiosResponse<IUser>> {
    return RequestService.axios.get(EndPoints.user, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}
export function DisableUserRequest(userId: number): Promise<AxiosResponse<Boolean>> {
    return RequestService.axios.delete(EndPoints.userId(userId));
}