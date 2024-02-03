using System.Collections.Generic;
using System.Linq;
using AppccelerateStateMachine;
using AppccelerateViewStateMachine.Infrastructure;
using AppccelerateViewStateMachine.StateMachine;
using static AppccelerateStateMachine.Extensions.EventRaiser;

namespace AppccelerateViewStateMachine.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel = default!;
        private List<IPageViewModel> _pageViewModels;

        public MainWindowViewModel(IViewStateMachine stateMachine)
        {
            stateMachine.ViewModelEvent += OnChangeViewModelEvent!;

            _pageViewModels = new List<IPageViewModel>
             {
                new UserControl1ViewModel(stateMachine),
                new UserControl2ViewModel(stateMachine),
                new UserControl3ViewModel(stateMachine)
             };

            CurrentPageViewModel = _pageViewModels[0];
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                _pageViewModels ??= new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get { return _currentPageViewModel; }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }

        private void OnChangeViewModelEvent(object sender, EventArgs<int> e)
        {
            ChangeViewModel(PageViewModels[e.Value]);
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
               .FirstOrDefault(vm => vm == viewModel)!;
        }
    }
}
