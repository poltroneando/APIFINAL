namespace APIFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Filmes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filmes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 50),
                        Descricao = c.String(maxLength: 200),
                        Duracao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Filmes");
        }
    }
}
