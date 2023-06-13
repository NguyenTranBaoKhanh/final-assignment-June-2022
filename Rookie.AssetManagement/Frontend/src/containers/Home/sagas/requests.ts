import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IAssignment from "src/interfaces/Assignment/IAssignment";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignmentModel";

export function getUserAssignmentsRequest(query: IQueryAssignmentModel): Promise<AxiosResponse<IAssignment>> {
    return RequestService.axios.get(EndPoints.userAssignment, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function updateUserAssignmentRequest(assignmentId: number): Promise<AxiosResponse<IAssignment>> {
    return RequestService.axios.put(EndPoints.assignmentId(assignmentId?? ""), assignmentId, {
        paramsSerializer: params => qs.stringify(params),
    });
}

export function AcceptAssignmentRequest(assignmentId: number): Promise<AxiosResponse<Boolean>> {
    return RequestService.axios.put(EndPoints.acceptAssignment(assignmentId));
}

export function DeclineAssignmentRequest(assignmentId: number): Promise<AxiosResponse<Boolean>> {
    return RequestService.axios.put(EndPoints.declineAssignment(assignmentId));
}