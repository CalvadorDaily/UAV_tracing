
namespace uav_tracng
{
    public class Project
    {
        public int projectID;
        public string projectName;
        public int countDevices = 0;
        public double crossEstimate = 0;
        public int chanellsVolume = 0;
        public int countCon = 0;
        public bool is_opened = false;
        public bool is_set = false;
        public void set_default()
        {
        countDevices = 0;
        crossEstimate = 0;
        chanellsVolume = 0;
        countCon = 0;
        is_opened = false;
        is_set = false;
        }
    }
}

