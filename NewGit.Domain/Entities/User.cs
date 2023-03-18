using NewGit.Domain.Commons;

namespace NewGit.Domain.Entities
{
    public class User : Auditable
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Parol { get; set; }
        public int FollowingCount { get; set; }
        public int FollowerCount { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Organisation> Organisations { get; set; }
    }
}
