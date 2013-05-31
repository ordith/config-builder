using System.Xml.Serialization;

namespace ConfigBuilderTask.Schema
{
    public class ConfigTemplate
    {
		[XmlAttribute("WorkingEnvironment")]
        public string WorkingEnvironment { get; set; }
		[XmlAttribute("WorkingEnvironmentFolder")]
	    public string WorkingEnvironmentFolder { get; set; }
        public CreateConfigTask[] Tasks { get; set; }
        public ConfigParameter[] Parameters { get; set; }

		public bool IsWorkingEnvironmentEnabled()
		{
			return !string.IsNullOrWhiteSpace(WorkingEnvironment) && !string.IsNullOrWhiteSpace(WorkingEnvironmentFolder);
		}
    }
}
