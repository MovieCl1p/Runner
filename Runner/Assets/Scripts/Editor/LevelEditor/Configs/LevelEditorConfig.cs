using Core.Binder;
using Core.Dispatcher;
using Game.Factory;
using Game.Model;
using Game.Player.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Configs
{
    public class LevelEditorConfig
    {
        public void AddBindings()
        {
            BindModels();
            BindServices();
            BindInjections();
        }

        private void BindInjections()
        {
            BindManager.Bind<IDispatcher>().To<Dispatcher>().ToSingleton();



            BindManager.Bind<IPlayerControl>().To<PlayerControl>().ToSingleton();
            BindManager.Bind<GameFactory>().ToSingleton();
        }

        private void BindModels()
        {
            BindManager.Bind<LevelSessionModel>().ToSingleton();
        }

        private void BindServices()
        {
        }
    }
}
