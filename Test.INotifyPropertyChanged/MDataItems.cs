﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TestINotifyPropertyChanged
{
    public class MDataItems : BindingList<CustomData>
    {
        private readonly ISynchronizeInvoke synchronizeInvoke;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="synchronizeInvoke">提供同步(非同步)invoke</param>
        public MDataItems( )
        { 
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="synchronizeInvoke">提供同步(非同步)invoke</param>
        public MDataItems(ISynchronizeInvoke synchronizeInvoke)
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
