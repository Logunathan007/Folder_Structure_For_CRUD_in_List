namespace OneToManyRelatonship.Model
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string Name { get; set; }

        public Employee Employee { get; set; }
    }
}
