using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        List<Expression<Func<T, bool>>> WhereExpressions { get; }
        List<Expression<Func<T, object>>> IncludeExpressions { get; }
    }
}