namespace BackendFirstStage.Domain.Entities.Seedwork;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    //public int? CreatedBy { get; set; }
    //public int? UpdatedBy { get; set; }
    //public int? DeletedBy { get; set; }

    public BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
        IsDeleted = false;
    }
}

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    //public T CreatedBy { get; set; }
    //public T? UpdatedBy { get; set; }
    //public T? DeletedBy { get; set; }

    public BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
        IsActive = true;
        IsDeleted = false;
    }

}
