using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Avalonia.Threading;

namespace SuikaiLauncher.Modules.Base{
    public class ThreadOperation{
        /// <summary>
        /// 在 UI 线程执行代码，不等待返回
        /// </summary>
        /// <param name="Operation">要执行的代码</param>
        public static void InvokeInUI(Action Operation){
            Dispatcher.UIThread.Post(Operation);
        }
        public async static Task<object?> InvokeInUIWait(Task<object?> Operation){
            return await Dispatcher.UIThread.InvokeAsync(async() => {
                return await Operation;
            });
        }
    }

}