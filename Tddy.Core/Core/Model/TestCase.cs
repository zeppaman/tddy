using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tddy.Core.Model
{
    public class TypeRef { 
        public string FullyQualifiedAssemblyName { get; set; }
        public string TypeName { get; set; }

    }

    public class ClassRef: TypeRef
    {
        public string Name { get; set; }

    }

    public class DependencyRef : TypeRef
    {        

    }

    public class TestCase
    {
        public ClassRef Class { get;set; }

        public string DisplayName { get;set; }

        public string MethodName { get; set; }

        public List<DependencyRef> Dependencies { get; set; }

        public string Categories { get; set; }
    }
}
