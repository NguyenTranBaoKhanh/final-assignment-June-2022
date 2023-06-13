export default interface IQueryUserModel {
    keyword: string;
    page: number;
    limit: number;
    type: string[];
    Ascending: boolean;
    sortBy: string;
    locationId: string;
}