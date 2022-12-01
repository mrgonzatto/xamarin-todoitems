using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using MeuPrimeiroApp.Repositories;
using MeuPrimeiroApp.ViewModels;
using Xamarin.Forms;

namespace MeuPrimeiroApp
{
    public abstract class Bootstrapper
    {
        protected ContainerBuilder ContainerBuilder { get; private set; }

        protected Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }

        protected virtual void Initialize()
        { 
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();

            foreach ( var type in 
                currentAssembly.DefinedTypes
                .Where( e => e.IsSubclassOf(typeof(Page)) || 
                             e.IsSubclassOf(typeof(ViewModel)) )
            ){
                ContainerBuilder.RegisterType(type.AsType());
            }

            ContainerBuilder.RegisterType<TodoItemRepository>().SingleInstance();
        }

        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
