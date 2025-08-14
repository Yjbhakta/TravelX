using System.ComponentModel.DataAnnotations;

namespace TravelX.Shared.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(256)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;
    
    [Required]
    public UserRole Role { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public UserStatus Status { get; set; } = UserStatus.Pending;
    
    public bool IsEmailVerified { get; set; } = false;
    public string? EmailVerificationToken { get; set; }
    
    // Navigation properties
    public virtual HotelOwnerProfile? HotelOwnerProfile { get; set; }
    public virtual InvestorProfile? InvestorProfile { get; set; }
}

public class HotelOwnerProfile
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
    
    [Required]
    [MaxLength(200)]
    public string CompanyName { get; set; } = string.Empty;
    
    public int NumberOfHotels { get; set; }
    public int TotalRooms { get; set; }
    public decimal AverageDailyRate { get; set; }
    public decimal CurrentOTACommission { get; set; }
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class InvestorProfile
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string InvestmentTier { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string InvestmentExperience { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string PreferredContact { get; set; } = string.Empty;
    
    public decimal AnnualInvestmentBudget { get; set; }
    public decimal InvestmentAmount { get; set; }
    public decimal TravelXTokens { get; set; }
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsApproved { get; set; } = false;
}

public enum UserRole
{
    Admin,
    HotelOwner,
    Investor,
    Traveler
}

public enum UserStatus
{
    Pending,
    Approved,
    Rejected,
    Suspended
}