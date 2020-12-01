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

        //These are important — they're just strings that are used to identify a "type" for your plugin's
        //accepted input and output. The BUTTER client will not allow users to connect plugin nodes
        //if the listed input/output for each are not compatible.
        public string[] InputType { get; } = { "Some Type of Input" };
        public string OutputType { get; } = "OutputArray";

        //this is a dictionary that is used as the header if you're writing output from this plugin. The keys are the column numbers (zero indexed)
        //and the values are the header row texts.
        public Dictionary<int, string> OutputHeaderData { get; set; } = new Dictionary<int, string>() { { 0, "TokenizedText" } };
        
        //this is for if you want to inhereit the header row from the previous plugin. Most of the time, this will be a "no" 
        public bool InheritHeader { get; } = false;



        //this is used not only for Blueberries, but mainly for the BUTTER client interface to give info to the users.
        #region Plugin Details and Info
        //Give your plugin a unique name
        public string PluginName { get; } = "Sample Plugin";
        //PluginType is used by the interface to "classify" what category your plugin goes under. You can use an existing one or a custom one.
        public string PluginType { get; } = "Samples";
        public string PluginVersion { get; } = "1.0.0";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "Just a bare-bones example of the plugin layout.";
        //The Tutorial should be a URL.
        public string PluginTutorial { get; } = "Coming Soon";

        //A "top level" plugin is one that *must* be situated at the top of a plugin chain for analysis. This would be for things like input plugins.
        //Most of the time, this is going to be "false" unless you're developing a plugin that is intended to read in input and hand it to other plugins.
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

            //This is what will get called when a user goes to change the settings for this plugin.
            //Most of my plugins use a WinForm to allow users to change settings, but anything works.
            MessageBox.Show("This plugin does not have any settings to change.",
                    "No Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

        }




        //This is the big thing right here — this is what actually gets run during analysis / applied to each input.
        //The important thing is that 
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



        public void Initialize() 
        { 
            //code in this method is run when you "initialize" the plugin. Basically, once the user chooses to run a pipeline,
            //the BUTTER client goes through and runs this for each plugin prior to things really taking off.
        }



        public bool InspectSettings()
        {
            //This is run before the pipeline is properly executed. This should be used to check and see if the user's settings
            //for this plugin are valid. For example, if they have failed to set certain options, or if options are incorrect,
            //you can check that here then return "false" if they fail to meet some criteria.
            return true;
        }

        public Payload FinishUp(Payload Input)
        {
            //this is the last thing that will be run for this plugin after all texts have been processed. This can be useful for
            //dropping some stuff back out of RAM, or for pooling data together and then handing it all to the output writer at the
            //very end of text processing.
            return (Input);
        }



        //these methods take and give a dictionary<string,string> for pipeline importing/exporting
        //all settings that you want users to be able to restore from an XML file must be "flattened" into strings
        //for later importing. You can also provide the user with messages here if you'd like.
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
