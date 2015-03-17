using System;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint.WebPartPages;
using SharePointWebParts.ContentSyndPageView;

namespace SharePointWebParts
{
    public class ContentSyndConfigurationEditorPart : EditorPart
    { 
        // The deployment path of the User Control
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/SharePointWebParts/ContentSyndPageView/ContentSyndPageViewUserControl.ascx";

        // The User Control Object ID
        const string UserControlID = "OperationsUserControl";

        // Declare a reference to the User Control
        ContentSyndPageViewUserControl configuratorControl;

        // Declare a reference to the Tab Editor Web Part
        private SharePointWebParts.ContentSyndPageView.ContentSyndPageView tabEditorWebPart;

        public ContentSyndConfigurationEditorPart()
        {
            this.Title = "Tab ContentSyndConfigurationEditorPart";
        }
         

        public override bool ApplyChanges()
        {
            this.tabEditorWebPart = this.WebPartToEdit as SharePointWebParts.ContentSyndPageView.ContentSyndPageView;

            // Set the Web Part's TabList
           

            // Call the webpart's personalization dirty            
            this.tabEditorWebPart.SaveChanges();
            return true;
        }

        public override void SyncChanges()
        {
            // sync with the new property changes here
            EnsureChildControls();

            this.tabEditorWebPart = this.WebPartToEdit as SharePointWebParts.ContentSyndPageView.ContentSyndPageView;
             
        }

        protected override void CreateChildControls()
        {
            // Get a reference to the Edit Tool Pane.
            ToolPane pane = this.Zone as ToolPane;
           

            // Load the User Control and it to the Controls Collection of the Editor Part
            this.configuratorControl =
                this.Page.LoadControl(_ascxPath) as ContentSyndPageViewUserControl;
            this.configuratorControl.ID = ContentSyndConfigurationEditorPart.UserControlID;
            this.Controls.Add(configuratorControl);
        }

      
    }
}
