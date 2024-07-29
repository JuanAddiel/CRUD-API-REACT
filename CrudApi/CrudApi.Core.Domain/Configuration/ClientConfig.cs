using CrudApi.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Core.Domain.Configuration
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        //Hacemos uso de IEntityTypwConfiguration para poder realizar las configuraciones de cada tabla
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c=>c.LastName).IsRequired().HasMaxLength(150);
            builder.Property(c=>c.Name).IsRequired().HasMaxLength(150);
            builder.Property(c=>c.BirthDate).IsRequired();
            builder.Property(c=>c.Phone).IsRequired().HasMaxLength(9);
            builder.Property(c=>c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c=>c.Direction).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Age).IsRequired();
            builder.Property(c=>c.CreatedBy).IsRequired().HasMaxLength(200);
            builder.Property(c=>c.LastModifiedBy).IsRequired().HasMaxLength(200);


        }
    }
}
