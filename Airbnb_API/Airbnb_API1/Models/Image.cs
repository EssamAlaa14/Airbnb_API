namespace Airbnb_API1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Img_ID { get; set; }

        [Column("Image")]
        [Required]
        public byte[] Image1 { get; set; }

        public int Loc_Id { get; set; }

        public int User_id { get; set; }

        public virtual Location Location { get; set; }
    }
}
