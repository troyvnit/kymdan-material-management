using System.Data.Entity;
using KMM.Data.Migrations;
using KMM.Model.Models;

namespace KMM.Data
{
    public class KMMEntities : DbContext
    {
        public KMMEntities()
            : base("KMMEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KMMEntities, Configuration>());
        }

        DbSet<MaterialRequest> MaterialRequests { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
