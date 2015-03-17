using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Collections;

namespace SharePointWebParts.ContentSyndPageView
{
    public partial class ContentSyndPageViewUserControl : UserControl
    {
        private ContentSyndConfigurationEditorPart parentEditorPart;
        string FEEDURL = "http://t.cdc.gov/feed.aspx?tpc=26816&days=20";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.parentEditorPart = this.Parent as ContentSyndConfigurationEditorPart;

            // Call Sync Changes on the Editor Part, of it to read the Tab List from the Web Part
            this.parentEditorPart.SyncChanges();
            

            // Check if this is the first Page_Load of the control
            if (this.hiddenFieldDetectRequest.Value == "0")
            {
                this.hiddenFieldDetectRequest.Value = "1"; 
            }

            PopulateTopicDropDown();
        } 

        private void ApplyChanges()
        {
            // Call the ApplyChanges method of the Parent Editor Part class.
            this.parentEditorPart.ApplyChanges();
        }

        private void PopulateTopicDropDown()
        {
            //loading Topics 
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(FEEDURL);
            XmlNodeList elemList = xmldoc.GetElementsByTagName("content:Topic");
            for (int i = 0; i < elemList.Count; i++)
            {
                string name = elemList[i].Attributes["TopicName"].Value.ToString();
                string id = elemList[i].Attributes["TopicId"].Value.ToString();

                if (ddlTopic.Items.Contains(ddlTopic.Items.FindByValue(id)) == false)
                {
                    this.ddlTopic.Items.Add(new ListItem(name, id));
                }
            }
            this.ddlTopic.DataBind();
        }

        protected void ddlTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTopicName = this.ddlTopic.SelectedItem.Text.ToString();
            string selectedTopicValue = this.ddlTopic.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(selectedTopicName) && !string.IsNullOrEmpty(selectedTopicValue))
            {
                LoadTitleByTopicName(selectedTopicName, selectedTopicValue);
            }
        }


        private void LoadTitleByTopicName(string selectedTopicName, string selectedTopicValue)
        {
            ArrayList arrResult = new ArrayList();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(FEEDURL);
            XmlNodeList referenceNodes = xmlDoc.GetElementsByTagName("content:Topic");
            this.ddlTitle.Items.Clear();
            foreach (XmlNode Node in referenceNodes)
            {
                if (Node.Attributes["TopicName"] != null && (Node.Attributes["TopicName"].Value.ToString() == selectedTopicName || Node.Attributes["TopicName"].Value.ToString() == selectedTopicValue))
                {
                    string _titleName = Node.ParentNode.ParentNode.Attributes["Title"].Value;
                    string _titleGuid = Node.ParentNode.ParentNode.Attributes["GUID"].Value;
                    if (!arrResult.Contains(_titleName))
                    {
                        //arrResult.Add(_titleName);
                        this.ddlTitle.Items.Add(new ListItem(_titleName, _titleGuid));
                    }
                }
            }

            if (this.ddlTitle.Items.Count > 0)
            {
                this.ddlTitle.DataBind();
            }
        }
      

    }
}
