using AdventureWorks.BusinessCore;
using AdventureWorks.BusinessCore.BLL;
using AdventureWorks.Model;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AdventureWorks.ViewModels
{
    public class EmployeeWindowViewModel : BindableBase
    {
        Employee _employeeObj;
        ObservableCollection<string> _genderListSourceValues = new ObservableCollection<string>() { "Male", "Female" };
        ObservableCollection<string> _martialStatusListSourceValues = new ObservableCollection<string>() { "Single", "Married" };
        ObservableCollection<Employee> _employees;

        string _selectedGender;
        string _selectedMartialStatus;
        ICommand _updateEmployeeCommand;

        public EmployeeWindowViewModel()
        {
            this.Employees = new ObservableCollection<Employee>(CoreFactory.GetInstance().EmployeeBusinessLogic.GetAllEmployees());
            this._updateEmployeeCommand = new RelayCommand(this.UpdateEmployeeReferenece);
        }

        public Employee EmployeeObj
        {
            get { return this._employeeObj; }
            set { this._employeeObj = value;
                this.SelectedGender = this._employeeObj.EmployeeSex == Sex.Male ? "Male" : "Female";
                this.SelectedMaritalStatus = this._employeeObj.EmployeeMaritalStatus == MaritalStatus.Single ? "Single" : "Married";
                base.OnPropertyChanged("EmployeeObj");
            }
        }

        public ObservableCollection<Employee> Employees
        {
            get { return this._employees; }
            set
            {
                this._employees = value;
                base.OnPropertyChanged("Employees");
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
                base.OnPropertyChanged("SelectedGender");
            }
        }

        public string SelectedMaritalStatus
        {
            get { return this._selectedMartialStatus; }
            set
            {
                this._selectedMartialStatus = value;
                base.OnPropertyChanged("SelectedMaritalStatus");
            }
        }

        public void UpdateEmployeeReferenece(object obj)
        {
            try
            {
                CoreFactory.GetInstance().EmployeeBusinessLogic.UpdateEmployee(this.EmployeeObj);
                NotificationService.ShowInformationMessage("Record has been updated");
            }
            catch (System.Exception e)
            {
                NotificationService.ShowErrorMessage(e.Message);
            }
            
        }


        public ICommand UpdateEmployeeCommand
        {
            get
            {
                return this._updateEmployeeCommand;
            }
            set
            {
                this._updateEmployeeCommand = value;
            }
        }
    }
}
