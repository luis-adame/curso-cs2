using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
		private List<Department> DepartmentList = TestData.DepartmentList;

		public List<Department> GetDepartments()
        {
			return DepartmentList;
        }

		public Department GetDepartment(int id)
		{
			return DepartmentList.FirstOrDefault(x => x.Id == id);
		}

		public List<Subdepartment> GetSubdepartments(string departmentName)
		{
			var department = DepartmentList.FirstOrDefault(c => c.Name == departmentName);

			if (department != null)
				return department.Subdepartments;

			return new List<Subdepartment>();
		}

		public List<Subdepartment> GetSubdepartments()
        {
			return DepartmentList.SelectMany(x => x.Subdepartments).ToList();
		}
	}
}
