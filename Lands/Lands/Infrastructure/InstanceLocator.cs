

namespace Lands.Infrastructure
{
    using ViewModels;

    class InstanceLocator
    {
        #region properties
        public MainViewModel Main { get; set; }
        #endregion

        #region Constructores
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
