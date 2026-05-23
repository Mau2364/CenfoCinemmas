using System;
using System.Collections.Generic;
using System.Text;

namespace Entities-DTOS
{
    internal class Ticket
{
    public double Price { get; set; }
    
    public TimeSpan Schedule {  get; set; }// para decir a que hora es la peli, TimeSpan Guarda solo duración/hora relativa
    public DateTime Date { get; set; }
    public string Type { get; set; } // adult, kids
    public Movie Movie { get; set; }
}
}
