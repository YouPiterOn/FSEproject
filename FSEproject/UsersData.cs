using System;

namespace FSEproject
{
    public class UsersData
    {
        public string nickname { get; set; }
        public DateTime? lastSeenDate { get; set; }
    }

    public class AllData
    {
        public List<UsersData> data { get; set; }
    }
}
