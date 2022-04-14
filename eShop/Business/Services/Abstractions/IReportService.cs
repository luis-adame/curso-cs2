using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface IReportService
    {
        public List<ProductReportDto> Top5Expensives();
        public List<UnitReportDto> StockUnder5();
    }
}
