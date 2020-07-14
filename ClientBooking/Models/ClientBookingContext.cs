using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ClientBooking.Models
{
    public partial class ClientBookingContext : DbContext
    {
        public ClientBookingContext()
        {
        }

        public ClientBookingContext(DbContextOptions<ClientBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingAdress> BookingAdress { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientContact> ClientContact { get; set; }
        public virtual DbSet<EmailLog> EmailLog { get; set; }

        //Just for now comment the OnConfiguring() method of Client|BookingContext class because later we will configure our
        //Dependency Injection inside the Startup.cs class

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            // services.AddScoped<IClientRepository, ClientRepository>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(50);


            });

            modelBuilder.Entity<BookingAdress>(entity =>
            {
                entity.Property(e => e.BookingAdressId).HasColumnName("BookingAdressID");

                entity.Property(e => e.AdressType)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HomeAdress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClientContact>(entity =>
            {
                entity.Property(e => e.ClientContactId).HasColumnName("ClientContactID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
