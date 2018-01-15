using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.e2e.Controls.Interfaces.Table
{
    interface ICell
    {
        string Text { get; }

        void OpenDetails();

        void SetValue(string value);
    }
}
