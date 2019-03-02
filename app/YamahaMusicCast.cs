using System;
using System.Collections.Generic;
using System.Text;

namespace app.YamahaMusicCast
{

    public class SimpleResponse
    {
        public int response_code { get; set; }
    }


    /// <summary>
    /// GetFeatures
    /// </summary>
    public class Features
    {
        public int response_code { get; set; }
        public System system { get; set; }
        public Zone[] zone { get; set; }
        public Netusb netusb { get; set; }
        public Distribution distribution { get; set; }
        public Ccs ccs { get; set; }
    }

    public class System
    {
        public string[] func_list { get; set; }
        public int zone_num { get; set; }
        public Input_List[] input_list { get; set; }
        public string[] ymap_list { get; set; }
    }

    public class Input_List
    {
        public string id { get; set; }
        public bool distribution_enable { get; set; }
        public bool rename_enable { get; set; }
        public bool account_enable { get; set; }
        public string play_info_type { get; set; }
    }

    public class Netusb
    {
        public string[] func_list { get; set; }
        public Preset preset { get; set; }
        public Recent_Info recent_info { get; set; }
        public Play_Queue play_queue { get; set; }
        public Mc_Playlist mc_playlist { get; set; }
        public string net_radio_type { get; set; }
        public string vtuner_fver { get; set; }
        public Pandora pandora { get; set; }
    }

    public class Preset
    {
        public int num { get; set; }
    }

    public class Recent_Info
    {
        public int num { get; set; }
    }

    public class Play_Queue
    {
        public int size { get; set; }
    }

    public class Mc_Playlist
    {
        public int size { get; set; }
        public int num { get; set; }
    }

    public class Pandora
    {
        public string[] sort_option_list { get; set; }
    }

    public class Distribution
    {
        public float version { get; set; }
        public int[] compatible_client { get; set; }
        public int client_max { get; set; }
        public string[] server_zone_list { get; set; }
    }

    public class Ccs
    {
        public bool supported { get; set; }
    }

    public class Zone
    {
        public string id { get; set; }
        public string[] func_list { get; set; }
        public string[] input_list { get; set; }
        public string[] equalizer_mode_list { get; set; }
        public string[] link_control_list { get; set; }
        public string[] link_audio_quality_list { get; set; }
        public Range_Step[] range_step { get; set; }
    }

    public class Range_Step
    {
        public string id { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int step { get; set; }
    }

    /////////////////////////////////////////////////////////////////////////

    public class DeviceInfo
    {
        public int response_code { get; set; }
        public string model_name { get; set; }
        public string destination { get; set; }
        public string device_id { get; set; }
        public string system_id { get; set; }
        public float system_version { get; set; }
        public float api_version { get; set; }
        public int netmodule_generation { get; set; }
        public string netmodule_version { get; set; }
        public string netmodule_checksum { get; set; }
        public string operation_mode { get; set; }
        public string update_error_code { get; set; }
    }


    public class NetworkStatus
    {
        public int response_code { get; set; }
        public string network_name { get; set; }
        public string connection { get; set; }
        public bool dhcp { get; set; }
        public string ip_address { get; set; }
        public string subnet_mask { get; set; }
        public string default_gateway { get; set; }
        public string dns_server_1 { get; set; }
        public string dns_server_2 { get; set; }
        public Wireless_Lan wireless_lan { get; set; }
        public Wireless_Direct wireless_direct { get; set; }
        public Musiccast_Network musiccast_network { get; set; }
        public Mac_Address mac_address { get; set; }
        public string vtuner_id { get; set; }
        public string airplay_pin { get; set; }
    }

    public class Wireless_Lan
    {
        public string ssid { get; set; }
        public string type { get; set; }
        public string key { get; set; }
        public int ch { get; set; }
        public int strength { get; set; }
    }

    public class Wireless_Direct
    {
        public string ssid { get; set; }
        public string type { get; set; }
        public string key { get; set; }
    }

    public class Musiccast_Network
    {
        public bool ready { get; set; }
        public string device_type { get; set; }
        public int child_num { get; set; }
        public int ch { get; set; }
        public bool initial_join_running { get; set; }
    }

    public class Mac_Address
    {
        public string wired_lan { get; set; }
        public string wireless_lan { get; set; }
        public string wireless_direct { get; set; }
    }

    /////////////////////////////////////////////////////////////////////////////

    public class PlayInfo
    {
        public int response_code { get; set; }
        public string input { get; set; }
        public string play_queue_type { get; set; }
        public string playback { get; set; }
        public string repeat { get; set; }
        public string shuffle { get; set; }
        public int play_time { get; set; }
        public int total_time { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public string track { get; set; }
        public string albumart_url { get; set; }
        public int albumart_id { get; set; }
        public string usb_devicetype { get; set; }
        public bool auto_stopped { get; set; }
        public int attribute { get; set; }
        public string[] repeat_available { get; set; }
        public string[] shuffle_available { get; set; }
    }

    //////////////////////////////////////////////////////////////////////////////////////


    public class AccountStatus
    {
        public int response_code { get; set; }
        public Service_List[] service_list { get; set; }
    }

    public class Service_List
    {
        public string id { get; set; }
        public bool registered { get; set; }
        public string login_status { get; set; }
        public string username { get; set; }
        public string type { get; set; }
        public int trial_time_left { get; set; }
    }

}
