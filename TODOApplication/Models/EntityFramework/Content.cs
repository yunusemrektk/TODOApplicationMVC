//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TODOApplication.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Content
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Display(Name = "Event Content")]
        [Required(ErrorMessage = "Please fill the event box")]
        public string Message { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please select a date for upcoming event")]
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual Kullanici Kullanici { get; set; }
    }
}
