
namespace CoreVC.Api
{
    public class Version
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }

        public override string ToString() =>
            $"{Major}.{Minor}.{Build}";
    }
}
