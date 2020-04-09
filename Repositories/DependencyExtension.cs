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
            Container.RegisterType<IFoodCategoryRepository, FoodCategoryRepository>();
            Container.RegisterType<IFoodRepository, FoodRepository>();
            Container.RegisterType<IMenuRepository, MenuRepository>();
            Container.RegisterType<IFeedBackRepository, FeedBackRepository>();
            Container.RegisterType<IDocumentRepository, DocumentRepository>();
            Container.RegisterType<IDesignCategoryRepository, DesignCategoryRepository>();
            Container.RegisterType<IDesignRepository, DesignRepository>();
        }
    }
}
