namespace PerformanceCalculator.SQLHelper.Procedures
{
    public static class CourseSQL 
    {
        public static string CoursesByTeacherView()
        {
            return @"
                CREATE VIEW vWCoursesByTeacher
                AS
                SELECT Courses.Id, Code, Title, Teachers.FirstName, Teachers.LastName, Teachers.Email from Courses
                JOIN Teachers
                ON Courses.TeacherId = Teachers.Id
            ";
        }
        public static string CourseInsertTrigger()
        {
            return @"CREATE TRIGGER tr_Courses_ForInsert
                    ON Courses
                    FOR INSERT
                    AS
                    BEGIN
                    Declare @Id uniqueidentifier, @Title nvarchar(250);
                    Select @Id = Id, @Title = Title from inserted
                    insert into CourseAudits
                    values(@Id, 'Course ' + @Title + ' is added at ' + cast(Getdate() as nvarchar(20)))
                    END
                    ";
        }
        public static string DropCoursesByTeacherView()
        {
            return @"DROP VIEW vWCoursesByTeacher";
        }
        public static string DropCourseInsertTrigger()
        {
            return @"DROP TRIGGER tr_Courses_ForInsert";
        }
    }
}