using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hk.Application1.Repository.Configurations
{
    public class EntityBaseConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public EntityBaseConfiguration()
        {
        }
    }
}
