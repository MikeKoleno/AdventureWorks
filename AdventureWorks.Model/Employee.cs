using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Model
{
    public enum Sex {  Male = 0, Female = 1 };
    public enum MaritalStatus { Single = 0, Married = 1 };

    [Serializable]
    [DataContract]
    public class Employee
    {
        private int id;
        private string nationalID;
        private string loginID;
        private string jobTitle;
        private DateTime dateOfBirth;
        private DateTime hireOnDate;
        private Sex employeeSex;
        private MaritalStatus employeeMaritalStatus;

        [DataMember]
        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                id = value;
            }
        }

        [DataMember]
        public string NationalID
        {
            get
            {
                return nationalID;
            }

            set
            {
                nationalID = value;
            }
        }

        [DataMember]
        public string LoginID
        {
            get
            {
                return loginID;
            }

            set
            {
                loginID = value;
            }
        }

        [DataMember]
        public string JobTitle
        {
            get
            {
                return jobTitle;
            }

            set
            {
                jobTitle = value;
            }
        }

        [IgnoreDataMember]
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;
            }
        }

        [DataMember(Name = "DateOfBirth")]
        private string DateOfBirthString { get; set; }

        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
            if (this.DateOfBirth == null)
                this.DateOfBirthString = "";
            else
                this.DateOfBirthString = this.DateOfBirth.ToString("MMM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            if (this.HireOnDate == null)
                this.HireOnDateString = "";
            else
                this.HireOnDateString = this.HireOnDate.ToString("MMM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
        }

        [OnDeserialized]
        void OnDeserializing(StreamingContext context)
        {
            if (this.DateOfBirthString == null)
                this.DateOfBirth = DateTime.MinValue;
            else
                this.DateOfBirth = DateTime.ParseExact(this.DateOfBirthString, "MMM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            if (this.HireOnDateString == null)
                this.HireOnDate = DateTime.MinValue;
            else
                this.HireOnDate = DateTime.ParseExact(this.HireOnDateString, "MMM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
        }

        [IgnoreDataMember]
        public DateTime HireOnDate
        {
            get
            {
                return hireOnDate;
            }

            set
            {
                hireOnDate = value;
            }
        }

        [DataMember(Name = "HireOnDate")]
        private string HireOnDateString;

        [DataMember]
        public Sex EmployeeSex
        {
            get
            {
                return employeeSex;
            }

            set
            {
                employeeSex = value;
            }
        }

        [DataMember]
        public MaritalStatus EmployeeMaritalStatus
        {
            get
            {
                return employeeMaritalStatus;
            }

            set
            {
                employeeMaritalStatus = value;
            }
        }
    }
}
