namespace ControlWorks.RecipeMaster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Variable")]
    public partial class Variable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Variable()
        {
            VariableDatas = new HashSet<VariableData>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VariableId { get; set; }

        [StringLength(50)]
        public string VariableName { get; set; }

        public int MachineId { get; set; }

        public int? TemplateId { get; set; }

        public virtual Machine Machine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VariableData> VariableDatas { get; set; }
    }
}
