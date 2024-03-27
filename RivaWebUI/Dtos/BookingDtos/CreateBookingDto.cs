using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RivaWebUI.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        [Required(ErrorMessage ="Lütfen İsminizi Yazın✒️")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Telefonunuzu Yazın✒️")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Lütfen Bir Mail Adresi Yazın Yazın✒️")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Lütfen Kaç Kişi Geleceğinizi Yazın✒️")]
        public int PersonCount { get; set; }
        [Required(ErrorMessage = "Lütfen Kaç Saate Geleceğinizi Seçin✒️")]
        public DateTime Date { get; set; }
		public string Description { get; set; }
	}
}
