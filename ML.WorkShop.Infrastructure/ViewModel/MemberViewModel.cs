using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ML.WorkShop.Infrastructure
{
    public class MemberViewModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string CompanyId { get; set; }

        [Required]
        public int WorkId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public DateTime CreateDateTime { get; set; }

        [Required]
        [StringLength(10)]
        public string CreateUserId { get; set; }

        public DateTime? LastModifyDateTime { get; set; }

        [StringLength(50)]
        public string LastModifyUserId { get; set; }

        public DateTime? LoginDateTime { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}
