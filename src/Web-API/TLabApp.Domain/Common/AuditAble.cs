namespace TLabApp.Domain.Common;

public abstract class AuditAble
{
    public AuditAble()
    {
        CreateBy = "Admin";
        CreateOn = DateTime.Now;

    }

    public string? CreateBy { get; set; }
    public DateTime? CreateOn { get; set; }

    public string? UpdateBy { get; set; }
    public DateTime? UpdateOn { get; set; }

    public bool IsDeleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
}