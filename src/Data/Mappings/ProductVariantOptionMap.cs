using FluentNHibernate.Mapping;

namespace PlexCommerce.Mappings
{
    public sealed class ProductVariantOptionMap : ClassMap<ProductVariantOption>
    {
        public ProductVariantOptionMap()
        {
            Id(x => x.Id, "ProductVariantOptionID");
            Map(x => x.Name).Not.Nullable();

            References(x => x.Product).Not.Nullable().Column("ProductID").Cascade.All();
        }
    }


    public sealed class ProductVariantOptionValueMap : ClassMap<ProductVariantOptionValue>
    {
        public ProductVariantOptionValueMap()
        {
            //CompositeId().KeyReference(x => x.Option.Id).KeyReference(x => x.Variant.Id);
            CompositeId().KeyProperty(x => x.Option.Id, "ProductVariantOptionID").KeyProperty(x => x.Variant.Id, "ProductVariantID");
            
            //Id(x => x.Id, "ProductVariantOptionID");
            //Map(x => x.Name).Not.Nullable();
            Map(x => x.Value);

            References(x => x.Option).Not.Nullable().Column("ProductVariantOptionID").Cascade.All();
            References(x => x.Variant).Not.Nullable().Column("ProductVariantID").Cascade.All();
        }
    }
}