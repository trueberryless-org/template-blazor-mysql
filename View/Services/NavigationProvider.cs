﻿using System.Collections.Specialized;
using Microsoft.AspNetCore.Components;

namespace View.Services;

public class NavigationProvider
{
    private readonly NavigationManager _navigationManager;
    private readonly Dictionary<string, Page> _pages;

    public NavigationProvider(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
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
            {
                "Imprint",
                new Page()
                {
                    Name = "Imprint", Link = "/imprint", Type = PageType.FOOTER,
                    Icon = Icons.Material.Filled.Assignment
                }
            },
            {
                "Sources",
                new Page()
                {
                    Name = "Source", Link = "/source", Type = PageType.FOOTER,
                    Icon = Icons.Material.Filled.Source
                }
            },
            {
                "Inactive Users",
                new Page()
                {
                    Name = "Inactive Users", Link = "/admin/inactiveusers", Type = PageType.ADMIN_SETTINGS,
                    Icon = Icons.Material.Filled.GroupOff
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
                "Games",
                new Page()
                {
                    Name = "Games",
                    Link = "/Games",
                    Type = PageType.CONTENT,
                    Icon = Icons.Material.Filled.Games,
                    Priority = PagePriority.IMPORTANT
                }
            },
            {
                "Tag",
                new Page()
                {
                    Name = "Tag",
                    Link = "/Tag",
                    Type = PageType.CONTENT,
                    Icon = Icons.Material.Filled.Tag,
                    Priority = PagePriority.IMPORTANT
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
        };

        var url = _navigationManager.Uri;

        switch (GetSubdomain(url))
        {
            case null:
                break;
            case "api":
                if (GetFirstPath(url) == string.Empty)
                {
                    
                }
                else
                {
                    _pages.Add(
                        GetFirstPath(url),
                        new Page()
                        {
                            Name = GetFirstPath(url),
                            Link = GetNewUrl(url, GetFirstPath(url)),
                            Type = PageType.RELATED
                        }
                    );
                    _pages.Add(
                        "Docs",
                        new Page()
                        {
                            Name = "Docs",
                            Link = GetNewUrl(url, "docs", GetFirstPath(url)),
                            Type = PageType.RELATED,
                            Icon = Icons.Material.Filled.Code
                        }
                    );
                }
                break;
            case "docs":
                if (GetFirstPath(url) == string.Empty)
                {
                    
                }
                else
                {
                    _pages.Add(
                        GetFirstPath(url),
                        new Page()
                        {
                            Name = GetFirstPath(url),
                            Link = GetNewUrl(url, GetFirstPath(url)),
                            Type = PageType.RELATED
                        }
                    );
                    _pages.Add(
                        "API",
                        new Page()
                        {
                            Name = "API",
                            Link = GetNewUrl(url, "api", GetFirstPath(url)),
                            Type = PageType.RELATED,
                            Icon = Icons.Material.Filled.Api
                        }
                    );
                }
                break;
            default:
                _pages.Add(
                    "API",
                    new Page()
                    {
                        Name = "API",
                        Link = GetNewUrl(url, "api", GetSubdomain(url)),
                        Type = PageType.RELATED,
                        Icon = Icons.Material.Filled.Api
                    }
                );
                _pages.Add(
                    "Docs",
                    new Page()
                    {
                        Name = "Docs",
                        Link = GetNewUrl(url, "docs", GetSubdomain(url)),
                        Type = PageType.RELATED,
                        Icon = Icons.Material.Filled.Code
                    }
                );
                break;
        }
    }

    public Page this[string name] => _pages[name];

    public List<Page> GetPages(params PageType[] types)
    {
        return GetPages(types.ToList());
    }

    public List<Page> GetPages(IEnumerable<PageType> types)
    {
        var pageTypes = types.ToList();
        if (pageTypes.ToList().Count > 0)
            return _pages
                .Where(p => pageTypes.Contains(p.Value.Type))
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
    
    public static string GetNewUrl(string url, string? newSubdomain)
    {
        // Split the URL into its components
        var uri = new Uri(url);
        var scheme = uri.Scheme;
        var host = uri.Host;

        // Split the host into its subdomains
        var domainParts = host.Split('.').ToList();

        if (domainParts.Count < 2)
        {
            throw new ArgumentException("Domain must at least contain of Top-Level-Domain and Second-Level-Domain");
        }

        // Rebuild the URL with the new subdomain and the new path
        if (newSubdomain == null)
        {
            return $"{scheme}://{domainParts[^2]}.{domainParts[^1]}";
        }
        else
        {
            return $"{scheme}://{newSubdomain}.{domainParts[^2]}.{domainParts[^1]}";
        }
    }

    public static string GetNewUrl(string url, string? newSubdomain, string newPath)
    {
        // Split the URL into its components
        var uri = new Uri(url);
        var scheme = uri.Scheme;
        var host = uri.Host;

        // Split the host into its subdomains
        var domainParts = host.Split('.').ToList();

        if (domainParts.Count < 2)
        {
            throw new ArgumentException("Domain must at least contain of Top-Level-Domain and Second-Level-Domain");
        }

        // Rebuild the URL with the new subdomain and the new path
        if (newSubdomain == null)
        {
            return $"{scheme}://{domainParts[^2]}.{domainParts[^1]}/{newPath}";
        }
        else
        {
            return $"{scheme}://{newSubdomain}.{domainParts[^2]}.{domainParts[^1]}/{newPath}";
        }
    }

    public static string? GetSubdomain(string url)
    {
        // Split the URL into its components
        var uri = new Uri(url);
        var host = uri.Host;

        // Split the host into its subdomains
        var subdomains = host.Split('.').ToList();

        return subdomains.Count < 3 ? null : subdomains[0];
    }

    public static string GetFirstPath(string url)
    {
        var uri = new Uri(url);
        var path = uri.AbsolutePath;
        if (string.IsNullOrEmpty(path))
        {
            return string.Empty;
        }

        var parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
        {
            return string.Empty;
        }

        return parts[0];
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
    ADMIN_SETTINGS,
    FOOTER,
    RELATED,
    SERVICE,
    USER,
}

public enum PagePriority
{
    IMPORTANT,
    TRIVIAL
}