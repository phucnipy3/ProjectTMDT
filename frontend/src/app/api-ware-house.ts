import { environment } from './../environments/environment';

export class ApiWareHouse {
    private domain: string;
    public get Domain(): string {
        return this.domain;
    }

    private protocol: string;
    public get Protocol(): string {
        return this.protocol;
    }

    private apiEndPoint: string;
    public get ApiEndPoint(): string {
        return this.apiEndPoint;
    }

    private appVersion: string;
    public get AppVersion(): string {
        return this.appVersion;
    }

    constructor() {
        this.appVersion = '1.0.0.0';
        if (environment.production) {
            this.domain = 'Nhom2.com';
            this.protocol = 'https://';
            this.apiEndPoint = 'nhom2TMDT.somee.com/api';
        }
        else {
            this.domain = 'Nhom2.com';
            this.protocol = 'https://';
            this.apiEndPoint = 'localhost:44376/api/';
        }
    }
}