using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NW.BLL
{
    public　class BLLSessionFactory
    {
        public static BLLSession GetBLLSession()
        {
            BLLSession bllsession = CallContext.GetData(typeof(BLLSessionFactory).Name) as BLLSession;
            if (bllsession == null)
            {
                bllsession = new BLLSession();
                CallContext.SetData(typeof(BLLSessionFactory).Name, bllsession);
            }
            return bllsession;
        }
    }
}
