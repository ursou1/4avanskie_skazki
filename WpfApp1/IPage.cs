using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    public interface IPage
    {
        void SetVM(IPageVM vm);
    }
}
