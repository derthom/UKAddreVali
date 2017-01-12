using System.AddIn;
using System.Drawing;
using System.Windows.Forms;
using RightNow.AddIns.AddInViews;

////////////////////////////////////////////////////////////////////////////////
//
// File: WorkspaceAddIn.cs
//
// Comments:
//
// Notes: 
//
// Pre-Conditions: 
//
////////////////////////////////////////////////////////////////////////////////
namespace UKAddreVali
{
    public class WorkspaceAddIn : Panel, IWorkspaceComponent2
    {
        /// <summary>
        /// The current workspace record context.
        /// </summary>
        private IRecordContext _recordContext;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="inDesignMode">Flag which indicates if the control is being drawn on the Workspace Designer. (Use this flag to determine if code should perform any logic on the workspace record)</param>
        /// <param name="RecordContext">The current workspace record context.</param>
        public WorkspaceAddIn(bool inDesignMode, IRecordContext RecordContext)
        {
            _recordContext = RecordContext;
        }

        #region IAddInControl Members

        /// <summary>
        /// Method called by the Add-In framework to retrieve the control.
        /// </summary>
        /// <returns>The control, typically 'this'.</returns>
        public Control GetControl()
        {
            return this;
        }

        #endregion

        #region IWorkspaceComponent2 Members

        /// <summary>
        /// Sets the ReadOnly property of this control.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Method which is called when any Workspace Rule Action is invoked.
        /// </summary>
        /// <param name="ActionName">The name of the Workspace Rule Action that was invoked.</param>
        public void RuleActionInvoked(string ActionName)
        {
        }

        /// <summary>
        /// Method which is called when any Workspace Rule Condition is invoked.
        /// </summary>
        /// <param name="ConditionName">The name of the Workspace Rule Condition that was invoked.</param>
        /// <returns>The result of the condition.</returns>
        public string RuleConditionInvoked(string ConditionName)
        {
            return string.Empty;
        }

        #endregion
    }

    [AddIn("Workspace Factory AddIn", Version = "1.0.0.0")]
    public class WorkspaceAddInFactory : IWorkspaceComponentFactory2
    {
        #region IWorkspaceComponentFactory2 Members

        /// <summary>
        /// Method which is invoked by the AddIn framework when the control is created.
        /// </summary>
        /// <param name="inDesignMode">Flag which indicates if the control is being drawn on the Workspace Designer. (Use this flag to determine if code should perform any logic on the workspace record)</param>
        /// <param name="RecordContext">The current workspace record context.</param>
        /// <returns>The control which implements the IWorkspaceComponent2 interface.</returns>
        public IWorkspaceComponent2 CreateControl(bool inDesignMode, IRecordContext RecordContext)
        {
            return new WorkspaceAddIn(inDesignMode, RecordContext);
        }

        #endregion

        #region IFactoryBase Members

        /// <summary>
        /// The 16x16 pixel icon to represent the Add-In in the Ribbon of the Workspace Designer.
        /// </summary>
        public Image Image16
        {
            get { return Properties.Resources.AddIn16; }
        }

        /// <summary>
        /// The text to represent the Add-In in the Ribbon of the Workspace Designer.
        /// </summary>
        public string Text
        {
            get { return "WorkspaceAddIn"; }
        }

        /// <summary>
        /// The tooltip displayed when hovering over the Add-In in the Ribbon of the Workspace Designer.
        /// </summary>
        public string Tooltip
        {
            get { return "WorkspaceAddIn Tooltip"; }
        }

        #endregion

        #region IAddInBase Members

        /// <summary>
        /// Method which is invoked from the Add-In framework and is used to programmatically control whether to load the Add-In.
        /// </summary>
        /// <param name="GlobalContext">The Global Context for the Add-In framework.</param>
        /// <returns>If true the Add-In to be loaded, if false the Add-In will not be loaded.</returns>
        public bool Initialize(IGlobalContext GlobalContext)
        {
            return true;
        }

        #endregion
    }
}