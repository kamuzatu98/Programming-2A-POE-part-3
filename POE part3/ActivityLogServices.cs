using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot.Wpf
{
    public class ActivityLogService
    {
        private readonly List<ActivityLogEntry> _entries = new List<ActivityLogEntry>();

        public void Add(string description)
        {
            _entries.Add(new ActivityLogEntry(description));
        }

        /// <summary>
        /// Returns the most recent entries (newest last), capped to keep the log concise.
        /// </summary>
        public List<ActivityLogEntry> GetRecent(int count = 10)
        {
            int skip = _entries.Count > count ? _entries.Count - count : 0;
            return _entries.Skip(skip).ToList();
        }

        public List<ActivityLogEntry> GetAll()
        {
            return _entries.ToList();
        }

        public int Count => _entries.Count;

        /// <summary>
        /// Returns all entries as formatted strings
        /// </summary>
        public List<string> GetAsStrings()
        {
            return _entries.Select(e => e.ToString()).ToList();
        }

        /// <summary>
        /// Returns recent entries as formatted strings
        /// </summary>
        public List<string> GetRecentAsStrings(int count = 10)
        {
            return GetRecent(count).Select(e => e.ToString()).ToList();
        }
    }
}
