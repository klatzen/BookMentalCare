using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMentalCareCore.ModelLayer
{
    public class Ressource
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public List<Unit> units { get; set; }
    }
}
