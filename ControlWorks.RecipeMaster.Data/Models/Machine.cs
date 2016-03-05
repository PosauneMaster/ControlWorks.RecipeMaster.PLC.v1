namespace ControlWorks.RecipeMaster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Machine")]
    public partial class Machine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Machine()
        {
            Variables = new HashSet<Variable>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MachineId { get; set; }

        public int? PviId { get; set; }

        [StringLength(100)]
        public string MachineName { get; set; }

        public string MachineDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Variable> Variables { get; set; }
    }
}
