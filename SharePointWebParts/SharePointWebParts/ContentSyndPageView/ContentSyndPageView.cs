using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace SharePointWebParts.ContentSyndPageView
{
    [ToolboxItemAttribute(false)]
    public class ContentSyndPageView :  System.Web.UI.WebControls.WebParts.WebPart 
    {
        ////// Visual Studio might automatically update this path when you change the Visual Web Part project item.
        ////private const string _ascxPath = @"~/_CONTROLTEMPLATES/SharePointWebParts/ContentSyndPageView/ContentSyndPageViewUserControl.ascx";

        ////protected override void CreateChildControls()
        ////{
        ////    Control control = Page.LoadControl(_ascxPath);
        ////    Controls.Add(control);
        ////}
 
        // A Div to display the Content of the Tab.
        private HtmlGenericControl _divTabContent;

    
 

        public override object WebBrowsableObject
        {
            // Return a reference to the Web Part instance.
            get { return this; }
        }

        public override EditorPartCollection CreateEditorParts()
        {
            ContentSyndConfigurationEditorPart editorPart = new ContentSyndConfigurationEditorPart();

            // The ID of the Editor part should be unique. So prefix it with the ID of the Web Part.
            editorPart.ID = this.ID + "_TabConfigurationEditorPart123";

            // Create a collection of Editor Parts and add them to the Editor Part collection.
            List<EditorPart> editors = new List<EditorPart> { editorPart };
            return new EditorPartCollection(editors);
        }

        public void SaveChanges()
        {
            // This method sets a flag indicating that the personalization data has changed.
            // This will allow the changes to the Web Part properties from outside the Web Part class.
            this.SetPersonalizationDirty();
        }

        protected override void CreateChildControls()
        {
            this._divTabContent = new HtmlGenericControl("div");
            this._divTabContent.ID = "divTabContent";

            //// Render the Tabs if the Count is more than zero.
            //if (this.TabList.Count > 0)
            //{
                 
            //}
            //else
            //{
            //    // If not tabs exist, Set the div text to,
            //    // suggest the user to Edit the Web Part and add Tabs.
            //    this._divTabContent.InnerHtml = "Edit this Web Part to add Tabs.";
            //}

            this.Controls.Add(_divTabContent);
        }

      
    }
}
