using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace InventoryMobileApp.Commands
{
    /// <summary>
    /// Class contains the common commands used in toolbar.
    /// </summary>
    public sealed class CommonToolbarCommands
    {
        private static CommonToolbarCommands instance = null;
        private static readonly object padlock = new object();

        /// <summary>
        /// Singleton instanse of the class <see cref="CommonToolbarCommands"/>.
        /// </summary>
        public static CommonToolbarCommands Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CommonToolbarCommands();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Gets the command used to Sync
        /// </summary>
        public ICommand SyncCommand
        {
            get; private set;
        }

        /// <summary>
        /// Gets the Logout command
        /// </summary>
        public ICommand LogoutCommand
        {
            get; private set;
        }

        /// <summary>
        /// Gets the Product command
        /// </summary>
        public ICommand ProductCommand
        {
            get; private set;
        }

        /// <summary>
        /// Gets the Designation command
        /// </summary>
        public ICommand DesignationCommand
        {
            get; private set;
        }

        /// <summary>
        /// Gets the User command
        /// </summary>
        public ICommand UserCommand
        {
            get; private set;
        }

        /// <summary>
        /// Gets the Rack command
        /// </summary>
        public ICommand RackCommand
        {
            get; private set;
        }

        private CommonToolbarCommands()
        {
            SyncCommand = new SyncCommand();
            LogoutCommand = new LogoutCommand();
            ProductCommand = new ProductCommand();
            UserCommand = new UserCommand();
            DesignationCommand = new DesignationCommand();
            RackCommand = new RackCommand();
        }
    }
}
