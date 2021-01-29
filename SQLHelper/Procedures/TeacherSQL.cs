namespace PerformanceCalculator.SQLHelper.Procedures
{
    public static class TeacherSQL
    {
        public static string SpGetTeacherById()
        {
            return @"create procedure GetTeacherById(id text)
                            language plpgsql
                            as $$
                            begin
                                select * from Teachers
                                    where Id = id;
                            end;$$";
        }
    }
}