var MyRequest = (function () {
    function MyRequest(method, uri, version, message) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.fulfilled = false;
    }
    return MyRequest;
}());
//# sourceMappingURL=request.js.map