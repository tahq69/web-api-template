namespace Crip.Samples.Data.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Migration of users and roles tables.
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class CreateUserAndRoleTable : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
                "dbo.Role",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Key = c.String(),
                    CreatedAt = c.DateTime(nullable: false),
                    UpdatedAt = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Username = c.String(maxLength: 100),
                    Email = c.String(maxLength: 254),
                    Password = c.String(maxLength: 255),
                    RememberToken = c.String(maxLength: 100),
                    Name = c.String(),
                    Surname = c.String(),
                    CreatedAt = c.DateTime(nullable: false),
                    UpdatedAt = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true);

            this.CreateTable(
                "dbo.UserRole",
                c => new
                {
                    User_Id = c.Long(nullable: false),
                    Role_Id = c.Long(nullable: false),
                })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.UserRole", "Role_Id", "dbo.Role");
            this.DropForeignKey("dbo.UserRole", "User_Id", "dbo.User");
            this.DropIndex("dbo.UserRole", new[] { "Role_Id" });
            this.DropIndex("dbo.UserRole", new[] { "User_Id" });
            this.DropIndex("dbo.User", new[] { "Email" });
            this.DropIndex("dbo.User", new[] { "Username" });
            this.DropTable("dbo.UserRole");
            this.DropTable("dbo.User");
            this.DropTable("dbo.Role");
        }
    }
}
