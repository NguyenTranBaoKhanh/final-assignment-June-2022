export default interface IAssignment {
    id: number | string,
    assetCode: string,
    assetName: string,
    specifiCation?: string
    assignedByUser?: string,
    assignedToUser?: string,
    assignedDate: Date,
    assignmentState?: string,
    categoryName?: string,
    note: string,
    fullName?: string
}