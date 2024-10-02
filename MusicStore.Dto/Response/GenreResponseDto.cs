using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Dto.Response
{
    public class GenreResponseDto
    {

        public int Id { get; set; }
        public String Name { get; set; } = default!;
        public bool Status { get; set; } = true;//todo bool se inciializa en False a menos que se indique lo contrario como aqui

    }
}
