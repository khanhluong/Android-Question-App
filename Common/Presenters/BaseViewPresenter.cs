using System;
using System.Threading.Tasks;
using Common.IViews;

namespace Common.Presenters
{
    public abstract class BaseViewPresenter
    {
        public IBaseView View { get; set; }
        public BaseViewPresenter(IBaseView view)
        {
            View = view;
        }

        public abstract void Init();

        //public abstract void Destroy();

    }

    public abstract class BaseViewPresenter<V> : BaseViewPresenter where V : IBaseView
    {

        public BaseViewPresenter(V view) : base(view)
        {
        }

        public new V View
        {
            get
            {
                return (V)base.View;
            }
            set
            {
                base.View = value;
            }
        }
    }
}
