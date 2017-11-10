using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Authentication
/// </summary>
public static class Authentication
{
    public static bool AuthenticateUser(string UserName, string Password)
    {
        var Result = false;
        var EncryptedUserName = Ciphering.Encrypt(UserName);
        var EncryptedPassword = Ciphering.Encrypt(Password);

        var UserNameInConfig = Convert.ToString(ConfigurationManager.AppSettings["UserName"]);
        var PasswordInConfig = Convert.ToString(ConfigurationManager.AppSettings["Password"]);

        if (EncryptedUserName == UserNameInConfig && EncryptedPassword == PasswordInConfig)
            Result = true;
        return Result;
    }
}