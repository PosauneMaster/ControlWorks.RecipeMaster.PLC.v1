namespace ControlWorks.RecipeMaster.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Template")]
    public partial class Template
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TemplateId { get; set; }

        [StringLength(50)]
        public string TemplateName { get; set; }

        public string TemplateDescription { get; set; }

        public int? VariableId { get; set; }
    }
}
