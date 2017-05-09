using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.ModelLayer
{
    public class Unit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SerialNo { get; set; }
        public int RessourceId { get; set; }
        [ForeignKey("RessourceId")]
        public Ressource Ressource { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
