namespace ML.WorkShop.DAL.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        public Guid Id { get; set; }

        public bool? Administrator { get; set; }

        public bool? Member { get; set; }

        public bool? Lock { get; set; }

        public DateTime CreateDateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string CreateUserId { get; set; }

        public DateTime? LastModifyDateTime { get; set; }

        [StringLength(50)]
        public string LastModifyUserId { get; set; }

        public string Remark { get; set; }

        public virtual Identity Identity { get; set; }
    }
}
