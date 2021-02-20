using Microsoft.EntityFrameworkCore.Migrations;
using PerformanceCalculator.SQLHelper.Procedures;

namespace SQLHelper
{
    public static class SQLRegister
    {
        public static void RegisterSQL(MigrationBuilder migrationBuilder )
        {
            migrationBuilder.Sql(TeacherSQL.SpGetTeacherById());
            migrationBuilder.Sql(CourseSQL.CoursesByTeacherView());
            migrationBuilder.Sql(CourseSQL.CourseInsertTrigger());
        }
        public static void DropSQL(MigrationBuilder migrationBuilder )
        {
            migrationBuilder.Sql(TeacherSQL.DropSpGetTeacherById());
            migrationBuilder.Sql(CourseSQL.DropCoursesByTeacherView());
            migrationBuilder.Sql(CourseSQL.DropCourseInsertTrigger());
        }
    }
}