using ClientesProdutos.Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesProdutos.Infrastructure.Persistence.Mappings
{
    public class ProdutoMap:ClassMap<ProdutoEntity>
    {
        public ProdutoMap()
        {
            Table("Produto");
            Id(x => x.ID);
            Map(x => x.Nome).Column("Nome").Length(150);
            Map(x => x.Created).Column("Created");
            Map(x => x.CreatedBy).Column("CreatedBy").Length(150);
            Map(x => x.LastModified).Column("LastModified");
            Map(x => x.LastModifiedBy).Column("LastModifiedBy").Length(150);


        }
    }
}
