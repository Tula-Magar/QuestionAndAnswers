using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuestionAndAnswers.Models;

namespace QuestionAndAnswers.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<QuestionAndAnswers.Models.QA_DataModel> QA_DataModel { get; set; }
    }
}