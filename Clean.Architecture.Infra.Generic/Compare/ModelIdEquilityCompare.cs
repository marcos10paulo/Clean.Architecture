using Clean.Architecture.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Clean.Architecture.Infra.Generic.Compare
{
    public class ModelIdEquilityCompare : IEqualityComparer<BaseEntity>
    {

        public bool Equals(BaseEntity x, BaseEntity y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] BaseEntity obj)
        {
            return (obj == null) ? 0 : obj.Id.GetHashCode();
        }
    }
}
