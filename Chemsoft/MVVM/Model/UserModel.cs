namespace Chemsoft.MVVM.Model
{
    internal class UserModel : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public UserModel(ulong id, string? lastName, string? firstName, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            ID = id;
        }

        public UserModel Clone()
        {
            return null;
            //return new UserModel { ID = ID, Age = Age, FirstName = FirstName, LastName = LastName };
        }
    }
}
