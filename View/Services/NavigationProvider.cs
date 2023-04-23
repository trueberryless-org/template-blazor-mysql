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
                new Page() { Name = "Register", Link = "/register", Type = PageType.AUTHENTICATION, Icon = Icons.Material.Filled.Logout }
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
                "Activities", 
                new Page()
                {
                    Name = "Activities", 
                    Link = "/activities", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Calculate
                }
            },
            {
                "Calendar", 
                new Page()
                {
                    Name = "Calendar", 
                    Link = "/Calendar", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.CalendarMonth
                }
            },
            {
                "Work", 
                new Page()
                {
                    Name = "Work", 
                    Link = "/Work", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Work
                }
            },
            {
                "Handshake", 
                new Page()
                {
                    Name = "Handshake", 
                    Link = "/Handshake", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Handshake
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
                "Padding", 
                new Page()
                {
                    Name = "Padding", 
                    Link = "/Padding", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Padding
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
                "Feedback", 
                new Page()
                {
                    Name = "Feedback", 
                    Link = "/Feedback", 
                    Type = PageType.CONTENT, 
                    Icon = Icons.Material.Filled.Feedback
                }
            },
            {
                "ZoomIn", 
                new Page()
                {
                    Name = "ZoomIn", 
                    Link = "/ZoomIn", 
                    Type = PageType.CONTENT
                }
            },
        };
    }

    public string this[string name] => _pages[name].Link;

    public List<Page> GetPages(params PageType[]? types)
    {
        if (types == null)
            return _pages.Select(p => p.Value).ToList();

        else
            return _pages
                .Where(p => types.Contains(p.Value.Type))
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
    USER,
}