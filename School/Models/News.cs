//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  public partial class News
  {
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Event { get; set; }

    [Required]
    [StringLength(250)]
    public string Description { get; set; }
  }
}
