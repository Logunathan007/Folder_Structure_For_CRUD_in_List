namespace OneToManyRelatonship.Model
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
