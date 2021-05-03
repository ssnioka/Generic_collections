using System;
using System.IO;
namespace LABORAS3.Classes
{
    public class Resident : IComparable<Resident>, IEquatable<Resident>, StringFormat
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Month { get; set; }
        public string ServiceId { get; set; }
        public int Amount { get; set; }
        public string Service { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Resident()
        {
    
        }
        /// <summary>
        /// for the service title
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="service"></param>
        public Resident(string name, string surname, string service, string month)
        {
            this.Name = name;
            this.Surname = surname;
            this.Service = service;
            this.Month = month;
        }
        /// <summary>
        /// Constructor for the resident
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="surname">Last Name</param>
        /// <param name="address">Residents address</param>
        /// <param name="month">Month of the payment</param>
        /// <param name="serviceid">Service ID</param>
        /// <param name="serviceamount">Service amount used</param>
        public Resident(string name, string surname, string address, string month, string serviceid, int amount)
        {
            this.Name = name;
            this.Surname = surname;
            this.Address = address;
            this.Month = month;
            this.ServiceId = serviceid;
            this.Amount = amount;

        }
        /// <summary>
        /// Method to format string line
        /// </summary>
        /// <returns>string line</returns>
        public string StringFormat()
        {
            return string.Format("|{0, -12}|{1, -12}|{2, -16}|{3, 10}|{4, 10}|{5, 15}|", "Name", "Surname", "Address", "Month", "ServiceID", "Service Amount");
        }

        /// <summary>
        /// Method to format data
        /// </summary>
        /// <returns>data in the correct format</returns>

        public override string ToString()
        {
            return string.Format("|{0, -12}|{1, -12}|{2, -16}|{3, 10}|{4, 10}|{5, 15}|", this.Name,
                this.Surname, this.Address, this.Month, this.ServiceId, this.Amount);
        }
        /// <summary>
        /// compare to method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Resident other)
        {
            if (other == null)
                return 1;
            if (Address.CompareTo(other.Address) == 0)
            {
                if (Surname.CompareTo(other.Surname) == 0)
                    return Name.CompareTo(other.Name);

                return Surname.CompareTo(other.Surname);
            }

            return Address.CompareTo(other.Address);
        }
        /// <summary>
        /// overrides hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// compares an object to another object
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Resident other)
        {
            if (other == null)
                return false;

            return (Address == other.Address && Surname == other.Surname && Name == other.Name);
        }
        /// <summary>
        /// interface implementation
        /// </summary>
        /// <returns></returns>
        public string Format()
        {
            return string.Format("|{0, -12}|{1, -12}|{2, -16}|{3, 10}|{4, 10}|{5, 15}|", "Name", "Surname", "Address", "Month", "ServiceID", "Service Amount");

        }




    }
}
