export class PagedList<T>{
    public items: T[];
    public totalCount: number;
    public pageNumber: number;
    public pageSize: number;
}