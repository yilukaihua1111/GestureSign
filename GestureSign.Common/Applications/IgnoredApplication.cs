﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestureSign.Common.Applications
{
	public class IgnoredApplication : ApplicationBase, INotifyPropertyChanged
	{
		#region Contructors

		protected IgnoredApplication()
		{

		}

		public IgnoredApplication(string Name, MatchUsing MatchUsing, string MatchString, bool IsRegEx,bool isEnabled)
		{
			this.Name = Name;
			this.MatchUsing = MatchUsing;
			this.MatchString = MatchString;
			this.IsRegEx = IsRegEx;
            this.IsEnabled = isEnabled;
		}

		#endregion

        private bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set { SetProperty(ref isEnabled, value); }
        }

		#region IApplication Properties

		public override List<IAction> Actions
		{
			get { return null; }
			set { /* Only exists for serialization purposes */ }
		}

		#endregion

		#region IApplication Methods

		public override void AddAction(IAction Action)
		{
			throw new NotSupportedException();
		}

		public override void RemoveAction(IAction Action)
		{
			throw new NotSupportedException();
		}

		public override void RemoveAllActions(Predicate<IAction> Match)
		{
			throw new NotSupportedException();
		}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return;

            storage = value;
            this.OnPropertyChanged(propertyName);
        }
		#endregion	
	}
}
