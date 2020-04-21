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
    }
}
