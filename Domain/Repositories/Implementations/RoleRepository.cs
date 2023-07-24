using Model.Entities.Authentication;

namespace Domain.Repositories.Implementations;

public class RoleRepository : ARepository<Role>, IRoleRepository {
    public RoleRepository(ModelDbContext context) : base(context) {
    }

    public async Task<IEnumerable<User>> GetAllUsersWithRole(string identifier)
    {
        return await Table
            .Where(r => r.Identifier == identifier)
            .SelectMany(r => r.RoleClaims.Select(rc => rc.User))
            .ToListAsync();
    }
}