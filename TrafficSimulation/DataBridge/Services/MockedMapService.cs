using Repositories;
using System;
using Datamodel;
using System.IO;

namespace DataBridge.Services
{
    class MockedMapService : IMapRepository
    {
        private Map map = null;
        private MockedDefinitions definitions = MockedDefinitions.getInstance();
        private string backGroundMapfilename; 

        public MockedMapService()
        {
            map = new Map();
            backGroundMapfilename = definitions.getbackGroundMapfilename();
            byte[] imagedata = backGroundMapreader(backGroundMapfilename);
            var temp = Convert.ToBase64String(imagedata);
            map.BackgroundImageBase64 = temp.ToCharArray();
            
            // Mal ableiten aus dem Image
            map.Height = 1080;
            map.Width = 1920;
        }
        public Map GetMap()
        {
            return map;
        }


        private byte[] backGroundMapreader(string filename)
        {
            var fs = new FileStream(filename, FileMode.Open);
            var len = (int)fs.Length;
            var filedata = new byte[len];
            fs.Read(filedata, 0, len);
            fs.Close();
            return (filedata);
        }
    }
}
