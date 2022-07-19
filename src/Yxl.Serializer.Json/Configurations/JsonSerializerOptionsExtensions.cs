
using Newtonsoft.Json;
using System;
using Yxl.Serializer.Configurations;

namespace Yxl.Serializer.Json.Configurations
{
    /// <summary>
    /// EasyCaching options extensions.
    /// </summary>
    public static class JsonSerializerOptionsExtensions
    {
        /// <summary>
        /// Withs the json serializer.
        /// </summary>        
        /// <param name="options">Options.</param>        
        /// <param name="name">The name of this serializer instance.</param>        
        public static SerializerOptions WithJson(this SerializerOptions options, string name = "NewtonsoftJson") => options.WithJson(configure: x => { }, name);

        /// <summary>
        /// Withs the json serializer.
        /// </summary>        
        /// <param name="options">Options.</param>
        /// <param name="configure">Configure serializer settings.</param>
        /// <param name="name">The name of this serializer instance.</param>     
        public static SerializerOptions WithJson(this SerializerOptions options, Action<JsonSerializerOptions> configure, string name)
        {
            var easyCachingJsonSerializerOptions = new JsonSerializerOptions();

            configure(easyCachingJsonSerializerOptions);

            Action<JsonSerializerSettings> jsonSerializerSettings = x =>
            {
                x.ReferenceLoopHandling = easyCachingJsonSerializerOptions.ReferenceLoopHandling;
                x.TypeNameHandling = easyCachingJsonSerializerOptions.TypeNameHandling;
                x.MetadataPropertyHandling = easyCachingJsonSerializerOptions.MetadataPropertyHandling;
                x.MissingMemberHandling = easyCachingJsonSerializerOptions.MissingMemberHandling;
                x.NullValueHandling = easyCachingJsonSerializerOptions.NullValueHandling;
                x.DefaultValueHandling = easyCachingJsonSerializerOptions.DefaultValueHandling;
                x.ObjectCreationHandling = easyCachingJsonSerializerOptions.ObjectCreationHandling;
                x.PreserveReferencesHandling = easyCachingJsonSerializerOptions.PreserveReferencesHandling;
                x.ConstructorHandling = easyCachingJsonSerializerOptions.ConstructorHandling;
            };

            options.RegisterExtension(new JsonSerializerOptionsExtension(name, jsonSerializerSettings));

            return options;
        }

        /// <summary>
        /// Withs the json serializer.
        /// </summary>        
        /// <param name="options">Options.</param>
        /// <param name="jsonSerializerSettingsConfigure">Configure serializer settings.</param>
        /// <param name="name">The name of this serializer instance.</param>     
        public static SerializerOptions WithJson(this SerializerOptions options, Action<JsonSerializerSettings> jsonSerializerSettingsConfigure, string name)
        {
            options.RegisterExtension(new JsonSerializerOptionsExtension(name, jsonSerializerSettingsConfigure));

            return options;
        }
    }
}
