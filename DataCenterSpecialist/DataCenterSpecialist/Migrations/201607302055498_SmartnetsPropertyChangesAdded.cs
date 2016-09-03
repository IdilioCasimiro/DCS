namespace DataCenterSpecialist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmartnetsPropertyChangesAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Smartnets", "Fornecedor", c => c.String(nullable: false));
            AlterColumn("dbo.Smartnets", "Descricao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Smartnets", "Descricao", c => c.String());
            AlterColumn("dbo.Smartnets", "Fornecedor", c => c.String());
        }
    }
}
