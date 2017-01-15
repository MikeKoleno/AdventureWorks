using AdventureWorks.BusinessCore.BLL;
using AdventureWorks.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        Employee _employeeObj;
        ObservableCollection<string> _genderListSourceValues = new ObservableCollection<string>() { "Male", "Female" };
        ObservableCollection<string> _martialStatusListSourceValues = new ObservableCollection<string>() { "Single", "Married" };
        string _selectedGender;
        string _selectedMartialStatus;
        ObservableCollection<Employee> _employees;
        EmployeeBLL bll = new EmployeeBLL();


        public EmployeeViewModel(Employee emp)
        {
            this.EmployeeObj = emp;
            this.Employees = new ObservableCollection<Employee>(bll.GetAllEmployees());
        }

        public EmployeeViewModel()
        {
            this.Employees = new ObservableCollection<Employee>(bll.GetAllEmployees());
            this.EmployeeObj = bll.GetEmployee(201);
        }

        public Employee EmployeeObj
        {
            get { return this._employeeObj; }
            set { this._employeeObj = value;
                this.SelectedGender = this._employeeObj.EmployeeSex == Sex.Male ? "Male" : "Female";
                this.SelectedMaritalStatus = this._employeeObj.EmployeeMaritalStatus == MaritalStatus.Single ? "Single" : "Married";
                base.RaisePropertyChanged("EmployeeObj");
            }
        }

        public ObservableCollection<Employee> Employees
        {
            get { return this._employees; }
            set
            {
                this._employees = value;
                base.RaisePropertyChanged("Employees");
            }
        }

        public ObservableCollection<string> GenderListSourceValues {
            get { return this._genderListSourceValues;  }
        }

        public ObservableCollection<string> MartialStatusListSourceValues
        {
            get { return this._martialStatusListSourceValues; }
        }

        public string SelectedGender
        {
            get { return this._selectedGender; }
            set
            {
                this._selectedGender = value;
                base.RaisePropertyChanged("SelectedGender");
            }
        }

        public string SelectedMaritalStatus
        {
            get { return this._selectedMartialStatus; }
            set
            {
                this._selectedMartialStatus = value;
                base.RaisePropertyChanged("SelectedMaritalStatus");
            }
        }
    }
}
