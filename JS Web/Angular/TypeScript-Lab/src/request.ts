class MyRequest{
    response:string;

    fulfilled:boolean;

    constructor(
        public method:string,
        public uri:string,
        public version:string, 
        public message:string) {
        this.fulfilled = false;
    }
}