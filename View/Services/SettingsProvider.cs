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

    /// <summary>
    /// The name of the application or company is used many times.
    /// For example in email templates, on view pages and so on.
    /// </summary>
    public const string ApplicationName = "MyFirstTemplate";

    #endregion

    #region Your Email Settings

    /// <summary>
    /// In order for emails to work, we need these basic information:
    ///     Host: The url which hosts your email service ("smtp.gmail.com", "smtp.office365.com", ...)
    ///     Port: The port where emails should be sent from (465 for SSL/TLS, 587)
    ///     SSL: Is used to encrypt your emails (in most cases activated on ports 465 or 587
    ///     Username: If you dont know any username, it is very likely your email address
    ///     From: From which email address should all emails be sent from?
    ///     Password: // TODO make secure
    /// </summary>
    public const string EmailHost = "";
    public const int EmailPort = 587;
    public const bool EmailEnableSsl = true;
    
    public const string EmailUsername = "";
    public const string EmailFrom = "";
    public const string EmailPassword = "";

    /// <summary>
    /// In some emails we need these information:
    ///     AppName: What is the name of your company?
    ///     AppUrl: The user should be able to quickly open your app [base url]
    ///     AppLogo: Path [Url or relative Path] to your logo img
    /// </summary>
    public const string EmailApplicationName = "YouTube";
    public const string EmailApplicationUrl = "https://www.youtube.com";
    public const string EmailApplicationLogo = "https://static.vecteezy.com/system/resources/previews/018/930/572/original/youtube-logo-youtube-icon-transparent-free-png.png";
    
    public const string EmailCompanySlogan = "Watch what you want!";
    public const string EmailCompanyAddress = "youtube@gmail.com";
    

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
    public const bool NewUsersNeedToBeConfirmedByAdmins = true;

    #endregion
}