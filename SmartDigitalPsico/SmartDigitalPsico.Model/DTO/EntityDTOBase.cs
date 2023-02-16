namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityDTOBase
    {
        public int Id { get; set; }
         
        public string Name { get; set; }
         
        public string Email { get; set; }

        public bool Enable { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModify { get; set; }

        public DateTime DateLasAcess { get; set; }

    }
}