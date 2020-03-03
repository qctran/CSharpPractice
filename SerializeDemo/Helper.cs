using System.Collections.Generic;

namespace SerializeDemo
{
    public static class Helper
    {
        public static List<Customer> CreateData()
        {
            var data = new List<Customer>();
            data.Add(new Customer {Firstname = "Jane", Lastname = "Anderson", Age = 26, Credit = 2000.0});
            data.Add(new Customer {Firstname = "Angelina", Lastname = "Jolley", Age = 45, Credit = 1500.0});
            data.Add(new Customer {Firstname = "Bill", Lastname = "Cosby", Age = 78, Credit = 100.0});
            data.Add(new Customer {Firstname = "Tom", Lastname = "Cruz", Age = 52, Credit = 850.0});

            return data;
        }
    }
}
