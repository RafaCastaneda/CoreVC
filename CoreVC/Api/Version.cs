using System.Runtime.Serialization;

namespace CoreVC.Api
{
    [DataContract]
    public class Version
    {
        [DataMember(Name = "major")]
        public int Major { get; set; }

        [DataMember(Name = "minor")]
        public int Minor { get; set; }

        [DataMember(Name = "build")]
        public int Build { get; set; }

        public override string ToString() =>
            $"{Major}.{Minor}.{Build}";
    }
}
