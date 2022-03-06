using System.Collections.Generic;
using SimpleApp.Models;

namespace SimpleApp.Tests
{
    public interface IDataSource {
        IEnumerable<Product> Products{get;}
    }
}