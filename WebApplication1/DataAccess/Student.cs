namespace WebApplication1.DataAccess
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Major { get; set; }

        public override string? ToString()
        {
            return Id.ToString()+" "+Name+" "+Gender+" "+Major;
        }
    }
}
