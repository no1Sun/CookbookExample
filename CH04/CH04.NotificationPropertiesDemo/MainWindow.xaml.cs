using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.ComponentModel;

namespace CH04.NotificationPropertiesDemo
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        


        // 1. CLR Property 추가
        public string Department { get { return "Software Engineering"; } }

        private string personName;
        public string PersonName
        {
            get { return personName; }
            set
            {
                personName = value;
                //Property 값 변경되면 UI를 업데이트하도록 
                //OnPropertyChanged이벤트에 Property 이름을 넣어준다.
                OnPropertyChanged("PersonName");
            }
        }


        //2. 이벤트 구현 추가

        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello " + PersonName);
        }
        private void OnReset(object sender, RoutedEventArgs e)
        {
            PersonName = string.Empty;
        }



        //3. 클래스에 INotifyPropertyChanged 인터페이스 추가 
        //4. using System.ComponentModel; 네임스페이스 추가
        //5. 클래스 내부에 PropertyChanged event 구현 추가
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            //in C# 7.0 and above
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //prior to C# 7.0
            //var handler = PropertyChanged;
            //if (handler != null)
            //{
            // handler(this, new PropertyChangedEventArgs(propertyName));
            //}
        }
    }


}
