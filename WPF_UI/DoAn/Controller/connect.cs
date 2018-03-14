using DoAn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Controller
{
   static class connect
    {
        static public QLVeMayBayEntities Connect()
        {
            QLVeMayBayEntities LT = new QLVeMayBayEntities();
            return LT;
        }
    }
}
