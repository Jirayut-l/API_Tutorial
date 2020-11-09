namespace API_Infrastructure
{
    public partial class Employee
    {
        public int PkEmpId { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal? Salary { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
    }
}
