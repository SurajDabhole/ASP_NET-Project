using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Person
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
}
