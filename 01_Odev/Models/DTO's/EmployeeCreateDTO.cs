using System.ComponentModel.DataAnnotations;

namespace Odev1.Models.DTO_s
{
    public class EmployeeCreateDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Isim Zorunludur!")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Soyisim Zorunludur!")]
        public string LastName { get; set; }
    }
}
