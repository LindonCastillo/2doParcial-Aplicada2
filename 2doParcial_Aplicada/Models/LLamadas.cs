using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _2doParcial_Aplicada.Models
{
    public class LLamadas
    {
        [Key]
        public int LlamadaId { get; set; }
        [Required(ErrorMessage = "No se puede dejar el campo Descripción vacío")]
        [StringLength(maximumLength:100,ErrorMessage ="La Descripción es muy larga")]
        public string Descripcion { get; set; }

        [ForeignKey("LlamadaId")]
        public virtual List<LLamadasDetalle> Detalle { get; set; }

        public LLamadas()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;

            Detalle = new List<LLamadasDetalle>();
        }
    }
}
