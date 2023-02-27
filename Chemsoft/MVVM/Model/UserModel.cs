namespace Chemsoft.MVVM.Model
{
    internal class UserModel : BaseEntity
    {
        private string? _firstName { get; set; }
        private string? _lastdName { get; set; }
        private uint _age { get; set; }

        public string? FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                OnPropertyChanged(nameof(FirstName));
                _firstName = value;
            }
        }

        public string? LastName
        {
            get
            {
                return _lastdName;
            }
            set
            {
                OnPropertyChanged(nameof(LastName));
                _lastdName = value;
            }
        }

        public uint Age
        {
            get
            {
                return _age;
            }
            set
            {
                OnPropertyChanged(nameof(Age));
                _age = value;
            }
        }

        public UserModel(ulong id, string? lastName, string? firstName, uint age)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            ID = id;
        }

        public UserModel Clone()
        {
            return null;//todo сделать
            //return new UserModel { ID = ID, Age = Age, FirstName = FirstName, LastName = LastName };
        }
    }
}
