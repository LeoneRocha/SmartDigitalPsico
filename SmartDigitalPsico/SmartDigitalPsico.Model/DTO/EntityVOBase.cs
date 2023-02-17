namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityVOBase
    {
        public long Id { get; set; }
         
        public string Name { get; set; }
         
        //public string Email { get; set; }

        public bool Enable { get; set; } 
    }
}