namespace Employee_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Employees(EmployeeName,EmployeePhone,EmployeeGender,Birthday,DepartmentId)" +
                "Values('Suyog',9594,'Male','1998-09-06',1)");
        }
        
        public override void Down()
        {
        }
    }
}
