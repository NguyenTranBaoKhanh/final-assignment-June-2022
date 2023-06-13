export default interface IPagedModel<T> {
    limit: number,
    page: number,

    currentPage: number,
    totalItems: number,
    totalPages: number,

    pageCount: number,
    totalRecords: number,
    items: [T]
}