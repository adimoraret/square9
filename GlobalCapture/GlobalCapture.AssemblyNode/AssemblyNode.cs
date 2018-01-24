using System;
using System.Collections.Generic;

namespace GlobalCapture.AssemblyNode
{
    public class AssemblyNode
    {
        private readonly string _assemblyNodeLogFile;

        public AssemblyNode()
        {
            var configManager = new ConfigManager();
            _assemblyNodeLogFile = configManager.GetAppSetting("LogFile");
        }

        public Dictionary<string, string> RunCallAssembly(Dictionary<string, string> Input)
        {
            try
            {
                Log.AppendLine("GlobalCapture AssemblyNode Starting.");
                foreach (var kvp in Input)
                {
                    Log.AppendLine("Key: " + kvp.Key + " | Value: " + kvp.Value);
                }
                Log.AppendLine("GlobalCapture AssemblyNode Finished");
                Log.SaveToFile(_assemblyNodeLogFile);
            }
            catch(Exception ex)
            {
                Log.AppendError(ex);
                Log.AppendLine("GlobalCapture AssemblyNode Finished");
                Log.SaveToFile(_assemblyNodeLogFile);
                throw;
            }

            return new Dictionary<string, string>();
        }
    }
}
