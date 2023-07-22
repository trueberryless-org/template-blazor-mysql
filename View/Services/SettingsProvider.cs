namespace View.Services;

public static class SettingsProvider
{
    /// <summary>
    /// Hello! If you just started using this template
    /// please go through this class end edit all properties
    /// as you like. Most of them are self-explanatory.
    ///
    /// We are constantly developing new options for you!
    /// Thank you for using this template!
    ///
    /// Please start by setting this value to true:
    /// </summary>
    public const bool DeveloperKnowsAboutSettingsProvider = true;

    #region Application Settings

    public const string ApplicationName = "MyFirstTemplate";

    #endregion

    #region Your Email Settings

    public const string EmailHost = "smtp.gmail.com";
    public const int EmailPort = 587;
    public const bool EmailEnableSsl = true;
    
    public const string EmailUsername = "";
    public const string EmailFrom = "";
    public const string EmailPassword = "";

    public const string EmailApplicationUrl = "";
    public const string EmailApplicationLogo = "";
    public const string EmailApplicationName = "";
    
    public const string EmailHeaderText = "";
    public const string EmailCompanyAddress = "";
    public const string EmailApplicationLogInPage = "";
    

    #endregion

    #region Registration

    /// <summary>
    /// true:   [default] New users are able to create their account.
    /// false:  Users who currently dont have an account, cannot use the website.
    /// </summary>
    public const bool UserCanRegister = true;

    /// <summary>
    /// true:   If a new user registers, the need to be confirmed by an admin.
    /// false:  [default] As soon as a user registers, a new account is created.
    /// </summary>
    public const bool NewUsersNeedToBeConfirmedByAdmins = false;

    #endregion
}