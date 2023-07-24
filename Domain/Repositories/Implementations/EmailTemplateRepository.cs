using Model.Entities.Email;

namespace Domain.Repositories.Implementations;

public class EmailTemplateRepository : ARepository<EmailTemplate>, IEmailTemplateRepository
{
    public EmailTemplateRepository(ModelDbContext context) : base(context)
    {
    }
}