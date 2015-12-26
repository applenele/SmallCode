//------------------------------------------------------------------------------
// <copyright company="Tunynet">
//     Copyright (c) Tunynet Inc.  All rights reserved.
// </copyright> 
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace NW.Utility
{
    /// <summary>
    /// 字符处理状态
    /// </summary>
    public enum WordFilterStatus
    {
        /// <summary>
        /// 匹配到需要替代的关键字
        /// </summary>
        Replace,

        /// <summary>
        /// 匹配到禁止提交的关键字
        /// </summary>
        Banned
    }
}
