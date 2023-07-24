namespace Model.Entities.Email;

[Table("EMAIL_TEMPLATES")]
public class EmailTemplate
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TEMPLATE_TYPE")] 
    public TemplateType TemplateType { get; set; }

    [Column("SUBJECT")]
    public string Subject { get; set; }
    
    [Column("PATH_TO_BODY")]
    public string PathToBody { get; set; }
    
    [NotMapped]
    public string Body { get; set; }
}