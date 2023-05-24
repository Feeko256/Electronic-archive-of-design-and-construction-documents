using Electronic_archive_of_design_and_construction_documents.Models;
using Microsoft.EntityFrameworkCore;

namespace Electronic_archive_of_design_and_construction_documents.Core;

public class ApplicationContext : DbContext
{
    public DbSet<Project> Project { get; set; }
    public DbSet<Docs_of_product> Docs_of_product { get; set; }
    public DbSet<Document> Document { get; set; }
    public DbSet<doc_content_other> doc_content_other { get; set; }
    public DbSet<doc_content_thech_drawning> doc_content_thech_drawning { get; set; }

  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost\SQLEXPRESS;Database=ElectroinicArchiveDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}