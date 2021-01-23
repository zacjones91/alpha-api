using System;
using System.Collections.Generic;
using System.Text;

namespace Alpha.Common.Enums
{
    public enum ErrorCodeEnum
    {
        Ok = 200,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        Unavailable = 404,
        InvalidRequest = 405,
        InternalServerError = 500,
        ServerBusy = 503
    }
}
