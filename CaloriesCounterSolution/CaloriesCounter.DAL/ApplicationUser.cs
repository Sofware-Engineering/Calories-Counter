using Microsoft.AspNetCore.Identity;
using System.Reflection;
using CaloriesCounter.Core.Models;

public class ApplicationUser : IdentityUser
{
    public int Age { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public Gender Gender { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
    public Goal Goal { get; set; }
    public bool IsApproved { get; set; }

}