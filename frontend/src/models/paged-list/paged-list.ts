export class PagedList<T>{
    public items: T;
    public totalCount: number;
    public pageIndex: number;
    public pageSize: number;
}