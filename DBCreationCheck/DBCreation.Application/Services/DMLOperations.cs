using AutoMapper;
using DBCreation.Application.Models;
using DBCreation.Domain.Entities;
using DBCreation.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCreation.Application.Services
{
    public interface IOperations
    {
        public List<StudentDTO> GetAll();
        public StudentDTO GetById(int id);
        public StudentDTO AddNew(StudentDTO stdDTO);
        public StudentDTO UpdateById(int id, StudentDTO stdDTO);
        public StudentDTO DeleteById(int id);
    }
    public class DMLOperations : IOperations
    {
        IMapper mapper;
        private readonly MakeConnections conn;

        public DMLOperations(IMapper _mapper, MakeConnections dbcontext)
        {
            conn = dbcontext;
            mapper = _mapper;
            Console.WriteLine("DMLOperations is worked");
        }
        public void print(StudentDTO stdDTO)
        {

        }
        public List<StudentDTO> GetAll()
        {
            List<StudentDTO> listDTO = new List<StudentDTO>();
            foreach (Student student in conn.Students.ToList())
            {
                listDTO.Add(mapper.Map<StudentDTO>(student));
            }
            return listDTO;
        }
        public StudentDTO GetById(int id)
        {
            Student std = conn.Students.ToList().Find(e => id == e.Id);
            if (std == null)
                return null;
            return mapper.Map<StudentDTO>(std);
        }
        public StudentDTO AddNew(StudentDTO stdDTO)
        {
            Student std = mapper.Map<Student>(stdDTO);
            conn.Students.Add(std);
            conn.SaveChanges();
            return stdDTO;
        }
        public StudentDTO UpdateById(int id,StudentDTO stdDTO)
        {
            Student std = conn.Students.Find(id);
            if (std == null)
                return null;
            std.Name = stdDTO.Name;
            std.Mark = stdDTO.Mark;
            std.Department = stdDTO.Department;
            conn.SaveChanges();
            return mapper.Map<StudentDTO>(std);
        }
        public StudentDTO DeleteById(int id)
        {
            Student std = conn.Students.ToList().Find(e => id == e.Id);
            if (std == null)
                return null;
            conn.Students.Remove(std);
            conn.SaveChanges();
            return mapper.Map<StudentDTO>(std);
        }
    }
}
