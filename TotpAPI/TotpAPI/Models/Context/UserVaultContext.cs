using Microsoft.EntityFrameworkCore;
using System;

namespace TotpAPI.Models.Context
{
    public class UserVaultContext : DbContext
    {
        public DbSet<UserVault> UserVaults { get; set; }

        public string DbPath { get; }

        public UserVaultContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "userVault.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { 
            options.UseSqlite($"Data Source={DbPath}");
            // SQLitePCL.raw.SetProvider(new SQLitePCL.bundle_winsqlite3 )
        }
    }
}
