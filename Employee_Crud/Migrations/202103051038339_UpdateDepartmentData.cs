namespace Employee_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDepartmentData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Departments(DepartmentName)Values('IT')");
            Sql("Insert into Departments(DepartmentName)Values('HR')");
            Sql("Insert into Departments(DepartmentName)Values('Payroll')");
            Sql("Insert into Departments(DepartmentName)Values('Finance')");
        }
        
        public override void Down()
        {

        }
    }
}
