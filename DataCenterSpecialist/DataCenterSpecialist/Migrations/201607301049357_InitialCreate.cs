namespace DataCenterSpecialist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CabosEnergia",
                c => new
                    {
                        CaboEnergiaID = c.Int(nullable: false, identity: true),
                        NumeroCaboEnergia = c.String(),
                        Rack = c.String(nullable: false),
                        Equipamento = c.String(nullable: false),
                        Fonte = c.String(nullable: false),
                        PDU = c.String(nullable: false),
                        Posicao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CaboEnergiaID);
            
            CreateTable(
                "dbo.CabosEthenet",
                c => new
                    {
                        CaboID = c.Int(nullable: false, identity: true),
                        NumeroCabo = c.Int(nullable: false),
                        Cor = c.String(nullable: false),
                        RackA = c.String(nullable: false),
                        EquipamentoA = c.String(nullable: false),
                        PortaA = c.String(nullable: false),
                        RackB = c.String(nullable: false),
                        EquipamentoB = c.String(nullable: false),
                        PortaB = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CaboID);
            
            CreateTable(
                "dbo.Equipamentos",
                c => new
                    {
                        EquipamentoID = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        Fabricante = c.String(nullable: false),
                        NomeEquipamento = c.String(nullable: false),
                        Localizacao = c.String(nullable: false),
                        DataArquisicao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EquipamentoID);
            
            CreateTable(
                "dbo.Licencas",
                c => new
                    {
                        LicencaID = c.Int(nullable: false, identity: true),
                        EquipamentoID = c.Int(nullable: false),
                        FabricanteLicenca = c.String(nullable: false),
                        FornecedorLicenca = c.String(),
                        TipoDeLicenca = c.String(nullable: false),
                        DataInicioCobertura = c.DateTime(nullable: false),
                        DataFimCobertura = c.DateTime(nullable: false),
                        Preço = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LicencaID)
                .ForeignKey("dbo.Equipamentos", t => t.EquipamentoID)
                .Index(t => t.EquipamentoID);
            
            CreateTable(
                "dbo.Smartnets",
                c => new
                    {
                        SmartnetID = c.Int(nullable: false, identity: true),
                        EquipamentoID = c.Int(nullable: false),
                        Fornecedor = c.String(),
                        Descricao = c.String(),
                        DataInicioCobertura = c.DateTime(nullable: false),
                        DataFimCobertura = c.DateTime(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SmartnetID)
                .ForeignKey("dbo.Equipamentos", t => t.EquipamentoID)
                .Index(t => t.EquipamentoID);
            
            CreateTable(
                "dbo.FibraOptica",
                c => new
                    {
                        CaboID = c.Int(nullable: false, identity: true),
                        NumeroCabo = c.Int(nullable: false),
                        Cor = c.String(nullable: false),
                        RackA = c.String(nullable: false),
                        EquipamentoA = c.String(nullable: false),
                        PortaA = c.String(nullable: false),
                        RackB = c.String(nullable: false),
                        EquipamentoB = c.String(nullable: false),
                        PortaB = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CaboID);
            
            CreateTable(
                "dbo.SFPs",
                c => new
                    {
                        SFPID = c.Int(nullable: false, identity: true),
                        Fabricante = c.String(nullable: false),
                        Referencia = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SFPID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Smartnets", "EquipamentoID", "dbo.Equipamentos");
            DropForeignKey("dbo.Licencas", "EquipamentoID", "dbo.Equipamentos");
            DropIndex("dbo.Smartnets", new[] { "EquipamentoID" });
            DropIndex("dbo.Licencas", new[] { "EquipamentoID" });
            DropTable("dbo.SFPs");
            DropTable("dbo.FibraOptica");
            DropTable("dbo.Smartnets");
            DropTable("dbo.Licencas");
            DropTable("dbo.Equipamentos");
            DropTable("dbo.CabosEthenet");
            DropTable("dbo.CabosEnergia");
        }
    }
}
