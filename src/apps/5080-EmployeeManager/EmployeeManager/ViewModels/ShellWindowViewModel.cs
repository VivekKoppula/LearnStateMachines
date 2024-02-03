using EmployeeManager.Extensions;
using EmployeeManager.Infrastructure;
using EmployeeManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeManager.ViewModels
{
    public class ShellWindowViewModel : BindableObject
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            // set { SetProperty(ref _title, value); }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    OnPropertyChanged(() => Title);
                }
            }
        }

        private Employee _selectedEmployee = default!;

        public ShellWindowViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            StateMachine = new StateMachine
            (
                searchAction: async () => await LoadEmployees()
            );
            SearchCommand = StateMachine.CreateCommand(Triggers.Search);
            EditCommand = StateMachine.CreateCommand(Triggers.Edit);
            EndEditCommand = StateMachine.CreateCommand(Triggers.EndEdit);
        }

        public ICommand SearchCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand EndEditCommand { get; private set; }

        public ObservableCollection<Employee> Employees { get; private set; }
        public StateMachine StateMachine { get; private set; }

        public Employee SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            //set { SetProperty(ref _title, value); }
            set
            {
                if (value != _selectedEmployee)
                {
                    _selectedEmployee = value;
                    OnPropertyChanged(() => SelectedEmployee);
                    // SetProperty(ref _selectedEmployee, value);
                    if (value != null)
                    {
                        StateMachine.Fire(Triggers.Select);
                    }
                    else
                    {
                        StateMachine.Fire(Triggers.DeSelect);
                    }
                }
            }
        }

        private async Task LoadEmployees()
        {
            try
            {
                Employees.Clear();

                //fake a long running process
                await Task.Delay(2000);

                List<Employee> employees = GetEmployees();

                employees.ForEach(e => Employees.Add(e));

                StateMachine.Fire(Triggers.SearchSucceeded);

                if (Employees.Count > 0)
                {
                    SelectedEmployee = Employees.First();
                }
            }
            catch
            {
                StateMachine.Fire(Triggers.SearchFailed);
            }
        }

        private List<Employee> GetEmployees()
        {
            return new List<Employee>()
        {
          new Employee("Davolio", "Nancy", "Sales Representative"),
          new Employee("Fuller", "Andrew", "Vice President, Sales"),
          new Employee("Leverling", "Janet", "Sales Representative"),
          new Employee("Peacock", "Margaret", "Sales Representative"),
          new Employee("Buchanan", "Steven", "Sales Manager"),
          new Employee("Suyama", "Michael", "Sales Representative"),
          new Employee("King", "Robert", "Sales Representative"),
          new Employee("Callahan", "Laura", "Inside Sales Coordinator"),
          new Employee("Dodsworth", "Anne", "Sales Representative")
        };
        }
    }
}
