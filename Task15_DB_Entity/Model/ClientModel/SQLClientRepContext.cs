﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Task15_DB_Entity.Model.ClientModel
{
    public partial class SQLClientRepContext : DbContext
    {
        public SQLClientRepContext()
        {
        }

        public SQLClientRepContext(DbContextOptions<SQLClientRepContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\rsuadmin\\source\\repos\\mollari85\\Skillbox-tasks-win10\\TaskEntity\\Client.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Mail)
                    .HasName("PK__Clients__2724B2D0651943D2");

                entity.ToTable("Client");

                entity.Property(e => e.Mail).HasMaxLength(20);

                entity.Property(e => e.ID)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}