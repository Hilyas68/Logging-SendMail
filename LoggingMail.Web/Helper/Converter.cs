using System.Web;

namespace LoggingMail.Web.Helper
{
    public class Converter : log4net.Util.PatternConverter
    {
        override protected void Convert(System.IO.TextWriter writer, object state)
        {
            //Environment.SpecialFolder specialFolder = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), base.Option, true);
            string homePath = HttpRuntime.AppDomainAppPath;
            //writer.Write(Environment.GetFolderPath(specialFolder));
            writer.Write(homePath);
        }

    }
}