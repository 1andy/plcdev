using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace PlexCommerce
{
    public class SettingsStorage
    {
        private readonly ISession _session;

        public SettingsStorage(ISession session)
        {
            _session = session;
        }

        public T GetValue<T>(string key)
        {
            return default(T);
        }
    }
}
