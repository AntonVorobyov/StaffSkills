using System;

namespace StaffSkills.Domain.Repository.Contract
{
    public interface IContextFactory : IDisposable
    {
        object Get();
    }
}