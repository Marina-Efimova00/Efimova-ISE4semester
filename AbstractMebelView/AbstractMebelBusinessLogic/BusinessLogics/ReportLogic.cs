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
        public ReportLogic(IMebelLogic MebelLogic, IZagotovkaLogic ZagotovkaLogic,
       IOrderLogic orderLLogic)
        {
            this.MebelLogic = MebelLogic;
            this.ZagotovkaLogic = ZagotovkaLogic;
            this.orderLogic = orderLLogic;
        }

        public List<ReportMebelZagotovkaViewModel> GetMebelZagotovka()
        {
            var Zagotovkas = ZagotovkaLogic.Read(null);
            var Mebels = MebelLogic.Read(null);
            var list = new List<ReportMebelZagotovkaViewModel>();
            foreach (var Zagotovka in Zagotovkas)
            {
                foreach (var Mebel in Mebels)
                {
                    if (Mebel.MebelZagotovkas.ContainsKey(Zagotovka.Id))
                    {
                        var record = new ReportMebelZagotovkaViewModel
                        {
                            MebelName = Mebel.MebelName,
                            ZagotovkaName = Zagotovka.ZagotovkaName,
                            Count = Mebel.MebelZagotovkas[Zagotovka.Id].Item2
                        };
                        list.Add(record);
                    }
                }
            }
            return list;
        }
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                MebelName = x.MebelName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
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
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
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
                Title = "Список заказов",
                MebelZagotovkas = GetMebelZagotovka(),
            });
        }
    }
}
