using AutoMapper;
using List.Domain.Entities;
using List.Persistence.Contexts;
using List.Application.Employees.Models;

namespace List.Application.Employees.Services
{
    public interface IOperations
    {
        List<EmployeeDTO> GetAll();
        EmployeeDTO GetById(Guid id);
        bool AddNew(EmployeeDTO employeeDTO);
        bool DeleteById(Guid id);
        EmployeeDTO UpdateById(Guid id, EmployeeDTO eDTO);
    }
    public class Operations : IOperations
    {
        LOEs loes;
        IMapper mapper;

        public Operations(LOEs loe, IMapper mapper)
        {
            loes = loe;
            this.mapper = mapper;
        }
        public List<EmployeeDTO> GetAll()
        {
            List<Employee> list = loes.getListOfEmployees();
            List<EmployeeDTO> listDTO = new List<EmployeeDTO>();

            foreach (var item in list)
            {
                listDTO.Add(mapper.Map<EmployeeDTO>(item));
            }
            return listDTO;
        }
        public EmployeeDTO GetById(Guid id)
        {
            Employee emp = loes.getListOfEmployees().Find(e => e.Id == id);
            if (emp == null)
            {
                return null;
            }
            EmployeeDTO eDTO = mapper.Map<EmployeeDTO>(emp);
            return eDTO;
        }
        public bool AddNew(EmployeeDTO employeeDTO)
        {
            Employee emp = mapper.Map<Employee>(employeeDTO);
            loes.getListOfEmployees().Add(emp);
            return true;
        }
        public bool DeleteById(Guid id)
        {
            Employee emp = loes.getListOfEmployees().Find(e => e.Id == id);
            if (emp == null)
            {
                return false;
            }
            loes.getListOfEmployees().Remove(emp);
            return true;
        }
        public EmployeeDTO UpdateById(Guid id, EmployeeDTO eDTO)
        {
            Employee emp = loes.getListOfEmployees().Find(e => e.Id == id);
            if (emp == null)
            {
                return null;
            }
            Employee empUp = mapper.Map<Employee>(eDTO);
            loes.getListOfEmployees().Remove(emp);
            loes.getListOfEmployees().Add(empUp);
            return eDTO;
        }
    }
}
