using MeuPrimeiroApp.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MeuPrimeiroApp.ViewModels
{
    public class TodoItemViewModel : ViewModel
    {
        public TodoItem Item { get; private set; }

        public TodoItemViewModel(TodoItem item) => Item = item;

        public event EventHandler ItemStatusChanged;

        public string StatusText => (Item.Completed ? "Reativar" : "Finalizado");

        public ICommand ToggleCompleted => new Command((arg) => 
        { 
            Item.Completed = !Item.Completed;
            ItemStatusChanged?.Invoke(this, new EventArgs());
        });
    }
}
