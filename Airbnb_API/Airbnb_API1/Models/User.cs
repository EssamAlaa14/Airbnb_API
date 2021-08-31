namespace Airbnb_API1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Locations = new HashSet<Location>();
        }

        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string User_Fname { get; set; }

        [StringLength(50)]
        public string User_Lname { get; set; }

        public int? Age { get; set; }

        [Required]
        [StringLength(100)]
        public string User_Email { get; set; }

        [Required]
        [StringLength(50)]
        public string User_Password { get; set; }

        [StringLength(50)]
        public string User_Phone { get; set; }

        [StringLength(50)]
        public string User_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location> Locations { get; set; }
    }
}
