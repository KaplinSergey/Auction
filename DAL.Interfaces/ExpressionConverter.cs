using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public static class ExpressionConverter
    {
        public static Expression<Func<TTarget, bool>> Convert<TSource, TTarget>(Expression<Func<TSource, bool>> expression)
        {
            var visitor = new ConvertParameterVisitor<TSource, TTarget>(Expression.Parameter(typeof(TTarget), expression.Parameters[0].Name));
            var newExpression = Expression.Lambda<Func<TTarget, bool>>(visitor.Visit(expression.Body), visitor.ParametrExpression);
            return newExpression;
        }
    }
}
