using System.IO;
using System.Xml.Serialization;
using ConfigBuilderTask.Schema;

namespace ConfigValueCreator
{
	class Program
	{
		/// <summary>
		///     This is just an easy way to generate the xml if you've changed the schema significantly.
		///		Change the object to what you want your template to be,
		///		Set this project as your startup project,
		///		Run it in debug mode,
		///		Then check ./bin/Debug/ConfigValues.xml folder for the xml.
		/// </summary>
		static void Main(string[] args)
		{
			var configTask = new ConfigValues
			{
				WorkingEnvironment = "Dev",
				Tasks = new CreateConfigTask[] {
                   new CreateConfigTask {
                       NameFormat = "App.{0}.config",
                       InputFile = "./App.config",
                       OutputFolderFormat = "./TestOutput"
                   }
                },
				Parameters = new ConfigParameter[]{
                    new ConfigParameter {
                        Name = "ReplaceMe",
                        Values = new ConfigParameterValue[] {
									new ConfigParameterValue {
										Environment = "Dev",
										Value = "Replaced1"
									}
								},
						DefaultValue = "DefaultReplaced"
                    },
                    new ConfigParameter {
                        Name = "ReplaceMe2",
                        Values = new ConfigParameterValue[] {
									new ConfigParameterValue {
										Environment = "Dev",
										Value = "Replaced3"
									},
									new ConfigParameterValue {
										Environment = "Stage",
										Value = "Replaced4"
									},	
								}
                    },
                }
			};

			var writer = new XmlSerializer(typeof(ConfigValues));

			using (var file = new StreamWriter("./ConfigValues.xml"))
			{
				writer.Serialize(file, configTask);
				file.Close();
			}
		}
	}
}