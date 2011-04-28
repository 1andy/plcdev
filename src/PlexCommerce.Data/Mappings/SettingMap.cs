using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class SettingMap : ClassMap<Setting>
    {
        public SettingMap()
        {
            Id(x => x.Id, "SettingID");
            Map(x => x.Value).Length(10000);
        }
    }
}