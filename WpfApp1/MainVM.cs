using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WpfApp1
{
     public class MainVM: MvvmNotify
    {
        Model model;

        public Page CurrentPage { get; set; }

        public MainVM()
        {
            model = new Model();
            Pages.SetModel(model);
            CurrentPage = Pages.GetPageByType(PageType.ClientList);
            Pages.CurrentPageChanged += PageContainer_CurrentPageChanged;
        }

        void PageContainer_CurrentPageChanged(object sender, PageType e)
        {
            CurrentPage = Pages.GetPageByType(e);
            NotifyPropertyChanged("CurrentPage");
        }
    }
}
