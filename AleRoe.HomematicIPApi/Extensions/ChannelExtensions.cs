using AleRoe.HomematicIpApi.Model;
using AleRoe.HomematicIpApi.Model.Channels;
using AleRoe.HomematicIpApi.Model.Devices;
using System;
using System.Diagnostics;
using System.Reflection;

namespace AleRoe.HomematicIpApi.Extensions
{
    public static class ChannelExtensions
    {
        public static IFunctionalChannel CopyTo<T>(this IFunctionalChannel channel, T instance) where T : IDevice
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            var props = typeof(T).GetProperties(flags);

            foreach (var prop in props)
            {
                try
                {
                    var sourceProp = channel.GetType().GetProperty(prop.Name);
                    if (sourceProp == null)
                    {
                        Debug.WriteLine("Sucks");
                        continue;
                    }
                    var value = sourceProp.GetValue(channel);
                    prop.SetValue(instance, value);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                
            }

            return channel;
        }

        public static TChannel CopyToEx<TChannel>(this TChannel channel, IDevice device) where TChannel : IFunctionalChannel
        {
            var flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            var props = device.GetType().GetProperties(flags);

            foreach (var prop in props)
            {
                var sourceProp = channel.GetType().GetProperty(prop.Name);
                if (sourceProp == null)
                {
                    Debug.WriteLine("Sucks");
                    continue;
                }
                var value = sourceProp.GetValue(channel);
                prop.SetValue(device, value);
            }

            return channel;
        }

        public static void SetSupportedOptionalFeatures(this DeviceBaseChannel channel, IDevice instance)
        {
            if (channel.SupportedOptionalFeatures == null)
                return;

            var features = typeof(SupportedOptionalFeatures).GetProperties();
            foreach (var feature in features)
            {
                if (feature.GetValue(channel.SupportedOptionalFeatures) is bool value && !value)
                {
                    var attr = feature.GetCustomAttribute<OptionalFeaturePropertyAttribute>();
                    if (attr != null)
                    {
                        var property = instance.GetType().GetProperty(attr.PropertyName);
                        property = property?.DeclaringType?.GetProperty(attr.PropertyName);
                        property?.SetValue(instance, null, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null);
                    }
                }
            }
        }

    }
}
