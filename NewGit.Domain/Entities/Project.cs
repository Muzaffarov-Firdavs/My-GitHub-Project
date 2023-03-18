using NewGit.Domain.Commons;
using NewGit.Domain.Enums;

namespace NewGit.Domain.Entities
{
    public class Project : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Star { get; set; }
        public bool IsPublic { get; set; }
        public ProgrammingLanguage MostUsedLanguage { get; set; }
        public long OwnerId { get; set; }  
        public User Owner { get; set; }
    }
}
