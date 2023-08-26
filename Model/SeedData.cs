
namespace efcore_practice.Model
{
    public class SeedData
    {
        public static void Seed(StudentDbContext context)
        {
            if (context.Students.Any()) return;
            
            var students = new List<Student>()
            {
                new Student
                    {
                        StudentId = Guid.NewGuid(),
                        FirstName = "Stephen",
                        MiddleName = "Melben",
                        LastName = "Contoso",
                    },
                    new Student
                    {
                        StudentId = Guid.NewGuid(),
                        FirstName = "Ann",
                        MiddleName = "Margarett",
                        LastName = "Contoso",
                    },
                    new Student
                    {
                        StudentId = Guid.NewGuid(),
                        FirstName = "Marco",
                        MiddleName = "Rettiene",
                        LastName = "Contoso",
                    },
                    new Student
                    {
                        StudentId = Guid.NewGuid(),
                        FirstName = "Renatus",
                        MiddleName = "",
                        LastName = "Crostobos",
                    },
                    new Student
                    {
                        StudentId = Guid.NewGuid(),
                        FirstName = "Evelyn",
                        MiddleName = "",
                        LastName = "Crostobos",
                    }
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}