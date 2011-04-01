using NHibernate;

namespace PlexCommerce.Web.Controllers
{
    public abstract class StoreControllerBase : PlexControllerBase
    {
        private readonly ISession _session;

        protected StoreControllerBase(ISession session)
        {
            _session = session;
        }

        protected override void SetAdditionalViewModelData(object model)
        {
            var sharedLayoutViewModel = model as SharedLayoutViewModel;
            if (sharedLayoutViewModel != null)
            {
                sharedLayoutViewModel.PageTitle = "123";
            }

            base.SetAdditionalViewModelData(model);
        }
    }
}