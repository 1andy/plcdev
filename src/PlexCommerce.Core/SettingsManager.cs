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
            Type type = typeof(T);

            var setting = _session.Get<Setting>(key);
            if (setting == null || setting.Value == null)
            {
                return default(T);
            }

            string value = setting.Value;
            object result;

            if (type == typeof(bool))
            {
                result = Convert.ToBoolean(value);
            }
            else
            {
                throw new NotSupportedException();
            }

            return (T)result;
        }

        public void SetValue<T>(string key, T value)
        {
            var setting = new Setting { Id = key };

            if (value == null || value.Equals(default(T)))
            {
                setting.Value = null;
            }
            else
            {
                setting.Value = Convert.ToString(value);
            }

            using (var transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(setting);
                transaction.Commit();
            }
        }
    }
}
