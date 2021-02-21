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

        public static string SpDeleteTeacherById()
        {
            return @"CREATE PROCEDURE SpDeleteTeacherById 
                        @Id uniqueidentifier
                    as
                    BEGIN
	                    DELETE FROM Teachers
	                        where Id = @Id 
                    END";
        }
    }
}