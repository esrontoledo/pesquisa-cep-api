using Es.PesquisaCep.DomainCore.Entities;

namespace Es.PesquisaCep.Domain.DbModel
{
    public class UserDbModel : EntityDbModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
