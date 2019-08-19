using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncWpfTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVm dataVM = new MainWindowVm();
        private object _lockList=new object();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = dataVM;
            BindingOperations.EnableCollectionSynchronization(dataVM.Mlist, _lockList);
        }

        private void UpdateListView(int count) {
           

                    TestItem item = new TestItem();
                    item.Count = count.ToString();
                    dataVM.Mlist.Add(item);
             
            Console.WriteLine("页面数据"+count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private int test(int count) {
            int countNum = 0;
            for (int i = 0; i < count; i++)
            {

                for (int j = 0; j < count; j++)
                {

                    
                     countNum++;
                }
            }
            return countNum;
        }
        private Task<int> testAsync(int count)
        {

           return Task.Run<int>(() =>
            {
                int countNum = 0;
                for (int i = 0; i < count; i++)
                {

                    for (int j = 0; j < count; j++)
                    {


                        countNum++;
                    }
                }
                return countNum;
            });
        }
        private async void getCount() {
            int result = await testAsync(25);
            Console.WriteLine("getCount"+result.ToString());
            await Task.Run(() =>
            {
                for (int i=0;i<result;i++) {

                    UpdateListView(i);
                }
            });
        }
        private  void button_Click(object sender, RoutedEventArgs e)
        {
            getCount();
            Console.WriteLine("no sleep");
            #region 基于委托的异步
            //Func<int,int> func = test;
            //Action<int> action = UpdateListView;
            //int count = 1000;
            ////this.Dispatcher.Invoke(action, count);
            
            //func.BeginInvoke(count, result =>
            //{
            //    int resultTest = func.EndInvoke(result);
            //    Console.WriteLine("test 结果"+ resultTest);
            //    for (int i=0;i< resultTest; i++) {

            //        //Thread.Sleep(10);
            //        this.Dispatcher.Invoke(action, i);
            //    }
                
            //}, null);
            #endregion
        }
    }
}
