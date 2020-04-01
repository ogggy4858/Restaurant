using Repositories.Implementation;
using Repositories.Interfaces;
using Unity;
using Unity.Extension;

namespace Repositories
{
    public class DependencyExtension : UnityContainerExtension
    {
        public DependencyExtension()
        {
            //IUnityContainer container = new UnityContainer();
        }

        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}
