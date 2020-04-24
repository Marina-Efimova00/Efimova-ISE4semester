using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.BusinessLogics;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbstractMebelRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IMebelLogic _mebel;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IMebelLogic mebel, MainLogic main)
        {
            _order = order;
            _mebel = mebel;
            _main = main;
        }
        [HttpGet]
        public List<MebelModel> GetMebelList() => _mebel.Read(null)?.Select(rec =>
      Convert(rec)).ToList();
        [HttpGet]
        public MebelModel GetMebel(int MebelId) => Convert(_mebel.Read(new
       MebelBindingModel
        { Id = MebelId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private MebelModel Convert(MebelViewModel model)
        {
            if (model == null) return null;
            return new MebelModel
            {
                Id = model.Id,
                MebelName = model.MebelName,
                Price = model.Price
            };
        }
    }
}