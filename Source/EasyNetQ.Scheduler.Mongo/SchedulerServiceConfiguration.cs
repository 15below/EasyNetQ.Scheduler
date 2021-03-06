﻿using System;
using System.Configuration;

namespace EasyNetQ.Scheduler.Mongo
{
    public class SchedulerServiceConfiguration : ConfigurationBase, ISchedulerServiceConfiguration
    {
        public bool EnableLegacyConventions { get; set; }
        public string SubscriptionId { get; set; }
        public TimeSpan PublishInterval { get; set; }
        public TimeSpan HandleTimeoutInterval { get; set; }
        public int PublishMaxSchedules { get; set; }
        public string RabbitHost { get; set; }

        public static SchedulerServiceConfiguration FromConfigFile()
        {
            return new SchedulerServiceConfiguration
            {
                RabbitHost = ConfigurationManager.ConnectionStrings["rabbit"].ConnectionString,
                SubscriptionId = ConfigurationManager.AppSettings["subscriptionId"],
                PublishInterval = GetTimeSpanAppSettings("publishInterval"),
                PublishMaxSchedules = GetIntAppSetting("publishMaxSchedules"),
                HandleTimeoutInterval = GetTimeSpanAppSettings("handleTimeoutInterval"),
                EnableLegacyConventions = GetBoolAppSetting("enableLegacyConventions")
            };
        }
    }
}
