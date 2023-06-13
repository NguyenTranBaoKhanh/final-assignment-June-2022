import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { stat } from "fs";
import { SetStatusType } from "src/constants/status";
import IAssignment from "src/interfaces/Assignment/IAssignment";
import IAssignmentForm from "src/interfaces/Assignment/IAssignmentForm";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignmentModel";
import IError from "src/interfaces/IError";
import IPagedModel from "src/interfaces/IPagedModel";

type UserAssignmentState = {
    loading: boolean;
    assignmentResult?: IAssignment;
    assignments: IPagedModel<IAssignment> | null;
    status?: number;
    error?: IError;
    disable: boolean;
}

export type CreateAction = {
    handleResult: Function,
    formValues: IAssignmentForm,
}

export type DisableAction = {
    handleResult: Function,
    assignmentId: number,
}

export type UpdateAction = {
    handleResult: Function,
    assignmentId: number,
}
export type AcceptAction = {
    handleResult: Function,
    assignmentId: number,
}

const initialState: UserAssignmentState = {
    assignments: null,
    loading: false,
    disable: false
}

const homeReduceSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        updateUserAssignment: (state, action: PayloadAction<UpdateAction>): UserAssignmentState => {
            return {
                ...state,
                loading: true,
            }
        },
       acceptAssignment: (state, action: PayloadAction<AcceptAction>): UserAssignmentState => {
            return {
                ...state,
                loading: true,
            }
        },
        declineAssignment: (state, action: PayloadAction<AcceptAction>): UserAssignmentState => {
            return {
                ...state,
                loading: true,
            }
        },

        setUserAssignment: (state, action: PayloadAction<IPagedModel<IAssignment>>): UserAssignmentState => {
            const assignments = action.payload;
            return {
                ...state,
                assignments,
                loading: false,
            }
        },

        setUserAssignments: (state, action: PayloadAction<IPagedModel<IAssignment>>): UserAssignmentState => {
            const assignments = action.payload;
            return {
                ...state,
                assignments,
                loading: false,
            }
        },

        getUserAssignments: (state, action: PayloadAction<IQueryAssignmentModel>): UserAssignmentState => {
            return {
                ...state,
                loading: true,
            }
        },

        setStatus: (state, action: PayloadAction<SetStatusType>): UserAssignmentState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            }
        },
    }
})

export const {
    getUserAssignments, setUserAssignments, setStatus, updateUserAssignment, setUserAssignment, acceptAssignment, declineAssignment
} = homeReduceSlice.actions;

export default homeReduceSlice.reducer;
