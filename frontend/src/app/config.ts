import { PathController } from './common/consts/path-controllers.const';
import { ApiWareHouse } from './api-ware-house';
export class Config {
    private static apiWareHouse: ApiWareHouse = new ApiWareHouse();

    public static getPath(value: string): string {
        const apiCluster: string = this.apiWareHouse.Protocol + this.apiWareHouse.ApiEndPoint;
        if (Object.keys(PathController).find((key) => PathController[key] === value)) {
            return apiCluster + value;
        }
        else {
            return apiCluster;
        }
    }

    public static getDomain(): string {
        return this.apiWareHouse.Domain;
    }
}
