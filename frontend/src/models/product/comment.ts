export class CommentViewModel{
    public id: number;
    public author: string;
    public image: string;
    public content: string;
    public time: string;
    public date: string;
    public children: CommentViewModel[];
    public canDelete: boolean;
    public manager: boolean;
}