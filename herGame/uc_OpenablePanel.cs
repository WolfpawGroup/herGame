using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace herGame
{
	public partial class uc_OpenablePanel : UserControl
	{
		private Control _attachedControl { get; set; } = null;
		public Control AttachedControl { get { return _attachedControl; } set { _attachedControl = value; if (!HasEventHandler(_attachedControl, "Click")) { _attachedControl.Click += attachedControl_Click; }; } }
		
		private attachment _controlAttachment { get; set; }
		[Browsable(false)]
		public attachment ControlAttachment
		{
			get
			{
				return _controlAttachment;
			}
			set
			{
				_controlAttachment = value;
				if (value.childObject != null && FromHandle(value.childObject) != null)
				{
					AttachedControl = FromHandle(value.childObject);
				}
			}
		}

		private int _PanelHeight { get; set; } = 50;
		[Browsable(true), Category("custom_Design")]
		public int PanelHeight  { get { return _PanelHeight; } set { _PanelHeight = value; } }

		private int _PanelWidth { get; set; } = 100;
		[Browsable(true), Category("custom_Design")]
		public int PanelWidth { get { return _PanelWidth; } set { _PanelWidth = value; } }
		
		private bool _StartClosed { get; set; }
		[Browsable(true), Category("custom_Design")]
		public bool StartClosed { get { return _StartClosed; } set { _StartClosed = value; openClose(value, true); } }

		private int _OpenCloseInterval { get; set; } = 10;
		[Browsable(true), DefaultValue(10), Category("custom_Design"), Description("Timer Delay for opening/closing animation")]
		public int OpenCloseInterval { get { return _OpenCloseInterval; } set { _OpenCloseInterval = value; } }

		Timer t = new Timer();
		public bool PanelIsOpen = false;

		public uc_OpenablePanel()
		{
			InitializeComponent();
			Load += Uc_OpenablePanel_Load;
		}

		private bool HasEventHandler(Control control, string eventName)
		{
			EventHandlerList events =
				(EventHandlerList)
				typeof(Component)
				 .GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance)
				 .GetValue(control, null);

			object key = typeof(Control)
				.GetField(eventName, BindingFlags.NonPublic | BindingFlags.Static)
				.GetValue(null);

			Delegate handlers = events[key];

			return handlers != null && handlers.GetInvocationList().Any();
		}

		public void openClose(bool oc)
		{
			openClose(oc, false);
		}

		public void openClose(bool oc, bool isStartValue)
		{
			if (isStartValue)
			{
				if (oc)
				{
					//TODO: manage opening
				}
				else
				{

				}
			}
			else
			{

			}

			PanelIsOpen = oc;
		}

		private void Uc_OpenablePanel_Load(object sender, EventArgs e)
		{
			t.Interval = _OpenCloseInterval == 0 ? 10 : _OpenCloseInterval;
			if(AttachedControl != null)
			{
				AttachedControl.Click += attachedControl_Click;
			}
		}

		private void attachedControl_Click(object sender, EventArgs e)
		{
			
		}
	}

	public class attachment
	{
		public attachmentPoint attachPoint { get; set; }
		public slideDirection slideMode { get; set; }

		public IntPtr parentObject { get; set; }
		public IntPtr childObject { get; set; }
	}

	public enum attachmentPoint
	{
		TopAttach,
		RightAttach,
		BottomAttach,
		LeftAttach,
		None
	}

	public enum slideDirection
	{
		SlideUp_AnchorTop,
		SlideUp_AnchorBottom,
		SlideRight_AnchorRight,
		SlideRight_AnchorLeft,
		SlideDown_AnchorTop,
		SlideDown_AnchorBottom,
		SlideLeft_AnchorRight,
		SlideLeft_AnchorLeft,
		None
	}


}
