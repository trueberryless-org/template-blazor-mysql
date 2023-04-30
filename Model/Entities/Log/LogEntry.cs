using Model.Entities.Authentication;

namespace Model.Entities.Log;

[Table("LOG_ENTRIES")]
public class LogEntry
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("LOG_ID")]
    public int Id { get; set; }
    
    [Required]
    [Column("USER_ID")]
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    [Required]
    [Column("FIELD_TYPE")]
    public ELogEntryType FieldType { get; set; }
    
    [Required]
    [Column("CHANGE_DATE")] 
    public DateOnly DateValue { get; set; }
    
    [Column("OLD_VALUE")]
    public string OldValue { get; set; }
    
    [Column("NEW_VALUE")]
    public string NewValue { get; set; }
}