using Model.Entities.Authentication;

namespace Domain.Repositories.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
    /// <summary>
    /// Creates a list with all users that have a specific role.
    /// </summary>
    /// <param name="identifier">The identifier of the role which all users should have</param>
    /// <returns>A list of users</returns>
    Task<IEnumerable<User>> GetAllUsersWithRole(string identifier);
}