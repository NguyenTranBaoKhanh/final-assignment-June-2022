export default interface IQueryRequestModel {
    keyword: string;
    State: number[];
    assignDate: string;
    sortBy: string;
    Ascending: boolean;
    locationId: string;
    limit: number;
    page: number;
}