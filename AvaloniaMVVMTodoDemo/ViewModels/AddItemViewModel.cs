using AvaloniaMVVMTodoDemo.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace AvaloniaMVVMTodoDemo.ViewModels
{
    class AddItemViewModel : ViewModelBase
    {
        string description;
        TodoItem item;
        public AddItemViewModel(TodoItem item = null)
        {
            if(item!= null)
            {
              Description = item.Description;
              this.item = item;
            }
              else
              this.item = new TodoItem();

            var okEnabled = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x));

            Ok = ReactiveCommand.Create(
                () =>  {this.item.Description=Description; return this.item; },
                okEnabled);
            Cancel = ReactiveCommand.Create(() => { });
        }

        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }

        public ReactiveCommand<Unit, TodoItem> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}
