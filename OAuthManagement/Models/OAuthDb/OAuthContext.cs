using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OAuthManagement.AppSettings;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class OAuthContext : DbContext
    {
        private readonly ConnectionStrings _connectionStrings;

        public OAuthContext(DbContextOptions<OAuthContext> options) : base(options)
        {
        }

        public OAuthContext(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public virtual DbSet<AccessProvider> AccessProvider { get; set; }
        public virtual DbSet<AccessProviderType> AccessProviderType { get; set; }
        public virtual DbSet<AccessToken> AccessToken { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientAccessParameter> ClientAccessParameter { get; set; }
        public virtual DbSet<ClientConfig> ClientConfig { get; set; }
        public virtual DbSet<ClientGrantType> ClientGrantType { get; set; }
        public virtual DbSet<ClientIdentity> ClientIdentity { get; set; }
        public virtual DbSet<ClientImpersonation> ClientImpersonation { get; set; }
        public virtual DbSet<ClientParameter> ClientParameter { get; set; }
        public virtual DbSet<ClientResourceAccess> ClientResourceAccess { get; set; }
        public virtual DbSet<IdentityProvider> IdentityProvider { get; set; }
        public virtual DbSet<IdentityProviderType> IdentityProviderType { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }

        // Unable to generate entity type for table 'dbo.OriginPromoter'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tmp_list_of_sellers'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tmp_Client'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tmp_ClientConfig'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tmp_ClientGrantType'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tmp_ClientIdentity'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tmp_ClientImpersonation'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tmp_ClientParameter'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tmp_ClientResourceAccess'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionStrings.OAuth);
                //optionsBuilder.UseSqlServer(@"Data Source=sqluatau.tt.local;Initial Catalog=OAuth;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessProvider>(entity =>
            {
                entity.Property(e => e.AccessProviderId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Configuration).IsUnicode(false);
            });

            modelBuilder.Entity<AccessProviderType>(entity =>
            {
                entity.Property(e => e.AccessProviderTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccessToken>(entity =>
            {
                entity.HasKey(e => e.Token);

                entity.HasIndex(e => new { e.Token, e.Expires })
                    .HasName("NCINDEX_AccessToken_Expires_INC_Token");

                entity.Property(e => e.Token)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Expires).HasColumnType("datetime");

                entity.Property(e => e.IssuedAt).HasColumnType("datetime");

                entity.Property(e => e.LastConsumed).HasColumnType("datetime");

                entity.Property(e => e.Scope)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('*')");

                entity.Property(e => e.Uses).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.AccessToken)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccessToken_Client");

                entity.HasOne(d => d.ClientImpersonation)
                    .WithMany(p => p.AccessToken)
                    .HasForeignKey(d => d.ClientImpersonationId)
                    .HasConstraintName("FK_AccessToken_ClientImpersonation");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Secret)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientAccessParameter>(entity =>
            {
                entity.Property(e => e.AccessProviderId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.AccessProvider)
                    .WithMany(p => p.ClientAccessParameter)
                    .HasForeignKey(d => d.AccessProviderId)
                    .HasConstraintName("FK_ClientAccessParameter_AccessProvider");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientAccessParameter)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceAccess_ResourceAccess");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ClientAccessParameter)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK_ResourceAccess_Resource");
            });

            modelBuilder.Entity<ClientConfig>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ClientGrantType>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GrantType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientIdentity>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityClientId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityProviderId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientImpersonation>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImpersonateClientId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientImpersonationClient)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientImpersonation_Client");

                entity.HasOne(d => d.ImpersonateClient)
                    .WithMany(p => p.ClientImpersonationImpersonateClient)
                    .HasForeignKey(d => d.ImpersonateClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientImpersonation_Client1");
            });

            modelBuilder.Entity<ClientParameter>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientParameter)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientParameters_Client");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ClientParameter)
                    .HasForeignKey(d => d.ResourceId)
                    .HasConstraintName("FK_ClientParameters_ClientParameters");
            });

            modelBuilder.Entity<ClientResourceAccess>(entity =>
            {
                entity.Property(e => e.Access)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientResourceAccess)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientResourceAccess_Client");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ClientResourceAccess)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientResourceAccess_Resource");
            });

            modelBuilder.Entity<IdentityProvider>(entity =>
            {
                entity.Property(e => e.IdentityProviderId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Configuration).IsUnicode(false);
            });

            modelBuilder.Entity<IdentityProviderType>(entity =>
            {
                entity.Property(e => e.IdentityProviderTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.Token);

                entity.Property(e => e.Token)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccessToken)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Consumed).HasColumnType("datetime");

                entity.HasOne(d => d.AccessTokenNavigation)
                    .WithMany(p => p.RefreshToken)
                    .HasForeignKey(d => d.AccessToken)
                    .HasConstraintName("FK_RefreshToken_AccessToken");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.ResourceId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Access)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasDefaultValueSql("('*')");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uri)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
