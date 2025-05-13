using System;
using System.Collections.Generic;
using Avalonia.Input;

namespace SuikaiLauncher.Modules.Base{
    /// <summary>
    /// 弹窗管理器
    /// </summary>
    public class MsgBox{
        private static List<MessageBox>  MsgBoxWaitList = new();
        private static bool HasMsgBox;
        private static readonly object ShowMsgLock = new object[1];
        /// <summary>
        /// 添加一个新的弹窗
        /// </summary>
        /// <param name="MsgboxObject"></param>
        public static void Append(MessageBox MsgboxObject){
            lock(ShowMsgLock){
                try{
                    MsgBoxWaitList.Add(MsgboxObject);

                }catch{
                    
                }
            }
        }
    }
    /// <summary>
    /// 所有弹窗的基类
    /// </summary>
    public class MessageBox{
        /// <summary>
        /// 标题
        /// </summary>
        public string Title = "提示";
        /// <summary>
        /// 文本
        /// </summary>
        public string Message = "";
        /// <summary>
        /// 回调函数
        /// </summary>
        public Action<object>? Callback;
        /// <summary>
        /// 按钮 1 的文本
        /// </summary>
        public string Btn1Text = "确定";
        /// <summary>
        /// 按钮 2 的文本
        /// </summary>
        public string Btn2Text = "";
        /// <summary>
        /// 按钮 3 的文本
        /// </summary>
        public string Btn3Text = "";
        /// <summary>
        /// 是否可输入
        /// </summary>
        public bool Inputable;
        /// <summary>
        /// 自定义弹窗代码，用于默认模板内没有对应模板的情况（需要手写 XAML 代码）
        /// </summary>
        public string? Code = null;
        /// <summary>
        /// 验证规则
        /// </summary>
        public object? ValidateRules;
    }
}