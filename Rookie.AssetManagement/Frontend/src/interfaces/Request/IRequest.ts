export default interface IRequest {
    id : number,
    assetCode: string,
    assetName: string,
    requestedBy?: string,
    acceptedBy?: string,
    assignedDate?: Date,
    requestState?: string,
    returnedDate?: Date,
}