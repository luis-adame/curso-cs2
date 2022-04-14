using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartments();
        public Department GetDepartment(int id);
        public List<Subdepartment> GetSubdepartments(string departmentName);
    }
}
