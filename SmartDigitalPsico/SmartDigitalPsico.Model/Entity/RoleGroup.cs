namespace SmartDigitalPsico.Model.Entity
{
    public class RoleGroup
    {
        public int Id { get; set; }

        public string Description { get; set; }


        public List<User> Users { get; set; }
    }
}