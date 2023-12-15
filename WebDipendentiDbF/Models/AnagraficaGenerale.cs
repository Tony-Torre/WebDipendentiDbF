using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebDipendentiDbF.Models;

public partial class AnagraficaGenerale
{
    [Key]
    [RegularExpression(@"[A-Z]{1}\d{3}$", ErrorMessage ="La matricola deve essere composta da una lettera e 3 numeri")]
    [StringLength(4, ErrorMessage ="Deve essere lunga 4 caratteri")]
    public string Matricola { get; set; } = null!;

    [Required(ErrorMessage = "Il parametro deve essere inserito")]
    [MinLength(3, ErrorMessage ="Il nominativo deve essere lungo almeno 3 caratteri")]
    [MaxLength (20, ErrorMessage ="Il nominativo deve essere lungo massimo 20 caratteri") ]
    public string? Nominativo { get; set; }

    [Required(ErrorMessage = "Il parametro deve essere inserito")]
    [MinLength(3, ErrorMessage = "Il ruolo deve essere lungo almeno 3 caratteri")]
    [MaxLength(20, ErrorMessage = "Il ruolo deve essere lungo massimo 20 caratteri")]
    public string? Ruolo { get; set; }

    [Required(ErrorMessage = "Il parametro deve essere inserito")]
    [MinLength(3, ErrorMessage = "Il reparto deve essere lungo almeno 3 caratteri")]
    [MaxLength(20, ErrorMessage = "Il reparto deve essere lungo massimo 20 caratteri")]
    public string? Reparto { get; set; }

    [Range(18, 90 , ErrorMessage ="L'età deve essere compresa tra 18 e 90") ]
    public int? Eta { get; set; }

    [MinLength(3, ErrorMessage = "L'indirizzo deve essere lungo almeno 3 caratteri")]
    [MaxLength(20, ErrorMessage = "L'indirizzo deve essere lungo massimo 20 caratteri")]
    public string? Indirizzo { get; set; }

    [MinLength(3, ErrorMessage = "Il nome della città deve essere lungo almeno 3 caratteri")]
    [MaxLength(20, ErrorMessage = "Il nome della città deve essere lungo massimo 20 caratteri")]
    public string? Citta { get; set; }

    [MinLength(2, ErrorMessage = "La provincia deve essere lunga almeno 2 caratteri")]
    [MaxLength(4, ErrorMessage = "La provincia deve essere lunga massimo 4 caratteri")]
    public string? Provincia { get; set; }

    [StringLength (5)]
    public string? Cap { get; set; }

    //[RegularExpression(@"[1-9]{10}$", ErrorMessage ="Il campo deve essere composto da numeri")]
    [MinLength (8)]
    public string? Telefono { get; set; }

    public virtual ICollection<AttivitaDipendente> AttivitaDipendentes { get; set; } = new List<AttivitaDipendente>();
}
