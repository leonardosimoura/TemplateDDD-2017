using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.Domain.Entidade;

namespace TemplateDDD.Repository.EF.Metadata
{
    public class UsuarioMetadata : EntityTypeConfiguration<Usuario>
    {
        [Key]
        public int IdUsuario { get; set; }
        [StringLength(maximumLength:250)]
        [Required]
        public string Nome { get; set; }
        public UsuarioMetadata()
        {
            //HasKey(c => c.IdUsuario);
            //Property(c => c.Nome).HasMaxLength(250).IsRequired();
        }
    }
}
