namespace Empleado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CatalogoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empleadoes");
        }
    }
}
