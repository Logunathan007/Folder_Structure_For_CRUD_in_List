﻿namespace OneToManyRelatonship.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ManagerId { get; set; }

        public Manager Manager { get; set; }
    }
}
