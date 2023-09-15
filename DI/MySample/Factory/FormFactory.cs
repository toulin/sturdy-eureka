using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace MySample.Factory
{
    public class FormFactory : IFormFactory
    {
        private readonly IServiceScope _scope;

        public FormFactory(IServiceScopeFactory scopeFactory)
        {
            _scope = scopeFactory.CreateScope();
        }

        public T Create<T>() where T : Form
        {
            //GetService: 當找不到時會回傳null
            return _scope.ServiceProvider.GetService<T>();
        }

        public T CreateInstance<T>() 
        {
            //GetRequiredService: 與GetService的差異於，當找不到實例時會拋出異常
            return _scope.ServiceProvider.GetRequiredService<T>();
        }
    }
}
