﻿using AbstractMebelBusinessLogic.Enums;
using AbstractMebelFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AbstractMebelFileImplement
{
    public class FileDataListSingleton
    {

        private static FileDataListSingleton instance;
        private readonly string ZagotovkaFileName = "Zagotovka.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string MebelFileName = "Mebel.xml";
        private readonly string MebelZagotovkaFileName = "MebelZagotovka.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        private readonly string MessageInfoFileName = "MessangeInfo.xml";
        public List<Zagotovka> Zagotovkas { get; set; }
        public List<Order> Orders { get; set; }
        public List<Mebel> Mebels { get; set; }
        public List<MebelZagotovka> MebelZagotovkas { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfoes { get; set; }

        private FileDataListSingleton()
        {
            Zagotovkas = LoadZagotovkas();
            Orders = LoadOrders();
            Mebels = LoadMebels();
            MebelZagotovkas = LoadMebelZagotovkas();
            Clients = LoadClients();
            Implementers = LoadImplementers();
            MessageInfoes = LoadMessageInfoes();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveZagotovkas();
            SaveOrders();
            SaveMebels();
            SaveMebelZagotovkas();
            SaveClients();
            SaveImplementers();
            SaveMessageInfoes();
        }
        private List<Zagotovka> LoadZagotovkas()
        {
            var list = new List<Zagotovka>();
            if (File.Exists(ZagotovkaFileName))
            {
                XDocument xDocument = XDocument.Load(ZagotovkaFileName);
                var xElements = xDocument.Root.Elements("Zagotovka").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Zagotovka
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ZagotovkaName = elem.Element("ZagotovkaName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        MebelId = Convert.ToInt32(elem.Element("MebelId").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        ImplementerId = Convert.ToInt32(elem.Attribute("ImplementerId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Mebel> LoadMebels()
        {
            var list = new List<Mebel>();
            if (File.Exists(MebelFileName))
            {
                XDocument xDocument = XDocument.Load(MebelFileName);
                var xElements = xDocument.Root.Elements("Mebel").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Mebel
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        MebelName = elem.Element("MebelName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<MebelZagotovka> LoadMebelZagotovkas()
        {
            var list = new List<MebelZagotovka>();
            if (File.Exists(MebelZagotovkaFileName))
            {
                XDocument xDocument = XDocument.Load(MebelZagotovkaFileName);
                var xElements = xDocument.Root.Elements("MebelZagotovka").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new MebelZagotovka
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        MebelId = Convert.ToInt32(elem.Element("MebelId").Value),
                        ZagotovkaId = Convert.ToInt32(elem.Element("ZagotovkaId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
        }
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();

            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value)
                    });
                }
            }

            return list;
        }
        private List<MessageInfo> LoadMessageInfoes()
        {
            var list = new List<MessageInfo>();

            if (File.Exists(MessageInfoFileName))
            {
                XDocument xDocument = XDocument.Load(MessageInfoFileName);
                var xElements = xDocument.Root.Elements("MessageInfo").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Attribute("MessageId").Value,
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        SenderName = elem.Element("SenderName").Value,
                        DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery").Value),
                        Subject = elem.Element("Subject").Value,
                        Body = elem.Element("Body").Value
                    });
                }
            }

            return list;
        }
        private void SaveZagotovkas()
        {
            if (Zagotovkas != null)
            {
                var xElement = new XElement("Zagotovkas");
                foreach (var zagotovka in Zagotovkas)
                {
                    xElement.Add(new XElement("Zagotovka",
                    new XAttribute("Id", zagotovka.Id),
                    new XElement("ZagotovkaName", zagotovka.ZagotovkaName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ZagotovkaFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("MebelId", order.MebelId),
                    new XElement("ClientId", order.ClientId),
                    new XElement("ImplementerId", order.ImplementerId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveMebels()
        {
            if (Mebels != null)
            {
                var xElement = new XElement("Mebels");
                foreach (var mebel in Mebels)
                {
                    xElement.Add(new XElement("Mebel",
                    new XAttribute("Id", mebel.Id),
                    new XElement("MebelName", mebel.MebelName),
                    new XElement("Price", mebel.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MebelFileName);
            }
        }
        private void SaveMebelZagotovkas()
        {
            if (MebelZagotovkas != null)
            {
                var xElement = new XElement("MebelZagotovkas");
                foreach (var mebelZagotovka in MebelZagotovkas)
                {
                    xElement.Add(new XElement("MebelZagotovka",
                    new XAttribute("Id", mebelZagotovka.Id),
                    new XElement("MebelId", mebelZagotovka.MebelId),
                    new XElement("ZagotovkaId", mebelZagotovka.ZagotovkaId),
                    new XElement("Count", mebelZagotovka.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MebelZagotovkaFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");

                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");

                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
        private void SaveMessageInfoes()
        {
            if (MessageInfoes != null)
            {
                var xElement = new XElement("MessageInfoes");

                foreach (var messageInfo in MessageInfoes)
                {
                    xElement.Add(new XElement("MessageInfo",
                    new XAttribute("Id", messageInfo.MessageId),
                    new XElement("ClientId", messageInfo.ClientId),
                    new XElement("SenderName", messageInfo.SenderName),
                    new XElement("DateDelivery", messageInfo.DateDelivery),
                    new XElement("Subject", messageInfo.Subject),
                    new XElement("Body", messageInfo.Body)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MessageInfoFileName);
            }
        }
    }
}
