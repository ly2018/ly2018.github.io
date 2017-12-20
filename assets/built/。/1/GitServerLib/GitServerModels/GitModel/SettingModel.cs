using System;
using System.Collections.Generic;
using System.Text;

namespace GitServerModels.GitModel
{
    public class SettingModel
    {
        public const String SPACE_DELIMITED = "SPACE-DELIMITED";

        public const String CASE_SENSITIVE = "CASE-SENSITIVE";

        public const String RESTART_REQUIRED = "RESTART REQUIRED";

        public const String SINCE = "SINCE";

        public String name;
        public volatile String currentValue;
        public String defaultValue;
        public String description;
        public String since;
        public bool caseSensitive;
        public bool restartRequired;
        public bool spaceDelimited;

        private const long serialVersionUID = 1L;

    }
}
