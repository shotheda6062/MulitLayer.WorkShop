namespace ML.WorkShop.DAL.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberLog")]
    public partial class MemberLog
    {
        public Guid Id { get; set; }

        public Guid Member_Id { get; set; }

        public int WorkId { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? CreateDateTime { get; set; }

        [StringLength(50)]
        public string CreateUserId { get; set; }

        public DateTime? LastModifyDateTime { get; set; }

        [StringLength(50)]
        public string LastModifyUserId { get; set; }

        public DateTime? DeleteDateTime { get; set; }

        [StringLength(50)]
        public string DeleteUserId { get; set; }

        public string Remark { get; set; }
    }
}
