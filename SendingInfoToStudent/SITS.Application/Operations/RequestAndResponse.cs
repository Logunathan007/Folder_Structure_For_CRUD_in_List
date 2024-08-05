using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SITS.Application.Models;
using SITS.Domain.Entities;
using SITS.Persistence.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS.Application.Operations
{
    public interface IRequestAndResponse
    {
        public IEnumerable<StudentCombained> getAllData();
        public StudentCombained AddNewData(StudentCombained studentCombained);
    }
    public class RequestAndResponse : IRequestAndResponse
    {
        private IValidator<Student> _stdValidator;
        private IValidator<StudentDetail> _stdDetValidator;
        private MakeConnection _conn;
        private IMapper _mapper;
        public RequestAndResponse(MakeConnection conn, IMapper mapper, IValidator<StudentDetail> stdDetValidator, IValidator<Student> stdValidator)
        {
            _conn = conn;
            _mapper = mapper;
            _stdDetValidator = stdDetValidator;
            _stdValidator = stdValidator;
        }
        public IEnumerable<StudentCombained> getAllData()
        {
            List<StudentCombained> listStud = new List<StudentCombained>();
            var res = _conn.Students.Include(std=>std.studentDetails).ToList();
            foreach (var student in res)
            {
                StudentCombained stdCom = _mapper.Map<StudentCombained>(student.studentDetails);
                stdCom.Name = student.Name;
                listStud.Add(stdCom);
            }
            return listStud;
        }
        public StudentCombained AddNewData(StudentCombained studentCombained)
        {
            Guid randId = Guid.NewGuid(); 

            Student student = _mapper.Map<Student>(studentCombained);
            student.StudentId = randId;
            var res = _stdValidator.Validate(student);
            if ((res.Errors).Count != 0)
                throw (new Exception(string.Join(",",res.Errors)));

            StudentDetail studentDetail = _mapper.Map<StudentDetail>(studentCombained);
            studentDetail.StudentId = randId;
            res = _stdDetValidator.Validate(studentDetail);
            if ((res.Errors).Count != 0)
                throw (new Exception(string.Join(",", res.Errors)));

            _conn.Students.Add(student);
            _conn.StudentDetails.Add(studentDetail);
            _conn.SaveChanges();
            return studentCombained;
        }
    }
}
