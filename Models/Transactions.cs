using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransactions.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }
        [Column(TypeName ="nvarchar(12)")]
        [DisplayName("Account Number")]
        [Required(ErrorMessage ="This Field is Required")]
        [MaxLength(12, ErrorMessage ="Maximum character is 12")]
        public string AccountNUmber { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        [DisplayName("Beneficiary Name")]
        [Required(ErrorMessage = "This Field is Required")]
        public string BeneficiaryName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Bank Name")]
        [Required(ErrorMessage = "This Field is Required")]
        public string BankName { get; set; }
        [Column(TypeName ="nvarchar(11)")]
        [DisplayName("SWIFT Code")]
        [Required(ErrorMessage = "This Field is Required")]
        [MaxLength(11, ErrorMessage = "Maximum number character is 11")]
        public string SWIFTCode { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString ="{0:MM-dd-yyyy}")]
        public DateTime Date { get; set; }
    }
}
