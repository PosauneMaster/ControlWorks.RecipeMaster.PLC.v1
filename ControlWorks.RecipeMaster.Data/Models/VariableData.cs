namespace ControlWorks.RecipeMaster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VariableData")]
    public partial class VariableData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VariableDataId { get; set; }

        public int VariableId { get; set; }

        [Required]
        [StringLength(50)]
        public string Value { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual Variable Variable { get; set; }
    }
}
