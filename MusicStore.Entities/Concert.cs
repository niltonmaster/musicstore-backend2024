using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Entities
{
    public class Concert : EntityBase
    {
        //public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Place { get; set; } = default!;
        public decimal UnitPrice { get; set; }
        public int GenreId { get; set; }
        public DateTime DateEvent { get; set; }
        public string? ImageUrl { get; set; }
        public int TicketsQuantity { get; set; }
        public bool Finalized { get; set; }
        //public  bool Status { get; set; } = true;


        //propiedadesd e navegacion: es la rlacion entre objetos. 1 concierto solo tiene un genero.y un genero puede esstar en muchos conciertos
        public virtual Genre Genre { get; set; } = default!;

    }
}
