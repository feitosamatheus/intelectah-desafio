using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaApp.Application.Interfaces
{
    public interface IGeradorPdfService
    {
        byte[] CreatePdfFromHtml(string htmlContent);
    }
}
