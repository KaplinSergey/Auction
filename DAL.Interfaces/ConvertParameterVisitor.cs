using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public class ConvertParameterVisitor<TSource, TTarget> : ExpressionVisitor
    {
        private ParameterExpression _parametrExpression;

        public ParameterExpression ParametrExpression
        {
            get { return _parametrExpression; }
        }

        public ConvertParameterVisitor(ParameterExpression parametrExpression)
        {
            _parametrExpression = parametrExpression;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parametrExpression;
        }
        /// <summary>
        /// Called in case expression tree node is a reference to a property or field and convet TSours property to TTareget property
        /// </summary>
        /// <param name="node"></param>
        /// <returns>TTareget property or original expression</returns>

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TSource))
            {
                return Expression.MakeMemberAccess(this.Visit(node.Expression), typeof(TTarget).GetMember(node.Member.Name).FirstOrDefault());
            }
            return base.VisitMember(node);
        }
    }
}
