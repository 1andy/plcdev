using System;
using System.Linq.Expressions;
using LinqKit;

namespace PlexCommerce.Web
{
    public static class SubformUtil
    {
        public static Func<Expression<Func<TFormModel, string>>, Expression<Func<TViewModel, string>>>
            GetConverter<TViewModel, TFormModel>(Expression<Func<TViewModel, TFormModel>> expr)
        {
            return m => Linq.Expr((TViewModel vm) => m.Invoke(expr.Invoke(vm))).Expand().Expand();
        }
    }
}