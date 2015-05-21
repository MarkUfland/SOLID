using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public class QueryTranslator
    {

        public virtual Expression<Func<T, bool>> CreateLambda<T>(Query query)
        {
            IList<Expression> expressions = new List<Expression>();

            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "o");

            foreach (Parameter p in query.GetParameters())
            {

                //MemberExpression memberExpression = Expression.PropertyOrField(parameterExpression, p.Name);

                Expression memberExpression = parameterExpression;

                foreach (var part in p.Name.Split('.'))
                {
                    memberExpression = Expression.PropertyOrField(memberExpression, part);
                }



                ConstantExpression constantExpression = Expression.Constant(p.Value, p.Value.GetType());

                switch (p.Criteria)
                {
                    case Criteria.EqualTo:

                        expressions.Add(Expression.Equal(memberExpression, constantExpression));
                        break;

                    case Criteria.NotEqualTo:

                        expressions.Add(Expression.NotEqual(memberExpression, constantExpression));
                        break;

                    case Criteria.GreaterThan:

                        expressions.Add(Expression.GreaterThan(memberExpression, constantExpression));
                        break;

                    case Criteria.LessThan:

                        expressions.Add(Expression.LessThan(memberExpression, constantExpression));
                        break;
                }

            }

            if (expressions.Count() > 1)
            {
                Expression expression = expressions[0];

                for (int count = 0; count < expressions.Count() - 1; count++)
                {
                    expression = Expression.AndAlso(expression, expressions[count + 1]);
                }

                return Expression.Lambda<Func<T, bool>>(expression, parameterExpression);

            }
            else
            {
                return Expression.Lambda<Func<T, bool>>(expressions.First(), parameterExpression);
            }
        }
    }
}
