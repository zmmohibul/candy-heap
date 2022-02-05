using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public List<Expression<Func<T, bool>>> WhereExpressions { get; } = new List<Expression<Func<T, bool>>>();
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new List<Expression<Func<T, object>>>();

        public void AddWhereExpression(Expression<Func<T, bool>> whereExpression)
        {
            this.WhereExpressions.Add(whereExpression);
        }

        public void AddIncludeExpression(Expression<Func<T, object>> includeExpression)
        {
            this.IncludeExpressions.Add(includeExpression);
        }
    }
}