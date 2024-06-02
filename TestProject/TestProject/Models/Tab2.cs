namespace TestProject.Models
{
    public class Tab2
    {
        public long Id { get; set; }
        public string Data { get; set; }
        public long KeyTab1 { get; set; }

        public Tab1 Tab1 { get; set; }
    }
}
