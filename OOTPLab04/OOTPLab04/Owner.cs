namespace OOTPLab04
{
     public partial class List<T>
    {
        public  class Owner
        {
            public int Id { get; }
            public string Name { get; set; } = "Ivan";
            public string Organisation { get; set; } = "BSTU";
            public Owner()
            {
                Id = 0;  
            }
            public Owner(int id,string name,string organisation)
            {
                Id = id;
                Name = name;
                Organisation = organisation;
            }
        }
    }
}
