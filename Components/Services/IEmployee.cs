using MUDCRUD.Components.Domain;
namespace MUDCRUD.Components.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Contracts.EmployeeContract>> GetAllEmployeesAsync();
        Task<Contracts.EmployeeContract> GetEmployeeByIdAsync(Guid id);
        Task CreateEmployeeAsync(Contracts.CreateEmployeeContract contract);
        Task UpdateEmployeeAsync(Contracts.UpdateEmployeeContract contract);
        Task DeleteEmployeeAsync(Guid id);
    }

}
