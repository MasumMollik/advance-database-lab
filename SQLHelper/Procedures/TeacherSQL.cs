namespace PerformanceCalculator.SQLHelper.Procedures
{
    public static class TeacherSQL
    {
        public static string SpGetTeacherById()
        {
            return @"CREATE PROCEDURE SpGetTeacherById 
                        @Id uniqueidentifier
                    as
                    BEGIN
	                    Select * from Teachers
	                        where Id = @Id 
                    END";
        }
    }
}