using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Provider
    {
		public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; private set; }
        public string City { get; set; }

		public Provider(int id, string name, string emailAddress)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("El nombre no puede ser vacio");

			if (string.IsNullOrEmpty(emailAddress))
				throw new ArgumentNullException("El nombre no puede ser vacio");

			try
			{
				var email = new System.Net.Mail.MailAddress(emailAddress);
				EmailAddress = email.Address;
			}
			catch (FormatException)
			{
				throw new ArgumentNullException("El correo es invalido");
			}

			Name = name;
			Id = id;
		}

		public void AddAddress(string street, string city)
        {

        }

		public void AddPhoneNumber(string phoneNumber)
		{
			if (string.IsNullOrEmpty(phoneNumber))
				throw new ArgumentNullException("El numero de telefono no puede ser vacio");

			if (phoneNumber.Length < 10)
				throw new FormatException("El telefono tiene que tener al menos 10 caracteres");

			PhoneNumber = phoneNumber;
		}
	}
}
