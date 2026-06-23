using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace LogsFormat;

class LogsFormat
{
    public string ChangeLogsFormat(string oldLogPattern, string oldLogLine, string oldFormatOfDate, string newFormatOfDate, string[] levelCorrectShortForms, string defaultMethodCallerValue, string delimiter)
    {
        string newFormatLine = string.Empty;
        Regex rx = new Regex(oldLogPattern);
        Match match = rx.Match(oldLogLine);
        if (match.Success)
        {
            Console.WriteLine(match.Value);
            newFormatLine += ChangeDateFormat(newFormatOfDate, oldFormatOfDate, match.Groups[1].Value) + delimiter;
            newFormatLine += match.Groups[2].Value + delimiter;
            newFormatLine += ChangeLevelOfLoggingFormat(match.Groups[3].Value, levelCorrectShortForms) + delimiter;
            if (String.IsNullOrEmpty(match.Groups[4].Value))
            {
                Console.WriteLine("?");
                newFormatLine += defaultMethodCallerValue + delimiter;
            }
            else
            {
                newFormatLine += match.Groups[4].Value + delimiter;
                Console.WriteLine(match.Groups[4].Value);
            }
            newFormatLine += match.Groups[5].Value;
        }
        else
        {
            Console.WriteLine("problem");
        }
        return newFormatLine;
    }
    public string ChangeDateFormat(string newDatePattern, string oldPattern, string oldFormatDate)
    {
        string newFormatDate = string.Empty;
        try
        {
            newFormatDate = (DateTime.
            ParseExact(oldFormatDate, oldPattern, CultureInfo.InvariantCulture)).ToString(newDatePattern);
        }
        catch { }
        return newFormatDate;
    }
    public string ChangeLevelOfLoggingFormat(string oldLoggingLevel, string[] newFormatValues)
    {
        for (int i = 0; i < newFormatValues.Length; i++)
        {
            if (oldLoggingLevel.StartsWith(newFormatValues[i]))
                return newFormatValues[i];

        }
        return oldLoggingLevel;
    }
    public void DoAll()
    {
        string delimiter = "\t";
        string newFormatOfDate = "dd-MM-yyyy";
        string[] levelCorrectShortForms = { "INFO", "WARN" };
        string defaultMethodCallerValue = "DEFAULT";
        string oldFormatOfDate1 = "dd.MM.yyyy";
        string oldFormatOfDate2 = "yyyy-MM-dd";
        string oldLogLine1 = "10.03.2025 15:14:49.523 INFORMATION Версия программы: '3.4.0.48729'";
        string oldLogLine2 = "2025-03-10 15:14:51.5882| INFO|11|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'";
        string datePattern1 = @"^(\d\d.\d\d.\d{4})";
        string datePattern2 = @"^(\d{4}-\d\d-\d\d)";
        string timePattern = @"(\d\d:\d\d:\d\d.\d+)";
        string methodCallerPattern = @"([A-Z]*[a-z]*\.*_*[A-Z]*[a-z]*)";
        string methodCallerPattern2 = @"([A-Z]+[a-z]+\.*_*[A-Z]*[a-z]*)";
        string loggingLevelPattern = @"(INFO\w*|WARN\w*|ERROR|DEBUG)";
        string messagePattern = @"(.+)$";
        string patternFirtstFormat = $"{datePattern1} {timePattern} {loggingLevelPattern} {methodCallerPattern} *{messagePattern}";
        Console.WriteLine(patternFirtstFormat);
        string patternSecondFormat = $@"{datePattern2} {timePattern}\|* *{loggingLevelPattern}\|.*\|*{methodCallerPattern}\| *{messagePattern}";
        Console.WriteLine(patternSecondFormat);
        string newFormatLine1 = ChangeLogsFormat(patternFirtstFormat, oldLogLine1, oldFormatOfDate1, newFormatOfDate, levelCorrectShortForms, defaultMethodCallerValue, delimiter);
        Console.WriteLine(newFormatLine1);
        string newFormatLine2 = ChangeLogsFormat(patternSecondFormat, oldLogLine2, oldFormatOfDate2, newFormatOfDate, levelCorrectShortForms, defaultMethodCallerValue, delimiter);
        Console.WriteLine(newFormatLine2);

    }
}