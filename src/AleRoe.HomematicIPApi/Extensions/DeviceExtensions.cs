using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using AleRoe.HomematicIpApi.Model;
using AleRoe.HomematicIpApi.Model.Channels;
using AleRoe.HomematicIpApi.Model.Devices;

namespace AleRoe.HomematicIpApi.Extensions
{
    public static class DeviceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsLightAndShadow(this IDevice device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            var channels = device.FunctionalChannels;
            var result = device.Service.GetCurrentStateAsync(CancellationToken.None).Result;
            var lightAndShadow = result.Home.FunctionalHomes.LightAndShadow;
            
            return lightAndShadow.FunctionalGroups.Any(group =>
                    channels.Any(channel => channel.Groups.Contains(group)));
        }

        public static bool GetOnState(this IDevice device)
        {
            switch (device.Type)
            {
                case DeviceType.BRAND_DIMMER:
                    var dimmerChannel = device.GetFunctionalChannel<DimmerChannel>();
                    return dimmerChannel.On;

                case DeviceType.PLUGABLE_SWITCH_MEASURING:
                    var switchChannel = device.GetFunctionalChannel<SwitchMeasuringChannel>();
                    return switchChannel.On;

                default:
                    throw new InvalidOperationException($"DeviceType {device.Type} not supported");
            }
        }

        public static WindowState? GetWindowState(this IDevice device)
        {
            switch (device.Type)
            {
                case DeviceType.SHUTTER_CONTACT:
                    var shutterChannel = device.GetFunctionalChannel<ShutterContactChannel>();
                    return shutterChannel.WindowState;

                default:
                    throw new InvalidOperationException($"DeviceType {device.Type} not supported");
            }
        }

        /// <summary>
        /// Returns the single occurrence of the given <see cref="IFunctionalChannel" />, and throws an exception if there is
        /// not exactly one element
        /// </summary>
        /// <typeparam name="T">
        ///     <see cref="IFunctionalChannel" />
        /// </typeparam>
        /// <param name="device"></param>
        /// <returns></returns>
        public static T GetFunctionalChannel<T>(this IDevice device) where T : IFunctionalChannel
        {
                var channels = device.FunctionalChannels.OfType<T>().ToList();
                if (channels.Any())
                {
                    if (channels.Count == 1)
                    {
                        return channels.Single();
                    }

                    return channels.SingleOrDefault(x => x.GetType() == typeof(T));
                }
                return default;

                
            
        }
        
        public static IEnumerable<T> GetFunctionalChannels<T>(this IDevice device) where T : IFunctionalChannel
        {
            return device.FunctionalChannels.OfType<T>();
        }

        public static IEnumerable<T> GetFunctionalChannels<T>(this IDevice device, Func<T, bool> predicate)
            where T : IFunctionalChannel
        {
            return device.FunctionalChannels.OfType<T>().Where(predicate);
        }

        public static IEnumerable<IFunctionalChannel> GetFunctionalChannels(this IDevice device)
        {
            if (device == null) 
                throw new ArgumentNullException(nameof(device));

            var attributes = device.GetType().GetCustomAttributes<FunctionalChannelTypeAttribute>(true);
            var channelTypes = attributes.Select(a => a.FunctionalChannelType);

            return device.FunctionalChannels.Where(x => channelTypes.Contains(x.FunctionalChannelType));
        }
    }
}