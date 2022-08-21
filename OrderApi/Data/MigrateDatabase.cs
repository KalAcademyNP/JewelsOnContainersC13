using Microsoft.EntityFrameworkCore;

namespace OrderApi.Data
{
    public static class MigrateDatabase
    {
        public static void EnsureCreated(OrdersContext context)
        {
            context.Database.Migrate();
        }
    }
}
