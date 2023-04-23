namespace Model.Entities.Authentication;

[Table("USERS")]
public class User {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("USER_ID")]
    public int Id { get; set; }

    [Required]
    [Column("USERNAME")]
    public string Username { get; set; } = null!;

    [Required]
    [DataType(DataType.EmailAddress)]
    [Column("EMAIL")]
    public string Email { get; set; } = null!;


    [Required]
    [DataType(DataType.Text)]
    [Column("PASSWORD_HASH")]
    public string PasswordHash { get; set; } = null!;

    [Required]
    [NotMapped]
    public string LoginPassword { get; set; } = null!;
    
    public List<RoleClaim> RoleClaims { get; set; }

    [NotMapped] 
    public IEnumerable<string> PlainRoles => RoleClaims.Select(x => x.Role.Identifier);
    
    public User ClearSensitiveData() {
        // PasswordHash = null!;
        return this;
    }

    public static string HashPassword(string plainPassword) {
        var salt = BC.GenerateSalt(8);
        return BC.HashPassword(plainPassword, salt);
    }

    public static bool VerifyPassword(string plainPassword, string hashedPassword) {
        return BC.Verify(plainPassword, hashedPassword);
    }

    public User Clone()
    {
        return new User()
        {
            Id = this.Id,
            Username = this.Username,
            Email = this.Email
        };
    }
}