namespace SmartDigitalPsico.Model.Dto.User
{
    public class UpdateUserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; }
        public string Email { get; set; }
    }
}