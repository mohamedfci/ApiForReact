namespace ApiForReact
{
    //public class Employee
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string Department { get; set; }
    //}

    public class Attachment
    {
        public string Name { get; set; }
        public string Url { get; set; } // If you are storing the URL in the database
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public List<Attachment> Attachments { get; set; }
    }

}
