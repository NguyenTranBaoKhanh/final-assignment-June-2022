export default interface IRequestForm {
    requestId? : number
    assetCode: string 
    assetName: string
    assignedDate?: Date
    requestBy?: string
    acceptedBy?: string
    returnedDate?: Date
    sate: string
}
