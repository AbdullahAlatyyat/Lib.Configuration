namespace Framework.Configuration
{
    using System;

    public class ConfigurationException : Exception
    {
        public ConfigurationException()
        {
        }

        public ConfigurationException(string message)
            : base(message)
        {
        }

        public ConfigurationException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}