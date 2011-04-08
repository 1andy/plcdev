using System.Diagnostics;
using System.IO;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace PlexCommerce
{
    public class InitialDataCreator
    {
        private readonly ISession _session;

        public InitialDataCreator(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Creates countries and other vital data if it is missing in the database
        /// (most likely during inital application load)
        /// </summary>
        public void CreateInitialDataIfMissing()
        {
            using (var transaction = _session.BeginTransaction())
            {
                if (_session.Query<Country>().Count() > 0)
                {
                    Trace.WriteLine("There is already some data in DB. Exiting.", "CreateInitialDataIfMissing");
                    return;
                }

                CreateCountries();

                transaction.Commit();
            }
        }

        private void CreateCountries()
        {
            using (var stream = File.Open(@"D:\Projects\pc\plcdev\src\Misc\PlexCommerce.InitialData\Data\Countries.csv", FileMode.Open))
            {
                var data = CsvReader.ReadCsv(stream);
                foreach (dynamic row in data)
                {
                    var country = new Country
                                  {
                                      Id = int.Parse(row.Id),
                                      Name = row.Name
                                  };

                    _session.Save(country);
                }
            }
        }
    }
}
