using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp1
{
    internal class ClientListVM: MvvmNotify, IPageVM
    {
        Model model;

        public ObservableCollection<Client> Clients { get; set; }
        public MvvmCommand CreateClient { get; set; }
        public MvvmCommand RemoveClient { get; set; }
        public MvvmCommand SaveClient { get; set; }
        public MvvmCommand VisitLog { get; set; }
        public MvvmCommand MarkDate { get; set; }
        public Client SelectedClient
        {
            get => model.SelectedClient;
            set
            {
                model.SelectedClient = value;
                if (value != null)
                    SelectedClientCopy = new Client { FirstName = value.FirstName, LastName = value.LastName, FatherName = value.FatherName, CarNumber = value.CarNumber, CarBrand = value.CarBrand, VisitLog = value.VisitLog };
                NotifyPropertyChanged("SelectedClient");
                NotifyPropertyChanged("SelectedClientCopy");
            }
        }
        public Client SelectedClientCopy { get; set; }

        public void SetModel(Model model)
        {
            this.model = model;
            Clients = new ObservableCollection<Client>(model.GetClients());
            VisitLog = new MvvmCommand(
                () => Pages.ChangePageTo(PageType.VisitList),
                () => SelectedClient != null);
            CreateClient = new MvvmCommand(
                () => model.CreateClient(),
                () => true);
            RemoveClient = new MvvmCommand(
                () => model.RemoveClient(SelectedClient),
                () => SelectedClient != null);
            SaveClient = new MvvmCommand(
                () => model.SaveClient(SelectedClient, SelectedClientCopy),
                () => SelectedClient != null);
            VisitLog = new MvvmCommand(
                () =>
                {
                    model.SelectedClient = SelectedClient;
                    Pages.ChangePageTo(PageType.VisitList);
                },
                () => SelectedClient != null);
            MarkDate = new MvvmCommand(
                () => model.MarkDate(SelectedClient),
                () => SelectedClient != null);

            model.ClientsChanged += Model_ClientsChanged;
        }

        private void Model_ClientsChanged(object sender, System.EventArgs e)
        {
            Clients = new ObservableCollection<Client>(model.GetClients());
            NotifyPropertyChanged("Clients");
        }
    }
}

