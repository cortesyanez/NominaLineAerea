using System.ComponentModel.DataAnnotations;

namespace NominaLinAerea.Models
{
    public class modeloTrabajadores
    {

        public Int16 IdEmp_mod {  get; set; }
        [Required(ErrorMessage = "El ID del trabajador es necesario")]
        public string NomEmp_mod { get; set; }
        [Required(ErrorMessage = "Es necesario el nombre del trabajador")]
        public string ApaEmp_mod { get; set; }
        [Required(ErrorMessage = "Es necesario el apellido paterno del trabajador")]
        public string SexEmp_mod { get; set; }
        [Required(ErrorMessage = "Es necesario el sexo correspondiente al trabajador")]
        public DateTime FNaEmp_mod { get; set; }
        [Required(ErrorMessage = "Se requiere la fecha de nacimiento del trabajador")]
        public Int16 IdBar_mod { get; set; }
        [Required(ErrorMessage = "El ID del barrio del trabajador es necesario")]
        public Int16 IdPue_mod { get; set; }
        [Required(ErrorMessage = "El ID del puesto del trabajador es necesario")]
        public Int16 IdTipTra_mod { get; set; }
        [Required(ErrorMessage = "El ID del tipo de trabajo del trabajador es necesario")]
        public Int16 tipOper_mod { get; set; }


    }
}
