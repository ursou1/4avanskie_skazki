using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace WpfApp1
{
    class ClientEdit
    {
        public List<Client> Clients { get; set; } = new List<Client>();

        public void Add()
        {
            Clients.Add(new Client { FirstName = "Имя", LastName = "Фамилия" });
            Save();
        }

        public ClientEdit()
        {
            Clients.Add(new Client { FirstName = "Иван", LastName = "Иванов", FatherName = "Иванович" });
            Load();
        }

        internal void Remove(Client client)
        {
            Clients.Remove(client);
            Save();
        }

        internal void SaveClient(Client original, Client copy)
        {
            int index = Clients.IndexOf(original);
            Clients[index] = copy;
            Save();
        }

        internal void MarkDate(Client client)
        {
            int index = Clients.IndexOf(client);
            Clients[index].VisitLog.Add(DateTime.Now);
            Save();
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(Clients, typeof(List<Client>));
            File.WriteAllText("clients.db", json);
        }

        public void Load()
        {
            string file = "clients.db";
            if (!File.Exists(file) || new FileInfo(file).Length == 0)
            {
                Clients = new List<Client>();
                return;
            }
            string json = File.ReadAllText(file);
            Clients = (List<Client>)JsonSerializer.Deserialize(json, typeof(List<Client>));
        }
    }
}
