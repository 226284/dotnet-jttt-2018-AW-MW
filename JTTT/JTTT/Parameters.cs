using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Parameters
    {
        public int Id { get; set; }
        // img - send parameters
        public Url Url { get; set; }
        public Key Key { get; set; }
        public Mail Mail { get; set; }
        // weather
        public City City { get; set; }
        public Temperature Temperature { get; set; }
        [NotMapped]
        public string Description { get; set; }


        public Parameters()
        {
            Url = new Url();
            Key = new Key();
            Mail = new Mail();
            City = new City();
            Temperature = new Temperature();
        }

        public override string ToString()
        {
            return String.Format("Url: {0} Key: {1} Mail: {2} City: {3} Temperature: {4} Opis: {5}", Url.Address, Key.Name, Mail.Address, City.Name, Temperature.Value, Description);
        }
    }
}
