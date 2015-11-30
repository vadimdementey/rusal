
function createRequest()
{

    if (window.XMLHttpRequest)
    {
        return new XMLHttpRequest();
    }

    try
    {
        return new ActiveXObject('Msxml2.XMLHTTP');
    }
    catch (e)
    {
        try {
            return new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch (e) {
            return null;
        }
    }

}


function createHttpClient(method, url, contentType,onReceive,onError)
{
    var request = createRequest();
    request.open(method, url, true);

    request.setRequestHeader('Content-Type', contentType);


    request.onreadystatechange = function ()
    {
        if (request.readyState == 4)
        {
            if (request.status == 200)
            {
                onReceive(request);
                return;
            }

            if(onError) onError(request);
        }
    }

    return request;
}



