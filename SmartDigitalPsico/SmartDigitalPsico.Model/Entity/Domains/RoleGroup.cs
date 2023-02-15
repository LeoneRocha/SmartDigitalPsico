using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Model.Entity.Domains
{
    public class RoleGroup : EntityBaseSimple
    { 
        public List<User> Users { get; set; }
    }
}