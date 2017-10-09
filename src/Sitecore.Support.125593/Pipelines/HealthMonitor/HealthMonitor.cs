using Sitecore.IO;
using Sitecore.Pipelines.HealthMonitor;
using System;
using System.IO;
using Sitecore.Pipelines;

namespace Sitecore.Support.Pipelines.HealthMonitor
{
  public class HealthMonitor : Sitecore.Pipelines.HealthMonitor.HealthMonitor
  {
    protected override void DumpInFile(string text)
    {
      string fileName = base.DumpFile.Replace("{datetime}", DateUtil.IsoNow)
        .Replace("{date}", DateUtil.IsoNowDate)
        .Replace("{time}", DateUtil.IsoNowTime);

      FileUtil.EnsureFileFolder(fileName);
      using (StreamWriter writer = File.CreateText(fileName))
      {
        writer.Write(text);
      }
    }
  }
}