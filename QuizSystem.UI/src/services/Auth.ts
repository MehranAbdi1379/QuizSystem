function GetAuthToken()
{
    if(localStorage.getItem('token'))
    return localStorage.getItem('token')
    else 
    return ''
}

export default GetAuthToken;