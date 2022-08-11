using System;
using System.Collections.Generic;
using System.Text;

namespace IntercomCommunication.Models.Request
{
   public class TimeSlot
    {
        public Base @base { get; set; }
        public Fr fr { get; set; }
        public object apartment { get; set; }
        public Access access { get; set; }
        public Valid valid { get; set; }
        public Additional additional { get; set; }
        public TimeProfiles time_profiles { get; set; }
    }
    public class IdentifierOwner
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Base
    {
        public IdentifierOwner identifier_owner { get; set; }
        public string identifier_type { get; set; }
        public string identifier_number { get; set; }
        public string @lock { get; set; }
    }

    public class Fr
    {
        public object file { get; set; }
        public object name { get; set; }
    }

    public class Access
    {
        public bool is_permanent { get; set; }
    }

    public class Time
    {
        public bool is_permanent { get; set; }
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Passes
    {
        public bool is_permanent { get; set; }
        public int max_passes { get; set; }
    }

    public class Valid
    {
        public Time time { get; set; }
        public Passes passes { get; set; }
    }

    public class Additional
    {
        public int passes_left { get; set; }
    }

    public class TimeProfiles
    {
        public int count { get; set; }
        public List<object> uid_items { get; set; }
    }
}
