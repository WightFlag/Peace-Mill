using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace_Mill
{
    public interface ISize <out T, in R>
    {
        string Name { get; set; }
        T Get();
        void Set(R value);
    }
}
