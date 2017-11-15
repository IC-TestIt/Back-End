using System;

namespace TestIt.Model
{
    public interface IEntityBase
    {
        int Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
    }
}
