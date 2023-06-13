export default interface IAssignmentForm {
    assignmentId? : number| string
    staffCode?: string 
    assetCode: string
    assignedDate?: Date
    note: string
    fullName?: string
    assetName?: string
}