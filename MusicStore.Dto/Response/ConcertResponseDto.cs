using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Dto.Response
{
    public class ConcertResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Place { get; set; } = default!;
        public decimal UnitPrice { get; set; }
        public int GenreId { get; set; }

        //Actualizo los siguientes campos de acuerdo a carpeta Info
        public string GenreName { get; set; } = default!;

        public string DateEvent { get; set; } = default!;
        public string TimeEvent { get; set; } = default!;

        public string? ImageUrl { get; set; }
        public int TicketsQuantity { get; set; }
        public bool Finalized { get; set; }
        public string Status { get; set; } = default!;

    }
}
