namespace ControlWorks.RecipeMaster.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ControlWorksContext : DbContext
    {
        public ControlWorksContext()
            : base("name=ControlWorksContext1")
        {
        }

        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<Variable> Variables { get; set; }
        public virtual DbSet<VariableData> VariableDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>()
                .HasMany(e => e.Variables)
                .WithRequired(e => e.Machine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Variable>()
                .HasMany(e => e.VariableDatas)
                .WithRequired(e => e.Variable)
                .WillCascadeOnDelete(false);
        }
    }
}
