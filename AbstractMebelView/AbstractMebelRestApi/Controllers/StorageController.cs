using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbstractMebelRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageLogic _storage;
        private readonly IZagotovkaLogic _zagotovka;

        public StorageController(IStorageLogic storage, IZagotovkaLogic zagotovka)
        {
            _storage = storage;
            _zagotovka = zagotovka;
        }

        [HttpGet]
        public List<StorageModel> GetStoragesList() => _storage.GetList()?.Select(rec => Convert(rec)).ToList();
        [HttpGet]
        public List<ZagotovkaViewModel> GetZagotovkasList() => _zagotovka.Read(null)?.ToList();
        [HttpGet]
        public StorageModel GetStorage(int StorageId) => Convert(_storage.GetElement(StorageId));
        [HttpPost]
        public void CreateOrUpdateStorage(StorageBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _storage.UpdElement(model);
            }
            else
            {
                _storage.AddElement(model);
            }
        }
        [HttpPost]
        public void DeleteStorage(StorageBindingModel model) => _storage.DelElement(model);
        [HttpPost]
        public void FillStorage(StorageZagotovkaBindingModel model) => _storage.FillStorage(model);
        private StorageModel Convert(StorageViewModel model)
        {
            if (model == null) return null;

            return new StorageModel
            {
                Id = model.Id,
                StorageName = model.StorageName,
                StorageZagotovkas = model.StorageZagotovkas
            };
        }
    }
}