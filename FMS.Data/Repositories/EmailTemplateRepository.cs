using FMS.Model;
using FMS.Data.Infrastructure;

namespace FMS.Data.Repositories
{
    internal class EmailTemplateRepository : RepositoryBase<EmailTemplate>, IEmailTemplateRepository
    {
        internal EmailTemplateRepository(IDbFactory dbFactory): base(dbFactory) {

        }
    }

}
