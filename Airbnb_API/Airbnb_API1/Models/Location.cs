namespace Airbnb_API1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            Images = new HashSet<Image>();
        }

        [Key]
        public int Loc_ID { get; set; }

        [Required]
        public int Location_Number { get; set; }

        [Required]
        [StringLength(50)]
        public string Loc_address { get; set; }

        [StringLength(1000)]
        public string Location_Des { get; set; }

        public int Location_Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Loc_type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Loc_startdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Loc_enddate { get; set; }

        public int Location_IS_Reserved { get; set; }

        public decimal? Loc_longtiute { get; set; }

        public decimal? Loc_latitude { get; set; }

        public int? User_ID { get; set; }

        public int? City_ID { get; set; }

        public int? Country_ID { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }

        public virtual User User { get; set; }
    }
}
