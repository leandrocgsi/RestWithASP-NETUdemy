namespace RestWithASPNETUdemy.Business.Implementattions
{
    public class FileBusinessImpl : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("C:\\Dev\\Playground\\Code\\RestWithASP-NETUdemy\\RestWithASPNETUdemy 14 - Binary Files\\RestWithASPNETUdemy\\Other\\aspnet-life-cycles-events.pdf");
            return bytes;
        }
    }
}
