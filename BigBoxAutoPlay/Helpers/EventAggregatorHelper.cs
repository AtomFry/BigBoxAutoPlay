﻿using Prism.Events;

namespace BigBoxAutoPlay.Helpers
{
    public sealed class EventAggregatorHelper
    {
        private static readonly EventAggregatorHelper instance = new EventAggregatorHelper();

        static EventAggregatorHelper()
        {
        }

        private EventAggregatorHelper()
        {
            eventAggregator = new EventAggregator();
        }

        public static EventAggregatorHelper Instance
        {
            get
            {
                return instance;
            }
        }

        private EventAggregator eventAggregator;

        public EventAggregator EventAggregator
        {
            get { return eventAggregator; }
        }
    }
}
