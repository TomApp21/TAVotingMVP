using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class BasePresenter : IBasePresenter
    {
        public IErrorMessageView _errorMessageView;

        public BasePresenter()
        {

        }
        public BasePresenter(IErrorMessageView errorMessageView)
        {
            _errorMessageView = errorMessageView;
        }

        public void ShowErrorMessage(string windowTitle, string errorMessage)
        {
            ErrorMessageView _errorMessageView = new ErrorMessageView();
            _errorMessageView.ShowErrorMessageView(windowTitle, errorMessage);
        }


    }
}
