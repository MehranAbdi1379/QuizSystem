function GetAuthToken()
{
    const token = localStorage.getItem('token');
    if(token)
    return token
    else 
    return ''
}

export default GetAuthToken;