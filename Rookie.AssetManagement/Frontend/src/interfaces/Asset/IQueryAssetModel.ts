export default interface IQueryAssetModel {
    keyword: string;
    category: string[];
    assetState: number[];
    sortBy: string;
    Ascending: boolean;
    locationId: string;
    limit: number;
    page: number;
}