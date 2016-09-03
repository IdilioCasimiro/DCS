using DataCenterSpecialist.Models.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DataCenterSpecialist.Models.Contexto
{
    public class ContextoCadastro : DbContext
    {
        public DbSet<CaboEthernet> CabosEthernet { get; set; }
        public DbSet<CaboEnergia> CabosEnergia { get; set; }
        public DbSet<FibraOptica> FibraOptica { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }

        public DbSet<SFP> SFPs { get; set; }
        public DbSet<Licenca> Licencas { get; set; }
        public DbSet<Smartnet> Smartnets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Configurações CabosEthernet
            modelBuilder.Entity<CaboEthernet>().ToTable("CabosEthenet");
            modelBuilder.Entity<CaboEthernet>().HasKey(p => p.CaboID);

            //Configurações CabosEnergia
            modelBuilder.Entity<CaboEnergia>().ToTable("CabosEnergia");
            modelBuilder.Entity<CaboEnergia>().HasKey(p => p.CaboEnergiaID);

            //Configurações FibraOptica
            modelBuilder.Entity<FibraOptica>().ToTable("FibraOptica");
            modelBuilder.Entity<FibraOptica>().HasKey(p => p.CaboID);

            //Configurações Equipamento
            modelBuilder.Entity<Equipamento>().ToTable("Equipamentos");
            modelBuilder.Entity<Equipamento>().HasKey(p => p.EquipamentoID);
            modelBuilder.Entity<Equipamento>().HasMany(p => p.Licencas).WithRequired(p => p.Equipamento).HasForeignKey(p => p.EquipamentoID);
            modelBuilder.Entity<Equipamento>().HasMany(p => p.Smartnets).WithRequired(p => p.Equipamento).HasForeignKey(p => p.EquipamentoID);

            //Configuracoes SFP
            modelBuilder.Entity<SFP>().ToTable("SFPs");
            modelBuilder.Entity<SFP>().HasKey(p => p.SFPID);

            //Configuracoes Licencas
            modelBuilder.Entity<Licenca>().ToTable("Licencas");
            modelBuilder.Entity<Licenca>().HasKey(p => p.LicencaID);
            modelBuilder.Entity<Licenca>().HasRequired(p => p.Equipamento).WithMany(p => p.Licencas).HasForeignKey(p => p.EquipamentoID); //(N : 1)

            //Configuracoes Smartnets
            modelBuilder.Entity<Smartnet>().ToTable("Smartnets");
            modelBuilder.Entity<Smartnet>().HasKey(p => p.SmartnetID);
            modelBuilder.Entity<Smartnet>().HasRequired(p => p.Equipamento).WithMany(p => p.Smartnets).HasForeignKey(p => p.EquipamentoID); //(N : 1)

            base.OnModelCreating(modelBuilder); 
        }
    }
}