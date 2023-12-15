using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebDipendentiDbF.Validations;
namespace WebDipendentiDbF.Models;

public partial class AttivitaDipendente
{
    
    [Key]
    public int Id { get; set; }

    [Required (ErrorMessage = "Il parametro deve essere inserito")]
    [PreviousDate]
    public DateTime? DataAttivita { get; set; }

    [Required(ErrorMessage = "Il parametro deve essere inserito")]
    [MinLength(3, ErrorMessage = "L'attività deve essere lunga almeno 3 caratteri")]
    [MaxLength(20, ErrorMessage = "L'attività deve essere lunga massimo 20 caratteri")]
    public string? Attivita { get; set; }

    [Required(ErrorMessage = "Il parametro deve essere inserito")]
    [Range(1,24, ErrorMessage = "Deve essere compreso tra 1 e 24")]
    [RegularExpression(@"^\d+(.\d{1,2})?$")]
    public decimal? Ore { get; set; }

    [Required(ErrorMessage = "Il parametro deve essere inserito")]
    public string Matricola { get; set; } = null!;

    public virtual AnagraficaGenerale? MatricolaNavigation { get; set; } = null;
}
