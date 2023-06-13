export default interface IAsset {
    assetCode: string,
    assetName: string,
    assetState: string,
    categoryID: string,
    categoryName?: string,
    locationID: string,
    installedDay: Date,
    specification: string,
}
