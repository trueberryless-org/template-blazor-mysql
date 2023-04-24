using System.Collections.Specialized;

namespace View.Services;

public class NavigationProvider
{
    private readonly Dictionary<string, Page> _pages;

    public NavigationProvider()
    {
        _pages = new Dictionary<string, Page>()
        {
            { 
                "Root", 
                new Page() { Name = "Root", Link = "/", Type = PageType.SERVICE } 
            },
            { 
                "Profile", 
                new Page() { Name = "Profile", Link = "/profile", Type = PageType.USER, Icon = Icons.Material.Filled.Person } 
            },
            {
                "Settings",
                new Page() { Name = "Settings", Link = "/settings", Type = PageType.USER, Icon = Icons.Material.Filled.Settings }
            },
            {
                "Login",
                new Page() { Name = "Login", Link = "/login", Type = PageType.AUTHENTICATION, Icon = Icons.Material.Filled.Login }
            },
            {
                "Register",
                new Page() { Name = "Register", Link = "/register", Type = PageType.AUTHENTICATION, Icon = Icons.Material.Filled.PersonAdd }
            },

            // Add pages here (everything else is automatic) #https://mudblazor.com/features/icons#icons
            {
                "Home", 
                new Page()
                {
                    Name = "Home", 
                    Link = "/", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Home
                }
            },
            {
                "Vignette", 
                new Page()
                {
                    Name = "Vignette", 
                    Link = "/Vignette", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Vignette
                }
            },
            {
                "Receipt", 
                new Page()
                {
                    Name = "Receipt", 
                    Link = "/Receipt", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Receipt
                }
            },
            {
                "Mail", 
                new Page()
                {
                    Name = "Mail", 
                    Link = "/Mail", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Mail
                }
            },
            {
                "Backspace", 
                new Page()
                {
                    Name = "Backspace", 
                    Link = "/Backspace", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Backspace
                }
            },
            {
                "Verified", 
                new Page()
                {
                    Name = "Verified", 
                    Link = "/Verified", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Verified
                }
            },
            {
                "Edit", 
                new Page()
                {
                    Name = "Edit", 
                    Link = "/Edit", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Edit
                }
            },
            {
                "Factory", 
                new Page()
                {
                    Name = "Factory", 
                    Link = "/Factory", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Factory
                }
            },
            {
                "Games", 
                new Page()
                {
                    Name = "Games", 
                    Link = "/Games", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Games
                }
            },
        };
    }

    public Page this[string name] => _pages[name];

    public List<Page> GetPages(params PageType[] types)
    {
        if (types.Length > 0)
            return _pages
                .Where(p => types.Contains(p.Value.Type))
                .Select(p => p.Value)
                .ToList();

        else
            return _pages
                .Select(p => p.Value)
                .ToList();
    }
}

public struct Page
{
    public string Name;
    public string Link;
    public PageType Type;
    public Color Color;

    // HTML Path string
    public string Icon;

    public Page()
    {
        Name = null;
        Link = null;
        Type = PageType.CONTENT;
        Icon = Icons.Material.Filled.Icecream;
        Color = Color.Default;
    }
}

public enum PageType
{
    AUTHENTICATION,
    CONTENT,
    SERVICE,
    USER,
}