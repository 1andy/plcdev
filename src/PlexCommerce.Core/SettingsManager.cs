using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace PlexCommerce
{
    public class SettingsManager
    {
        private readonly ISession _session;

        public SettingsManager(ISession session)
        {
            _session = session;
        }

        public T GetValue<T>(string key)
        {
            return default(T);
        }

        public void SetValue<T>(string key, T value)
        {
        }
    }
}
