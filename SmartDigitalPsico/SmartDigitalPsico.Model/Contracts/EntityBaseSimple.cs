using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using SmartDigitalPsico.Model.Contracts.Interface;

namespace SmartDigitalPsico.Model.Contracts
{
    public abstract class EntityBaseSimple : IEntityBaseLog
    {
        [Column("Id", Order = 0)]
        public long Id { get; set; }

        [Column("Enable", Order = 1)]
        [DefaultValue(true)] 
        public bool? Enable { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("ModifyDate")]
        public DateTime ModifyDate { get; set; }

        [Column("LastAccessDate")]
        public DateTime LastAccessDate { get; set; }
    }
}
