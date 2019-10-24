namespace Vidla.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c30e00ab-090a-4e69-8a8f-43f4afc2d2db', N'guest1@vidla.com', 0, N'AKvvDZX7rUAY+ms5Gcu5ll5BTn3HKFAhGJueKrcowE7C3OvBnAWHWYsgMDpuO5Ryag==', N'9beb8706-4f7d-48c4-94f4-9cf0c358be51', NULL, 0, 0, NULL, 1, 0, N'guest1@vidla.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f3c003a4-38fe-4215-a98e-420f93e1814e', N'admin1@vidla.com', 0, N'ANARMRwCXhI9Hy/k9ThuR8ZhF6re3ytKOydZcufbFSOLvJ+fHsh6flDbnxOqgV5BJg==', N'6d93ce61-e122-4ce0-a09d-e8a06c68bc71', NULL, 0, 0, NULL, 1, 0, N'admin1@vidla.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6fbc8a45-f134-44b4-9b7b-926adb5a2f4a', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f3c003a4-38fe-4215-a98e-420f93e1814e', N'6fbc8a45-f134-44b4-9b7b-926adb5a2f4a')

");
        }
        
        public override void Down()
        {
        }
    }
}
