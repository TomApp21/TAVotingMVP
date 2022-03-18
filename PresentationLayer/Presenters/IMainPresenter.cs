using PresentationLayer.Views;
using System;

namespace PresentationLayer.Presenters
{
  public interface IMainPresenter
  {
    void OnMainViewLoadedEventRaised(object sender, System.EventArgs e);
    IMainView GetMainView();
    void SetMainView(IMainView mainView);
  }
}