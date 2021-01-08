using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CH07.MVVMDemo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CH07.MVVMDemo.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


		private UserModel m_selectedUser;
		public UserModel SelectedUser
		{
			get { return m_selectedUser; }
			set
			{
				m_selectedUser = value;
				OnPropertyChanged("SelectedUser");
			}
		}

		private ObservableCollection<UserModel> m_userCollection;
		public ObservableCollection<UserModel> UserCollection
		{
			get { return m_userCollection; }
			set
			{
				m_userCollection = value;
				OnPropertyChanged("UserCollection");
			}
		}

		public MainWindowViewModel()
		{
			UserCollection = new ObservableCollection<UserModel>
			{
				new UserModel
				{
					Firstname = "User", Lastname = "One"
				},
				new UserModel
				{
					Firstname = "User", Lastname = "Two"
				},
				new UserModel
				{
					Firstname = "User", Lastname = "Three"
				},
				new UserModel
				{
					Firstname = "User", Lastname = "Four"
				},
			};
		}
	}
}
