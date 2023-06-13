import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { stat } from "fs";
import { SetStatusType } from "src/constants/status";
import IAssignment from "src/interfaces/Assignment/IAssignment";
import IAssignmentForm from "src/interfaces/Assignment/IAssignmentForm";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignmentModel";
import IError from "src/interfaces/IError";
import IPagedModel from "src/interfaces/IPagedModel";

type AssignmentState = {
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

const initialState: AssignmentState = {
    assignments: null,
    loading: false,
    disable: false
}

const assignmentReduceSlice = createSlice({
    name: 'assignment',
    initialState,
    reducers: {
        createAssignment: (state, action: PayloadAction<CreateAction>) : AssignmentState => {
            return {
                ...state,
                loading: false,
            }
        },

        setAssignment: (state, action: PayloadAction<IAssignment | undefined>) : AssignmentState => {
            const assignmentResult = action.payload;

            return {
                ...state,
                assignmentResult,
                loading: false,
            }
        },

        getAssignment: (state, action: PayloadAction<IPagedModel<IAssignment>>): AssignmentState => {
            return {
                ...state,
                loading: true,
            }
        },

        getAssignments: (state, action: PayloadAction<IQueryAssignmentModel>): AssignmentState => {
            return {
                ...state,
                loading: true,
            }
        },

        setAssignments: (state, action: PayloadAction<IPagedModel<IAssignment>>): AssignmentState => {
            const assignments = action.payload;
            return {
                ...state,
                assignments,
                loading: false,
            }
        },

        deleteAssignment: (state, action: PayloadAction<DisableAction>): AssignmentState => {
            return {
                ...state,
                loading: true,
            }
        },

        setStatus: (state, action: PayloadAction<SetStatusType>): AssignmentState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            }
        },

        updateAssignment: (state, action: PayloadAction<CreateAction>): AssignmentState => {
            return {
                ...state,
                loading: true,
            }
        },
    }
})

export const {
    createAssignment, setAssignment, getAssignment, getAssignments, setAssignments, setStatus, deleteAssignment, updateAssignment
} = assignmentReduceSlice.actions;

export default assignmentReduceSlice.reducer;
