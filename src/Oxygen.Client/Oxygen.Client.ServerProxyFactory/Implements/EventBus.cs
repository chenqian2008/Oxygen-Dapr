﻿using Oxygen.Client.ServerProxyFactory.Interface;
using Oxygen.Client.ServerSymbol.Events;
using Oxygen.Common;
using Oxygen.ProxyGenerator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oxygen.Client.ServerProxyFactory.Implements
{
    public class EventBus : IEventBus
    {
        private readonly IRemoteMessageSender messageSender;
        public EventBus(IRemoteMessageSender messageSender)
        {
            this.messageSender = messageSender;
        }
        public async Task<DefaultResponse> SendEvent<T>(string topic, T input)
        {
            return await messageSender.SendMessage<DefaultResponse>(DaprConfig.GetCurrent().PubSubCompentName, $"/{topic}", input, SendType.publish);
        }
    }
}