namespace ML.WorkShop.DAL.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Identity")]
    public partial class Identity
    {
        [Key]
        public Guid Member_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public DateTime CreateDateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string CreateUserId { get; set; }

        public DateTime? LastModifyDateTime { get; set; }

        [StringLength(50)]
        public string LastModifyUserId { get; set; }

        public string Remark { get; set; }

        public virtual Member Member { get; set; }

        public virtual Role Role { get; set; }
    }
}
