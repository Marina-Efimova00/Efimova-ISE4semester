using AbstractMebelBusinessLogic.BindingModels;
using AbstractMebelBusinessLogic.HelperModels;
using AbstractMebelBusinessLogic.Interfaces;
using AbstractMebelBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractMebelBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IZagotovkaLogic ZagotovkaLogic;
        private readonly IMebelLogic MebelLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IStorageLogic storageLogic;
        public ReportLogic(IMebelLogic MebelLogic, IZagotovkaLogic ZagotovkaLogic,
       IOrderLogic orderLogic, IStorageLogic storageLogic)
        {
            this.MebelLogic = MebelLogic;
            this.ZagotovkaLogic = ZagotovkaLogic;
            this.orderLogic = orderLogic;
            this.storageLogic = storageLogic;
        }

        public List<ReportMebelZagotovkaViewModel> GetMebelZagotovka()
        {
            var Mebels = MebelLogic.Read(null);
            var list = new List<ReportMebelZagotovkaViewModel>();
            foreach (var mebel in Mebels)
            {
                foreach (var mb in mebel.MebelZagotovkas)
                {
                    var record = new ReportMebelZagotovkaViewModel
                    {
                        MebelName = mebel.MebelName,
                        ZagotovkaName = mb.Value.Item1,
                        Count = mb.Value.Item2,
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        public List<ReportStorageZagotovkaViewModel> GetStorageZagotovkas()
        {
            var storages = storageLogic.GetList();
            var list = new List<ReportStorageZagotovkaViewModel>();

            foreach (var storage in storages)
            {
                foreach (var sz in storage.StorageZagotovkas)
                {
                    var record = new ReportStorageZagotovkaViewModel
                    {
                        StorageName = storage.StorageName,
                        ZagotovkaName = sz.ZagotovkaName,
                        Count = sz.Count
                    };

                    list.Add(record);
                }
            }
            return list;
        }
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();

            return list;
        }
        public void SaveMebelsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список мебели",
                Mebels = MebelLogic.Read(null)
            });
        }
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
        public void SaveMebelsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заготовок мебели",
                MebelZagotovkas = GetMebelZagotovka(),
            });
        }
        public void SaveStoragesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Mebels = null,
                Storages = storageLogic.GetList()
            });
        }

        public void SaveStorageZagotovkasToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заготовок на складах",
                Orders = null,
                Storages = storageLogic.GetList()
            });
        }

        public void SaveComponentsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Заготовок",
                MebelZagotovkas = null,
                StorageZagotovkas = GetStorageZagotovkas()
            });
        }
    }
}
