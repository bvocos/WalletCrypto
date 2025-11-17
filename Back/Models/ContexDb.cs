using Microsoft.EntityFrameworkCore;

namespace cyptowallet.Models;

public class ContexDb : DbContext
{
    public ContexDb(DbContextOptions<ContexDb> options) : base(options)
    { 

    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Crypto> Cryptos    { get; set; }
    public DbSet<Transactions> Transactions { get; set; }
    public DbSet<TypeTransaction> TypeTransactions { get; set; }


    
}
