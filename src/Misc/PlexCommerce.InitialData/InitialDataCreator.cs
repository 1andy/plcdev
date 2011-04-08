using NHibernate;

namespace PlexCommerce
{
    public class InitialDataCreator
    {
        private readonly ISession _session;

        public InitialDataCreator(ISession session)
        {
            _session = session;
        }

        public void CreateInitialData()
        {
            using (var transaction = _session.BeginTransaction())
            {
                transaction.Commit();
            }
        }
    }
}
