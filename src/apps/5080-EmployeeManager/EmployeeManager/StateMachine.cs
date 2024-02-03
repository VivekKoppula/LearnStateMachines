using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeManager
{
    public enum States
    {
        Start, Searching, SearchComplete, Selected, NoSelection, Editing
    }

    public enum Triggers
    {
        Search, SearchFailed, SearchSucceeded, Select, DeSelect, Edit, EndEdit
    }

    public class StateMachine : Stateless.StateMachine<States, Triggers>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public StateMachine(Action searchAction) : base(States.Start)
        {
            Configure(States.Start)
              .Permit(Triggers.Search, States.Searching);

            Configure(States.Searching)
              .OnEntry(searchAction)
              .Permit(Triggers.SearchSucceeded, States.SearchComplete)
              .Permit(Triggers.SearchFailed, States.Start)
              .Ignore(Triggers.Select)
              .Ignore(Triggers.DeSelect);

            Configure(States.SearchComplete)
              .SubstateOf(States.Start)
              .Permit(Triggers.Select, States.Selected)
              .Permit(Triggers.DeSelect, States.NoSelection);

            Configure(States.Selected)
              .SubstateOf(States.SearchComplete)
              .Permit(Triggers.DeSelect, States.NoSelection)
              .Permit(Triggers.Edit, States.Editing)
              .Ignore(Triggers.Select);

            Configure(States.NoSelection)
              .SubstateOf(States.SearchComplete)
              .Permit(Triggers.Select, States.Selected)
              .Ignore(Triggers.DeSelect);

            Configure(States.Editing)
              .Permit(Triggers.EndEdit, States.Selected);

            OnTransitioned
              (
                (t) =>
                {
                    OnPropertyChanged("State");
                    CommandManager.InvalidateRequerySuggested();
                }
              );

            //used to debug commands and UI components
            OnTransitioned
              (
                (t) => Debug.WriteLine
                  (
                    "State Machine transitioned from {0} -> {1} [{2}]",
                    t.Source, t.Destination, t.Trigger
                  )
              );
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }

}
