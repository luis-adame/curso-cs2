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
		private List<Department> DepartmentList = TestData.GetDepartmentData();

		public List<Department> GetDepartments()
        {
			return DepartmentList;
        }

		public Department GetDepartment(int id)
		{
			return DepartmentList.FirstOrDefault(x => x.Id == id);
		}

		public Subdepartment GetSubdepartment(int id)
        {
			return DepartmentList.SelectMany(x => x.Subdepartments).Where(x => x.Id == id).FirstOrDefault();
        }

		public List<Subdepartment> GetSubdepartments()
		{
			return DepartmentList.SelectMany(x => x.Subdepartments).ToList();
		}

		public List<Subdepartment> GetSubdepartments(int id)
		{
			var department = DepartmentList.FirstOrDefault(c => c.Id == id);

			if (department != null)
				return department.Subdepartments;

			return new List<Subdepartment>();
		}
	}
}
