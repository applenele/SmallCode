using NW.Entity;
using NW.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NW.DAL
{
    public class ImageThemeDAL : BaseDAL<ImageTheme>, IImageThemeDAL
    {
        public ImageThemeDAL()
        {
            base.t = new ImageTheme();
        }

        public ImageTheme GetEntityWithRefence(int id)
        {
            throw new NotImplementedException();
        }


    }
}
