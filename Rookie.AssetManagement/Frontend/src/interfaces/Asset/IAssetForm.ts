export default interface IAssetForm {
    assetId? : number,
    assetCode?: string,
    assetName : string,
    specification: string
    categoryID: string,
    assetState: string;
    installedDay?: Date;
    categoryName?:string,
    locationID?: string
}

