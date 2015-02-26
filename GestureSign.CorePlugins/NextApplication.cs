﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using GestureSign.Common.Plugins;
using ManagedWinapi.Windows;

using System.Windows.Controls;

namespace GestureSign.CorePlugins
{
	public class NextApplication : IPlugin
	{
		#region Private Variables

		IHostControl _HostControl = null;

		#endregion

		#region IAction Properties

		public string Name
		{
			get { return "下一窗口"; }
		}

		public string Description
		{
			get { return "切换到下一个窗口 (相当于 Alt + Tab)"; }
		}

		public UserControl  GUI
		{
			get { return null; }
		}

		public string Category
		{
			get { return "Windows"; }
		}

		public bool IsAction
		{
			get { return true; }
		}

		#endregion

		#region IAction Methods

		public void Initialize()
		{

		}

		public bool Gestured(PointInfo ActionPoint)
		{
			try
			{
				SystemWindow.ForegroundWindow = SystemWindow.AllToplevelWindows.Where
												(w => w.Visible &&	// Must be a visible windows  
												 //w.WindowState != FormWindowState.Minimized && 
												 w.Title != "" &&	// Must have a window title
												//(w.Style & WindowStyleFlags.POPUPWINDOW) 
												//	!= WindowStyleFlags.POPUPWINDOW &&
												(w.ExtendedStyle & WindowExStyleFlags.TOOLWINDOW)
													!= WindowExStyleFlags.TOOLWINDOW	// Must not be a tool window
												).Last();
			}
			catch (InvalidOperationException ex)
			{
				// Do nothing here, no other window open..
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Oops! - "+ex.Message);
			}
			finally { }
			return true;
		}

		public void Deserialize(string SerializedData)
		{
			// Nothing to deserialize
		}

		public string Serialize()
		{
			// Nothing to serialize, send empty string
			return "";
		}

		public void ShowGUI(bool IsNew)
		{
			// Nothing to do here
		}

		#endregion

		#region Host Control

		public IHostControl HostControl
		{
			get { return _HostControl; }
			set { _HostControl = value; }
		}

		#endregion
	}
}