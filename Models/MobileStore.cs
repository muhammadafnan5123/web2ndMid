using System.Data.Entity;

namespace MuhammadAfnan2ndMid.Models
{
    public class MobileStore
    {
        public int ID { get; set; }
        public string MobileName { get; set; }
        public string Company { get; set; }
        public string MadeIn { get; set; }
        public int Price { get; set; }

        public class MobileStoreDBContext : DbContext
        {
            public DbSet<MobileStore> MobileStores { get; set; }
        }
    }
}