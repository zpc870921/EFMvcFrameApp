using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMvcFrame.FrameWork.Caching
{
    public interface ICacheProvider
    {
        T Get<T>(string key,Func<T> func);
        void Remove(string key);
    }
}
