
function restClient(url)
{
    this.url = url;
}


function processRequest (callBack, response)
{
    if (callBack)
    {
        if (response && response.responseText)
        {
            response = JSON.parse(response.responseText);
        }
        else
        {
            response = {};
        }

        callBack(response);
    }
}

restClient.prototype.GET = function (callBack)
{
    this.callBack = callBack;
    createHttpClient("GET", this.url, "application/json", function (x) { processRequest(callBack, x); }).send();
}


restClient.prototype.POST = function (dataObj, callBack)
{
    createHttpClient("POST", this.url, "application/json", function (x) { processRequest(callBack, x); }).send(JSON.stringify(dataObj));
}


restClient.prototype.PUT = function (dataObj, callBack)
{
    this.callBack = callBack;
    createHttpClient("PUT", this.url, "application/json", function (x) { processRequest(callBack, x); }).send(JSON.stringify(dataObj));
}

restClient.prototype.DELETE = function (callBack)
{
    this.callBack = callBack;
    createHttpClient("DELETE", this.url, "application/json", function (x) { processRequest(callBack, x); }).send();
}
