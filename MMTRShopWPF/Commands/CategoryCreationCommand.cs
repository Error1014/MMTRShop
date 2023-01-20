using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.Commands
{
    public class CategoryCreationCommand : BaseCommand
    {
        private CategoryService categoryService = new CategoryService();
        public CategoryCreationCommand(Action<object> execute, Func<object, bool> canExecute = null) :base(execute,  canExecute = null)
        {

        }
        public void Save(object obj)
        {
            categoryService.Save(obj);
        }
        public void Add(object obj)
        {
            categoryService.Add(obj);
        }
        public void Remove(object obj)
        {
            categoryService.Remove(obj);
        }
    }

}
