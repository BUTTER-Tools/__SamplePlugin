using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using PluginContracts;
using OutputHelperLib;


namespace SamplePlugin
{
    public class SamplePlugin : Plugin
    {


        public string[] InputType { get; } = { "" };
        public string OutputType { get; } = "";

        public Dictionary<int, string> OutputHeaderData { get; set; } = new Dictionary<int, string>() { { 0, "TokenizedText" } };
        public bool InheritHeader { get; } = false;

        #region Plugin Details and Info

        public string PluginName { get; } = "Sample Plugin";
        public string PluginType { get; } = "Samples";
        public string PluginVersion { get; } = "1.0.0";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "Just a bare-bones example of the plugin layout.";
        public string PluginTutorial { get; } = "Coming Soon";
        public bool TopLevel { get; } = false;


        public Icon GetPluginIcon
        {
            get
            {
                return Properties.Resources.icon;
            }
        }

        #endregion



        public void ChangeSettings()
        {

            MessageBox.Show("This plugin does not have any settings to change.",
                    "No Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

        }





        public Payload RunPlugin(Payload Input)
        {



            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            pData.SegmentID = Input.SegmentID;


            for (int i = 0; i < Input.StringList.Count; i++)
            {

            }

            return (pData);

        }



        public void Initialize() { }

        public bool InspectSettings()
        {
            return true;
        }

        public Payload FinishUp(Payload Input)
        {
            return (Input);
        }


        #region Import/Export Settings
        public void ImportSettings(Dictionary<string, string> SettingsDict)
        {

        }

        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();
            return (SettingsDict);
        }
        #endregion

    }
}
