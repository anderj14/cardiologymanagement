namespace Core.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string CarnetIdentification { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public long NoMedicare { get; set; }
    }
}