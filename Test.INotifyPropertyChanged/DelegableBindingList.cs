using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestINotifyPropertyChanged
{
    /// <summary>
    /// 可提供非同步、同步觸發屬性變更事件的BindingList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegableBindingList<T> : BindingList<T>
    {
        private readonly ISynchronizeInvoke synchronizeInvoke;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="synchronizeInvoke">提供同步(非同步)invoke</param>
        public DelegableBindingList(ISynchronizeInvoke synchronizeInvoke)
        {
            this.synchronizeInvoke = synchronizeInvoke;
        }

        /// <summary>
        /// BindingList異動事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (this.synchronizeInvoke != null && this.synchronizeInvoke.InvokeRequired)
            {
                this.synchronizeInvoke.BeginInvoke(new Action<ListChangedEventArgs>(base.OnListChanged), new object[] { e });
            }
            else
            {
                base.OnListChanged(e);
            }
        }
    }
}
