export default interface IQueryAssignmentModel {
    keyword: string;
    State: number[];
    assignDate: string;
    sortBy: string;
    Ascending: boolean;
    locationId: string;
    limit: number;
    page: number;
    sortOrder: string;
    sortColumn: string;
}