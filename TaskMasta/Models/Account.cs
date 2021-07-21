using System;
using System.Collections.Generic;

namespace TaskMasta.Models
{
    public class Account : Profile
    {
public DateTime CreatedAt {get;set;}  
public DateTime UpdatedAt {get; set;}      
public string Email { get; set; }
    }
}