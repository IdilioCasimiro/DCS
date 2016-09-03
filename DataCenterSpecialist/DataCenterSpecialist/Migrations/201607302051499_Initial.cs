namespace DataCenterSpecialist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Licencas", "Descricao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Licencas", "Descricao");
        }
    }
}
