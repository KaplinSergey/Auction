using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.e2e.Controls.Interfaces.Table
{
    interface IRow
    {
        void OpenDetails();

        ICell this[string headerName] { get; }

        void Select();

        void Expand();
    }
}
