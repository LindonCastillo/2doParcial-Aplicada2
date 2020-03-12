using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2doParcial_Aplicada.Models
{
    public class LLamadasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int LlamadaId { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LLamadasDetalle()
        {
            Id = 0;
            LlamadaId = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }
    }
}
