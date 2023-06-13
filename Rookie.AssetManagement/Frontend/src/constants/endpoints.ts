import { changePassword } from "src/containers/Authorize/reducer";
import { number } from "yup";

const Endpoints = {
    authorize: 'api/Security/login',
    user: 'api/user',
    userId: (id : number | string) : string => `api/user/${id}`,
    staffcode: (staffcode: string): string => `api/Asset/${staffcode}`,
    assetCode: (assetCode: string): string => `api/Asset/${assetCode}`,
    me: 'api/Security/getMe',
    changePassword: '/api/Security/changePasswordFirstLogin',
    changePasswordAgain: '/api/Security/changePassword',
    asset: 'api/asset',
    assignment: 'api/assignment',
    userAssignment: 'api/Assignment/findByUser',
    deleteAssignment: (id: number) => `api/Assignment/${id}`,
    assignmentId: (assignmentId: number) => `api/Assignment/UpdateWaitingReturn/${assignmentId}`,
    assignmentIdUpdate: (assginmentId: number |string): string => `api/Assignment/${assginmentId}`,
    request: 'api/request',
    acceptAssignment: (id: number) => `/api/Assignment/Accept/${id}`,
    declineAssignment: (id: number) => `/api/Assignment/Decline/${id}`,
};

export default Endpoints;
