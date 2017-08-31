using System;
using Core.Binder;
using Game.Model;
using Game.Services;
using Game.Services.Interfaces;

namespace Game.Config
{
    public class AppConfig
    {
        public void AddBindings()
        {
            BindModels();
            BindServices();
        }

        private void BindModels()
        {
            BindManager.Bind<LevelSessionModel>().ToSingleton();
        }

        private void BindServices()
        {
            BindManager.Bind<ILevelLoaderService>().To<LevelLoaderService>().ToSingleton();
        }
    }
}
