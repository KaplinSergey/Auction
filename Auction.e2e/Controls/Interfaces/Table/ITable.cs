using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.e2e.Controls.Interfaces.Table
{
    interface ITable
    {
        List<IHeader> Headers { get; }

        List<IRow> Rows { get; }
    }
}
