﻿using NLog;
using NLog.Config;
using NLog.Targets;

namespace Glimpse.Core.Logging
{
    public class GlimpseLoggerFactory
    { 
        private LogFactory factory;
        private bool loggingEnabled;

        public GlimpseLoggerFactory(bool loggingEnabled)
        {
            this.loggingEnabled = loggingEnabled;
            factory = BuildFactory(); 
        }

        public Logger CreateLogger(string name)
        {
            if (!loggingEnabled)
                return LogManager.CreateNullLogger();
            return factory.GetLogger(name);
        }
         
        private LogFactory BuildFactory()
        {
            // Step 1. Create configuration object 
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration  
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            // Step 3. Set target properties  
            fileTarget.FileName = "${basedir}/GlimpseLog.log";
            fileTarget.Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}";

            // Step 4. Define rules 
            var rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule2);
             
            return new LogFactory(config);  
        }
    }
}
