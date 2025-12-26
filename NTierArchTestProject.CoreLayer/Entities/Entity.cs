using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.CoreLayer.Entities
{
    //Abstract class oluşturdum base class olarak düşünebiliriz.
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id= Guid.NewGuid();
        }
    }
}
