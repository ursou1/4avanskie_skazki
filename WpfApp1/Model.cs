using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    public class Model
    {
        ClientEdit clientEdit = new ClientEdit();
        Client selectedClient;

        public event EventHandler ClientsChanged;
        public event EventHandler SelectedClientChanged;
        public Client SelectedClient
        {
            get => selectedClient;
            set { selectedClient = value; SelectedClientChanged?.Invoke(this, null); }
        }

        public List<Client> GetClients()
        {
            return clientEdit.Clients;
        }

        internal void CreateClient()
        {
            clientEdit.Add();
            ClientsChanged?.Invoke(this, null);
        }

        internal void RemoveClient(Client client)
        {
            clientEdit.Remove(client);
            ClientsChanged?.Invoke(this, null);
        }

        internal void SaveClient(Client original, Client copy)
        {
            clientEdit.SaveClient(original, copy);
            ClientsChanged?.Invoke(this, null);
        }

        internal void MarkDate(Client client)
        {
            clientEdit.MarkDate(client);
        }
    }
}
