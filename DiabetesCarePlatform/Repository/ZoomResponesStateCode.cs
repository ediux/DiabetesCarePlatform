using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Helpers.ZoomSupports
{
    public enum ZoomResponesStateCode
    {
        Success = 0,
        Waiting_for_confirm_mail = 1,
        APIKeyInvaild = 5,
        MissingParameters = 6,
        CheckValueInvaild=7,
        FunctionNotFound = 8,
        APIReturnError=9,
        UserAlreadyRegistered=1000,
        UserNotExists=2000
    }
}