namespace MusicStore.Entities;


public class Genre
{
    public int Id{ get; set; }
    public String Name { get; set; } = default!;
    public bool Status { get; set; } = true;//todo bool se inciializa en False a menos que se indique lo contrario como aqui

}

