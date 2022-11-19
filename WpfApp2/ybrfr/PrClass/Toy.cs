using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.ybrfr
{
    partial class Toy
    {
        public string IsAvailableDraw
        {
            get
            {
                if (IsAvailable == false)
                    return "#bfbfbf";
                else
                    return "#ffffff";
            }
        }

    }
}
