using System.ComponentModel.DataAnnotations;
using System.Web;

namespace InterfacilityGatewayASPNET.dto
{
    public class FileDto
    {
        [Required]
        //[DataType(DataType.Upload)]
        [Display(Name = "Upload Medical Report")]
        public HttpPostedFileBase FileDtoHttpPostedFileBaseFile { get; set; }

        public int FileDtoId { get; set; }
        public string FileDtoFileName { get; set; }
        public byte[] FileDtoFileContent { get; set; }
    }
}