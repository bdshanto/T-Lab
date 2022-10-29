namespace TLabApp.Domain.Common;

public abstract class AuditAble
{

    public string CreateBy { get; set; }
    public DateTime CreateOn { get; set; }
    public string UpdateBy { get; set; }
    public DateTime UpdateOn { get; set; }
}