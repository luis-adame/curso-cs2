using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Department
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Subdepartment> Subdepartments { get; set; }
        private static int idSeed = 1;

        public Department(string name, List<Subdepartment> subdepartments)
        {
            if (string.IsNullOrEmpty(name) == null)
                throw new ArgumentNullException("El nombre no puede estar vacio");

            if (subdepartments == null || !subdepartments.Any())
            {
                throw new InvalidOperationException("El Departamento necesita subdepartamentos");
            }

            Name = name;
            Subdepartments = subdepartments;
            Id = idSeed++;
        }
    }
}
