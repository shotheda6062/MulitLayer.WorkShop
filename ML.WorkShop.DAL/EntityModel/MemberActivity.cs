namespace ML.WorkShop.DAL.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberActivity")]
    public partial class MemberActivity
    {
        public Guid Id { get; set; }

        public Guid Member_Id { get; set; }

        public DateTime? LoginDateTime { get; set; }

        public DateTime? LastModifyPasswordDate { get; set; }

        public string Remark { get; set; }

        public virtual Member Member { get; set; }
    }
}
