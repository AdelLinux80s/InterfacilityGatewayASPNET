using System;
using System.ComponentModel.DataAnnotations;

namespace InterfacilityGatewayASPNET.Models
{
    public class ClientReport
    {
        [Display(Name = "Request Number")]
        public int Id { get; set; }

        [Display(Name = "National ID")]
        public int SocialNumber { get; set; }


        public string Nationality { get; set; }
        public string City { get; set; }

        [Display(Name = "Referred From")]
        public string ReferringFacility { get; set; }


        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        [Display(Name = "Contact 1")]
        public string Phone1 { get; set; }

        [Display(Name = "Contact 2")]
        public string Phone2 { get; set; }


        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        //[DataType(DataType.DateTime), Required]
        //[DisplayFormat(DataFormatString = "yyyy/MM/dd", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "MRN")]
        public int MedicalRecordNumber { get; set; }
        //public bool EligibilityStatus { get; set; }


        //public EligibilityStatus EligibilityStatus { get; set; }

        [Display(Name = "Eligibility Status")]
        public byte EligibilityStatusId { get; set; }



        [Display(Name = "Request Date")]
        public DateTime? RequestDate { get; set; }


        [Display(Name = "Urgency")]
        public Category Category { get; set; }

        [Display(Name = "Category")]
        public byte CategoryId { get; set; }
        // public RequestStatus RequestStatus { get;set; }
        //public DateTime ElapsedTime { get; set; }

        public byte RequestStatusId { get; set; }

        public int HandlerTransferRequestId { get; set; }
    }
}