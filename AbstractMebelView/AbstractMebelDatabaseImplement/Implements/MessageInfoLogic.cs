using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using AbstractMebelDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractMebelDatabaseImplement.Implements
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        public void Create(MessageInfoBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                MessageInfo element = context.MessageInfoes.FirstOrDefault(rec => rec.MessageId == model.MessageId);

                if (element != null)
                {
                    throw new Exception("Уже есть письмо с таким идентификатором");
                }

                int? clientId = context.Clients.FirstOrDefault(rec => rec.Email == model.FromMailAddress)?.Id;

                context.MessageInfoes.Add(new MessageInfo
                {
                    MessageId = model.MessageId,
                    ClientId = clientId,
                    SenderName = model.FromMailAddress,
                    DateDelivery = model.DateDelivery,
                    Subject = model.Subject,
                    Body = model.Body
                });

                context.SaveChanges();
            }
        }

        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            using (var context = new AbstractMebelDatabase())
            {
                return context.MessageInfoes
                .Where(rec => model == null || rec.ClientId == model.ClientId)
                .Select(rec => new MessageInfoViewModel
                {
                    MessageId = rec.MessageId,
                    SenderName = rec.SenderName,
                    DateDelivery = rec.DateDelivery,
                    Subject = rec.Subject,
                    Body = rec.Body
                })
               .ToList();
            }
        }
    }
}
