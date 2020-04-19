using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFStudy.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // virtual uses with LazyLoad
        public virtual Categoria Categoria { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
