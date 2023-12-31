﻿namespace Tddy.Core.Model
{
    public class TypeRef
    {
        public string FullyQualifiedAssemblyName { get; set; }
        public string TypeName { get; set; }
    }

    public class ClassRef : TypeRef
    {
        public string Name { get; set; }
    }

    public class DependencyRef : TypeRef
    {
    }

    public class TestCase
    {
        public ClassRef Class { get; set; }

        public string DisplayName { get; set; }

        public string MethodName { get; set; }

        public List<DependencyRef> Dependencies { get; set; }

        public string Categories { get; set; }

        public override string ToString()
        {
            return DisplayName ?? MethodName + "(" + Class?.Name + ")";
        }
    }
}