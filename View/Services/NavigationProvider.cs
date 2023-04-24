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
                new Page()
                {
                    Name = "Profile", Link = "/profile", Type = PageType.USER, Icon = Icons.Material.Filled.Person
                }
            },
            {
                "Settings",
                new Page()
                {
                    Name = "Settings", Link = "/settings", Type = PageType.USER, Icon = Icons.Material.Filled.Settings
                }
            },
            {
                "Login",
                new Page()
                {
                    Name = "Login", Link = "/login", Type = PageType.AUTHENTICATION, Icon = Icons.Material.Filled.Login
                }
            },
            {
                "Register",
                new Page()
                {
                    Name = "Register", Link = "/register", Type = PageType.AUTHENTICATION,
                    Icon = Icons.Material.Filled.PersonAdd
                }
            },

            // Add pages here (everything else is automatic) #https://mudblazor.com/features/icons#icons
            {
                "Home",
                new Page()
                {
                    Name = "Home",
                    Link = "/",
                    Type = PageType.CONTENT,
                    Icon = Icons.Material.Filled.Home,
                    Priority = PagePriority.IMPORTANT
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


    public List<Page> GetPagesSorted(params PageType[] types)
    {
        if (types.Length > 0)
            return _pages
                .Where(p => types.Contains(p.Value.Type))
                .Select(p => p.Value)
                .OrderBy(p => (int)p.Priority)
                .ToList();

        else
            return _pages
                .Select(p => p.Value)
                .OrderBy(p => (int)p.Priority)
                .ToList();
    }
}

public struct Page
{
    public string Name;
    public string Link;
    public PageType Type;
    public PagePriority Priority;
    public Color Color;

    // HTML Path string
    public string Icon;

    public Page()
    {
        Name = null;
        Link = null;
        Type = PageType.CONTENT;
        Priority = PagePriority.TRIVIAL;
        Icon = Icons.Material.Filled.Icecream;
        Color = Color.Inherit;
    }
}

public enum PageType
{
    AUTHENTICATION,
    CONTENT,
    SERVICE,
    USER,
}

public enum PagePriority
{
    IMPORTANT,
    TRIVIAL
}