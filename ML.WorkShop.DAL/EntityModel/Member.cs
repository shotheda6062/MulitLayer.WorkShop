namespace ML.WorkShop.DAL.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Member")]
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            MemberActivity = new HashSet<MemberActivity>();
        }

        public Guid Id { get; set; }

        public int WorkId { get; set; }

        public Guid CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime CreateDateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string CreateUserId { get; set; }

        public DateTime? LastModifyDateTime { get; set; }

        [StringLength(50)]
        public string LastModifyUserId { get; set; }

        public string Remark { get; set; }

        public virtual CompanyConfing CompanyConfing { get; set; }

        public virtual Identity Identity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberActivity> MemberActivity { get; set; }
    }
}
