using System;
using System.Collections.Generic;
using System.Text;

namespace Entities-DTOS
{
    public class Movie : BaseDTO
{
    public string Title { get; set; }
    public string Synopsis { get; set; }
    public string Gender { get; set; }
    public TimeSpan Duration { get; set; }

    public string Clasificacion { get; set; }

    public string Image { get; set; }
    public string Status { get; set; }
}
}
